using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.Core.DependencyInjection;
using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Appl.gptAssistant.Services
{
    [Export(typeof(IGptRequestViewModelService))]
    internal class GptRequestViewModelService : IGptRequestViewModelService
    {
        public IGptRequestViewModel GetFromModel(IGptRequest requestModelInput)
        {
            var viewModel = ComponentContainer.Container.Build<IGptRequestViewModel>();
            
            viewModel.GptRequest = requestModelInput;

            return viewModel;
        }
    }
}
