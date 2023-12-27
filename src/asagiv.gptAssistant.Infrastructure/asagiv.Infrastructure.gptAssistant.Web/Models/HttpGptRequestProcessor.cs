using asagiv.Application.gptAssistant.Interfaces;
using asagiv.domain.core.DependencyInjection;
using asagiv.domain.core.Models;
using asagiv.Domain.gptAssistant.Enumerators;
using asagiv.Domain.gptAssistant.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;

namespace asagiv.Infrastructure.gptAssistant.Web.Models
{
    [Export(typeof(IGptRequestProcessor))]
    public class HttpGptRequestProcessor : DisposableBase, IGptRequestProcessor
    {
        #region Statics
        // todo: make settings/environemnt variables.
        private static readonly string url = @"https://api.openai.com/v1/";
        #endregion

        #region Fields
        private readonly IGptRequestSerializer _requestSerializer;
        private readonly IGptResponseParserFactory _responseFactoryParser;
        private readonly Subject<HttpRequestPipeline> _processHttpRequestSubject = new Subject<HttpRequestPipeline>();
        private readonly Subject<IGptResponse> _responseProcessedSubject = new Subject<IGptResponse>();
        private readonly TaskCompletionSource<bool> _isCompletedChanged = new TaskCompletionSource<bool>();
        
        private HttpClient _httpClient;
        #endregion

        #region Properties
        public IObservable<IGptResponse> ResponseProcessedObservable => _responseProcessedSubject.AsObservable();
        #endregion

        #region Constructor
        public HttpGptRequestProcessor(IGptRequestSerializer requestSerializerInput,
            IGptResponseParserFactory responseParserFactoryInput)
        {
            _requestSerializer = requestSerializerInput;
            _responseFactoryParser = responseParserFactoryInput;

            _processHttpRequestSubject
                .SelectMany(SendRequestAsync)
                .SelectMany(ParseResponseAsync)
                .Subscribe(OnGptRequestCompleted);
        }
        #endregion

        #region Methods
        public void ProcessRequest(IGptRequest request, IRequestProcessorOptions options)
        {
            if (!(options is HttpRequestProcessorOptions httpOptions))
            {
                throw new ArgumentException("Incorrect request processor options type.", nameof(options));
            }

            var pipeline = new HttpRequestPipeline
            {
                GptRequest = request,
                Options = httpOptions,
            };

            _httpClient = new HttpClient() { BaseAddress = new Uri(url) };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", pipeline.Options.ApiKey);

            _processHttpRequestSubject.OnNext(pipeline);
        }

        private async Task<HttpRequestPipeline> SendRequestAsync(HttpRequestPipeline pipeline)
        {
            var requestJson = _requestSerializer.Serialize(pipeline.GptRequest);

            var content = new StringContent(requestJson);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            pipeline.HttpResponse = await _httpClient.PostAsync("chat/completions", content);

            return pipeline;
        }

        private async Task<HttpRequestPipeline> ParseResponseAsync(HttpRequestPipeline pipeline)
        {
            if (pipeline.HttpResponse.StatusCode != HttpStatusCode.OK)
            {
                pipeline.ErrorMessage = pipeline.HttpResponse.ReasonPhrase;

                return pipeline;
            }

            var deliveryMethod = pipeline.GptRequest.GetRequestDeliveryMechanism();

            if (pipeline.GptRequest.Stream)
            {
                await ProcessStreamAsync(pipeline, deliveryMethod);
            }
            else
            {
                await ProcessSingleResponseAsync(pipeline, deliveryMethod);
            }

            return pipeline;
        }

        private async Task ProcessStreamAsync(HttpRequestPipeline pipeline, ResponseDeliveryMethod deliveryMethod)
        {
            using (var stream = await pipeline.HttpResponse.Content.ReadAsStreamAsync())
            {
                using (var streamReader = new StreamReader(stream))
                {
                    string streamResponse;

                    while ((streamResponse = await streamReader.ReadLineAsync()) != null)
                    {
                        var response = await ProcessResponseAsync(deliveryMethod, streamResponse);

                        pipeline.AppendResponse(response);
                    }
                }
            }
        }

        private async Task ProcessSingleResponseAsync(HttpRequestPipeline pipeline, ResponseDeliveryMethod deliveryMethod)
        {
            var responseString = await pipeline.HttpResponse.Content.ReadAsStringAsync();

            var response = await ProcessResponseAsync(deliveryMethod, responseString);

            pipeline.AppendResponse(response);
        }

        private void OnGptRequestCompleted(HttpRequestPipeline pipeline)
        {
            pipeline.IsComplete = true;

            _isCompletedChanged.TrySetResult(true);
        }

        private Task<IGptResponse> ProcessResponseAsync(ResponseDeliveryMethod responseType, string streamResponse)
        {
            var parser = _responseFactoryParser.OfResponseType(responseType);

            var response = parser.ParseResponse(streamResponse);

            _responseProcessedSubject.OnNext(response);

            return Task.FromResult(response);
        }

        protected override void OnDisposing()
        {
            _httpClient?.Dispose();
        }

        public async Task AwaitCompletion()
        {
            await _isCompletedChanged.Task;
        }
        #endregion
    }
}
