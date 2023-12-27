using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.Core.DependencyInjection;
using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Appl.gptAssistant.Services
{
    [Export(typeof(IGptRequestProcessorService))]
    internal class GptRequestProcesserService : IGptRequestProcessorService
    {
        public IGptRequestProcessor GetNew() 
        {
            return ComponentContainer.Container.Build<IGptRequestProcessor>();
        }
    }
}
