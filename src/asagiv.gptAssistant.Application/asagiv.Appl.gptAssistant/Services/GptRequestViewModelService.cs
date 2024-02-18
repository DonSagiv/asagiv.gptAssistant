using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Appl.gptAssistant.Models;
using asagiv.Domain.Core.DependencyInjection;

namespace asagiv.Appl.gptAssistant.Services
{
    [Export(typeof(IGptRequestViewModelService))]
    internal class GptRequestViewModelService : IGptRequestViewModelService
    {
        public IGptRequestViewModel GetFromModel(GptRequest requestModelInput)
        {
            var viewModel = ComponentContainer.Container.Build<IGptRequestViewModel>();
            
            viewModel.GptRequest = requestModelInput;

            return viewModel;
        }
    }
}
