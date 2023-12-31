﻿using asagiv.Application.gptAssistant.Interfaces;
using asagiv.domain.core.DependencyInjection;
using asagiv.Domain.gptAssistant.Enumerators;
using asagiv.Domain.gptAssistant.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace asagiv.Infrastructure.gptAssistant.Web
{
    [Export(typeof(IGptRequestProcessor))]
    public class HttpGptRequestProcessor : IGptRequestProcessor
    {
        #region Statics
        // todo: make settings/environemnt variables.
        private static readonly string url = @"https://api.openai.com/v1/";
        #endregion

        #region Fields
        private readonly IGptRequestSerializer _requestSerializer;
        private readonly IGptResponseParserFactory _responseFactoryParser;
        #endregion

        #region Constructor
        public HttpGptRequestProcessor(IGptRequestSerializer requestSerializerInput,
            IGptResponseParserFactory responseParserFactoryInput)
        {
            _requestSerializer = requestSerializerInput;
            _responseFactoryParser = responseParserFactoryInput;
        }
        #endregion

        #region Methods
        public async IAsyncEnumerable<IGptResponse> ProcessAsync(IGptRequest gptRequest, IRequestProcessorOptions options)
        {
            if(!(options is HttpRequestProcessorOptions httpOptions))
            {
                throw new ArgumentException("Incorrect request processor options type.", nameof(options));
            }

            var deliveryMethod = gptRequest.GetRequestDeliveryMechanism();

            using var client = new HttpClient()
            {
                BaseAddress = new Uri(url)
            };

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", httpOptions.ApiKey);

            var requestJson = _requestSerializer.Serialize(gptRequest);

            var content = new StringContent(requestJson);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("chat/completions", content);

            if(response.StatusCode != HttpStatusCode.OK)
            {
                yield break;
            }

            if(gptRequest.Stream)
            {
                using var stream = await response.Content.ReadAsStreamAsync();

                using var streamReader = new StreamReader(stream);

                string streamResponse;

                while ((streamResponse = await streamReader.ReadLineAsync()) != null)
                {
                    yield return await ProcessResultAsync(deliveryMethod, streamResponse);
                }
            }
            else
            {
                var responseString = await response.Content.ReadAsStringAsync();

                yield return await ProcessResultAsync(deliveryMethod, responseString);
            }
        }

        private Task<IGptResponse> ProcessResultAsync(ResponseDeliveryMethod responseType, string streamResponse)
        {
            var parser = _responseFactoryParser.OfResponseType(responseType);

            var response = parser.ParseResponse(streamResponse);

            return Task.FromResult(response);
        }
        #endregion
    }
}
