using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.Core.DependencyInjection;
using System.Text.Json;

namespace asagiv.Infrastructure.gptAssistant.Serialization.Models
{
    [Export(typeof(IGptRequestSerializer), creationPolicy: CreationPolicy.Singleton)]
    internal class GptRequestSerializer : IGptRequestSerializer
    {
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions()
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
