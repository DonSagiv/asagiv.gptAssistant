using asagiv.domain.core.DependencyInjection;
using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Domain.gptAssistant.Models
{
    [Export(typeof(IGptMessage), creationPolicy: CreationPolicy.Transient)]
    public class GptMessage : IGptMessage
    {
        public string Role { get; set; }
        public string Content { get; set; }
    }
}
