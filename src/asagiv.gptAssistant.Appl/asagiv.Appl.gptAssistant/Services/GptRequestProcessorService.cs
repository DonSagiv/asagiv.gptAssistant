using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.Core.DependencyInjection;

namespace asagiv.Appl.gptAssistant.Services
{
    internal class GptRequestProcessorService : IGptRequestProcessorService
    {
        public IGptRequestProcessor GetProcessorFor(string requestProcessorName)
        {
            // todo: use request processor name to get appropriate processor.
            return ComponentContainer.Container.Build<IGptRequestProcessor>();
        }
    }
}
