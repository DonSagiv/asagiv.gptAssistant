using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.gptAssistant.Enumerators;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace asagiv.Infrastructure.gptAssistant.Web.Models;

public class HttpGptRequestHandler(IGptRequestSerializer requestSerializerInput,
    IGptResponseParserFactory responseParserFactoryInput,
    IGptRequestAuthenticationService authenticationService)
    : IRequestHandler<IGptRequest, IEnumerable<IGptResponse>>
{
    #region Statics
    // todo: make settings/environemnt variables.
    private static readonly string url = @"https://api.openai.com/v1/";
    #endregion

    #region Fields
    private readonly IGptRequestSerializer _requestSerializer = requestSerializerInput;
    private readonly IGptResponseParserFactory _responseFactoryParser = responseParserFactoryInput;
    private readonly IGptRequestAuthenticationService _authenticationService = authenticationService;
    #endregion

    #region Methods
    public async Task<IEnumerable<IGptResponse>> Handle(IGptRequest request, CancellationToken cancellationToken)
    {
        /*
        var options = new HttpRequestProcessorOptions
        {
            ApiKey = GetApiKey()
        };
        */

        var httpResponse = await SendRequestAsync(request);

        if (httpResponse.StatusCode != HttpStatusCode.OK)
        {
            // todo: return result instead.
            return [];
        }

        var responses = ParseResponseAsync(request, httpResponse);

        return await responses.ToArrayAsync(cancellationToken);
    }

    private async Task<HttpResponseMessage> SendRequestAsync(IGptRequest request, HttpRequestProcessorOptions options = null)
    {
        using var httpClient = new HttpClient() { BaseAddress = new Uri(url) };

        // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", pipeline.Options.ApiKey);

        var requestJson = _requestSerializer.Serialize(request);

        var content = new StringContent(requestJson);

        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        return await httpClient.PostAsync("chat/completions", content);
    }

    private IAsyncEnumerable<IGptResponse> ParseResponseAsync(IGptRequest request, HttpResponseMessage httpResponse)
    {
        var deliveryMethod = request.GetRequestDeliveryMechanism();

        if (deliveryMethod == ResponseDeliveryMethod.Stream)
        {
            return ProcessStreamAsync(httpResponse, deliveryMethod);
        }
        else
        {
            return ProcessSingleResponseAsync(httpResponse, deliveryMethod);
        }
    }

    private async IAsyncEnumerable<IGptResponse> ProcessStreamAsync(HttpResponseMessage httpResponse, ResponseDeliveryMethod deliveryMethod)
    {
        using var stream = await httpResponse.Content.ReadAsStreamAsync();
        using var streamReader = new StreamReader(stream);

        string streamResponse;

        while ((streamResponse = await streamReader.ReadLineAsync()) != null)
        {
            yield return await ProcessResponseAsync(deliveryMethod, streamResponse);
        }
    }

    private async IAsyncEnumerable<IGptResponse> ProcessSingleResponseAsync(HttpResponseMessage httpResponse, ResponseDeliveryMethod deliveryMethod)
    {
        var responseString = await httpResponse.Content.ReadAsStringAsync();

        yield return await ProcessResponseAsync(deliveryMethod, responseString);
    }

    private Task<IGptResponse> ProcessResponseAsync(ResponseDeliveryMethod responseType, string streamResponse)
    {
        var parser = _responseFactoryParser.OfResponseType(responseType);

        var response = parser.ParseResponse(streamResponse);

        return Task.FromResult(response);
    }
    #endregion
}