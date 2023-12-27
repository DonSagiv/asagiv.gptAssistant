using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.Core.DependencyInjection;
using asagiv.Domain.gptAssistant.Enumerators;
using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Infrastructure.gptAssistant.Tests;

public class SerializerTesting
{
    public SerializerTesting()
    {
        ComponentContainer.Container.Initialize();
    }

    [Fact]
    public void BulkGptParser_ShouldNot_ThrowException()
    {
        // Arrange
        var responseStringRaw =
             """
             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"role":"assistant","content":""},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":"Sure"},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":","},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":" here"},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":" are"},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":" three"},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":" random"},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":" words"},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":":\n\n"},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":"1"},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":"."},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":" Eclipse"},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":"\n"},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":"2"},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":"."},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":" Harmon"},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":"ica"},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":"\n"},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":"3"},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":"."},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":" Wander"},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{"content":"lust"},"finish_reason":null}]}

             data: {"id":"chatcmpl-8OXKIFmKYpWoErEd1oV99qRn5wbI4","object":"chat.completion.chunk","created":1700858670,"model":"gpt-4-1106-preview","system_fingerprint":"fp_a24b4d720c","choices":[{"index":0,"delta":{},"finish_reason":"stop"}]}

             data: [DONE]
             """;

        // Act
        var exception = Record.Exception(() =>
        {
            var responseStrings = responseStringRaw.Split("\n\r");

            var parserFactory = ComponentContainer.Container.Build<IGptResponseParserFactory>();
            var parser = parserFactory.OfResponseType(ResponseDeliveryMethod.Stream);

            var responses = new List<IGptResponse>();

            foreach (var responseString in responseStrings)
            {
                var response = parser.ParseResponse(responseString);

                responses.Add(response);
            }
        });

        // Assert
        Assert.Null(exception);
    }
}