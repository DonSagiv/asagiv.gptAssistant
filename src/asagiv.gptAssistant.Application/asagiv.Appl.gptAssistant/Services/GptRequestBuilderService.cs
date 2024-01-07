using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.Core.DependencyInjection;
using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Appl.gptAssistant.Services
{
    [Export(typeof(IGptRequestBuilderService), creationPolicy: CreationPolicy.Singleton)]
    public class GptRequestBuilderService : IGptRequestBuilderService
    {
        public IGptRequestBuilder GetBuilder()
        {
            return ComponentContainer.Container.Build<IGptRequestBuilder>();
        }

        public IGptRequestViewModel GetViewModel()
        {
            return ComponentContainer.Container.Build<IGptRequestViewModel>();
        }
    }
}
