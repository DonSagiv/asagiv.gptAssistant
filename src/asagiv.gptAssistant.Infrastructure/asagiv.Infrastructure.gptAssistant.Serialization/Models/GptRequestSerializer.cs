using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Appl.gptAssistant.Models;
using System.Text.Json;

namespace asagiv.Infrastructure.gptAssistant.Serialization.Models
{
    public class GptRequestSerializer : IGptRequestSerializer
    {
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions()
        {
            IgnoreReadOnlyProperties = true,
            IgnoreReadOnlyFields = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public string Serialize(GptRequest request)
        {
            return JsonSerializer.Serialize(request, options);
        }
    }
}
