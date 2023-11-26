using asagiv.Application.gptAssistant.Interfaces;
using asagiv.domain.core.DependencyInjection;
using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Application.gptAssistant.Services
{
    [Export(typeof(IGptRequestBuilderService), creationPolicy: CreationPolicy.Singleton)]
    public class GptRequestBuilderService : IGptRequestBuilderService
    {
        public IGptRequestBuilder GetNew()
        {
            return ComponentContainer.Container.Build<IGptRequestBuilder>();
        }
    }
}
