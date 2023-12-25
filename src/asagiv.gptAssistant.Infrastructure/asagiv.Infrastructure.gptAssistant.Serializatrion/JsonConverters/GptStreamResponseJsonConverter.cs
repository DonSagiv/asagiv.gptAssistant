using asagiv.Application.gptAssistant.Interfaces;
using asagiv.domain.core.DependencyInjection;
using asagiv.Domain.gptAssistant.Enumerators;
using asagiv.Domain.gptAssistant.Interfaces;
using System.Linq;
using System.Text.Json.Nodes;

namespace asagiv.Infrastructure.gptAssistant.Serializatrion.JsonConverters
{
    [Export(typeof(IGptResponseParser), contractKey: ResponseDeliveryMethod.Stream, creationPolicy: CreationPolicy.Singleton)]
    internal sealed class GptStreamResponseJsonConverter : GptResponseJsonConverterBase
    {
        protected override bool IsValidJsonString(string jsonString, out string modifiedJsonString)
        {
            if (string.IsNullOrWhiteSpace(jsonString) ||
                jsonString == "data: [DONE]" || 
                jsonString == "\ndata: [DONE]")
            {
                modifiedJsonString = null;

                return false;
            }

            if (jsonString.StartsWith("data: "))
            {
                modifiedJsonString = jsonString.Remove(0, 6);
            }
            else if (jsonString.StartsWith("\ndata:"))
            {
                modifiedJsonString = jsonString.Remove(0, 7);
            }
            else
            {
                modifiedJsonString = jsonString;
            }

            return true;
        }

        protected override void ParseResponsePayload(IGptResponse response, JsonNode jNode)
        {
            var choices = jNode["choices"]
                .AsArray()
                .Select(choiceJson =>
                {
                    var choice = ComponentContainer.Container.Build<IGptResponseChoice>();

                    choice.Index = choiceJson["index"].GetValue<int>();
                    choice.FinishReason = choiceJson["finish_reason"]?.GetValue<string>();

                    var message = ComponentContainer.Container.Build<IGptMessage>();

                    // In stream response, the payload JSON key is "delta"
                    var messageJson = choiceJson["delta"];

                    message.Role = messageJson["role"]?.GetValue<string>();
                    message.Content = messageJson["content"]?.GetValue<string>();

                    choice.Payload = message;

                    return choice;
                })
                .ToArray();

            response.Choices = choices;

            // Stream response has no "usage" element.
        }
    }
}
