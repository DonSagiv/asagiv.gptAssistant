using asagiv.domain.core.DependencyInjection;
using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Domain.gptAssistant.Models
{
    [Export(typeof(IGptUsage), creationPolicy: CreationPolicy.Transient)]
    internal class GptUsage : IGptUsage
    {
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
        public int TotalTokens { get; set; }
    }
}
