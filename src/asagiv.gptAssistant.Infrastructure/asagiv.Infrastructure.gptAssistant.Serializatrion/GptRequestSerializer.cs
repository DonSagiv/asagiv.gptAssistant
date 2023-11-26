using asagiv.Application.gptAssistant.Interfaces;
using asagiv.domain.core.DependencyInjection;
using asagiv.Domain.gptAssistant.Interfaces;
using System.Text.Json;

namespace asagiv.Infrastructure.gptAssistant.Serializatrion
{
    [Export(typeof(IGptRequestSerializer), creationPolicy: CreationPolicy.Singleton)]
    internal class GptRequestSerializer : IGptRequestSerializer
    {
        private static readonly JsonSerializerOptions options = new()
        {
            IgnoreReadOnlyProperties = true,
            IgnoreReadOnlyFields = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public string Serialize(IGptRequest request)
        {
            return JsonSerializer.Serialize(request, options);
        }
    }
}
