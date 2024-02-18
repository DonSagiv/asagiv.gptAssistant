using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.Core.DependencyInjection;

namespace asagiv.Appl.gptAssistant.Services
{
    [Export(typeof(IGptRequestBuilderService), creationPolicy: CreationPolicy.Singleton)]
    internal class GptRequestBuilderService : IGptRequestBuilderService
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
