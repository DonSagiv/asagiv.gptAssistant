using asagiv.domain.core.DependencyInjection;
using asagiv.Domain.gptAssistant.Interfaces;
using System.Linq;

namespace asagiv.Domain.gptAssistant.Models
{
    [Export(typeof(IGptResponse), creationPolicy: CreationPolicy.Transient)]
    internal class GptResponse : IGptResponse
    {
        public string Id { get; set; }
        public string ObjectType { get; set; }
        public long Created { get; set; }
        public string Model { get; set; }
        public string SystemFingerprint { get; set; }
        public IGptResponseChoice[] Choices { get; set; }
        public IGptUsage Usage { get; set; }

        public string[] GetMessageLines()
        {
            return Choices
                .Select(x => x.Payload.Content)
                .ToArray();
        }
    }
}
