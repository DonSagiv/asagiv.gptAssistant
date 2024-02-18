using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.Core.DependencyInjection;
using System.Text.Json.Nodes;

namespace asagiv.Infrastructure.gptAssistant.Serialization.JsonConverters
{
    internal abstract class GptResponseJsonConverterBase : IGptResponseParser
    {
        #region Methods
        public IGptResponse ParseResponse(string jsonString)
        {
            if (!IsValidJsonString(jsonString, out var modifiedJsonString))
            {
                return null;
            }

            var jNode = JsonNode.Parse(modifiedJsonString);
            var response = ComponentContainer.Container.Build<IGptResponse>();

            ParseResponseMetadata(response, jNode);
            ParseResponsePayload(response, jNode);

            return response;
        }
        #endregion

        #region Virtual Methods
        protected virtual void ParseResponseMetadata(IGptResponse response, JsonNode jNode)
        {
            response.Id = jNode["id"]?.GetValue<string>();
            response.ObjectType = jNode["object"]?.GetValue<string>();
            response.Created = jNode["created"].GetValue<long>();
            response.Model = jNode["model"]?.GetValue<string>();
            response.SystemFingerprint = jNode["system_fingerprint"]?.GetValue<string>();
        }

        protected abstract bool IsValidJsonString(string jsonString, out string modifiedJsonString);
        protected abstract void ParseResponsePayload(IGptResponse response, JsonNode jNode);
        #endregion
    }
}
