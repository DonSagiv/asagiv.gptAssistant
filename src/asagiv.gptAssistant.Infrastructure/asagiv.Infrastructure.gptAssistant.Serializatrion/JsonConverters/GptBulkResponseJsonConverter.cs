using asagiv.Application.gptAssistant.Interfaces;
using asagiv.domain.core.DependencyInjection;
using asagiv.Domain.gptAssistant.Enumerators;
using asagiv.Domain.gptAssistant.Interfaces;
using System.Linq;
using System.Text.Json.Nodes;

namespace asagiv.Infrastructure.gptAssistant.Serializatrion.JsonConverters
{
    [Export(typeof(IGptResponseParser), contractKey: ResponseDeliveryMethod.Bulk, creationPolicy: CreationPolicy.Singleton)]
    internal sealed class GptBulkResponseJsonConverter : GptResponseJsonConverterBase
    {
        #region Methods
        protected override bool IsValidJsonString(string jsonString, out string modifiedJsonString)
        {
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                modifiedJsonString = null;

                return false;
            }

            modifiedJsonString = jsonString;

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

                    // In bulk response, the payload JSON key is "message"
                    var messageJson = choiceJson["message"];

                    message.Role = messageJson["role"]?.GetValue<string>();
                    message.Content = messageJson["content"]?.GetValue<string>();

                    choice.Payload = message;

                    return choice;
                })
                .ToArray();

            response.Choices = choices;

            var usageJson = jNode["usage"];

            if (usageJson != null)
            {
                var usage = ComponentContainer.Container.Build<IGptUsage>();

                usage.PromptTokens = usageJson["prompt_tokens"].GetValue<int>();
                usage.CompletionTokens = usageJson["completion_tokens"].GetValue<int>();
                usage.TotalTokens = usageJson["total_tokens"].GetValue<int>();

                response.Usage = usage;
            }
        }
        #endregion
    }
}
