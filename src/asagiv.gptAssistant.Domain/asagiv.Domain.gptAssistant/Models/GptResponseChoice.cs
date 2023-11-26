using asagiv.domain.core.DependencyInjection;
using asagiv.Domain.gptAssistant.Enumerators;
using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Domain.gptAssistant.Models
{
    [Export(typeof(IGptResponseChoice), creationPolicy: CreationPolicy.Transient)]
    internal class GptResponseChoice : IGptResponseChoice
    {
        public int Index { get; set; }
        public IGptMessage Payload { get; set; }
        public string FinishReason { get; set; }
    }
}
