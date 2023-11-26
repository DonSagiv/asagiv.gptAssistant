namespace asagiv.UI.gptAssistant.ConsoleDiagnostics
{
    public static class GptResponseParseTesting
    {
        public static string SimulateBulkResponse()
        {
            return
                """
                 {
                   "id": "chatcmpl-123",
                   "object": "chat.completion",
                   "created": 1677652288,
                   "model": "gpt-3.5-turbo-0613",
                   "system_fingerprint": "fp_44709d6fcb",
                   "choices": [{
                     "index": 0,
                     "message": {
                       "role": "assistant",
                       "content": "\n\nHello there, how may I assist you today?"
                     },
                     "finish_reason": "stop"
                   }],
                   "usage": {
                     "prompt_tokens": 9,
                     "completion_tokens": 12,
                     "total_tokens": 21
                   }
                 }
                """;
        }

        public static IEnumerable<string> SimulateResponseStream()
        {
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

            var responseStrings = responseStringRaw.Split("\n\r");

            foreach(var responseString in responseStrings)
            {
                yield return responseString;
            }
        }
    }
}
