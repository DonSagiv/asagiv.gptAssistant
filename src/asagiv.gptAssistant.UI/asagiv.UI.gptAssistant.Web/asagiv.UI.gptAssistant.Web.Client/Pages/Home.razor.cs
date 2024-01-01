using asagiv.Domain.Core.DependencyInjection;
using asagiv.UI.gptAssistant.Interfaces;
using asagiv.UI.gptAssistant.Web.Client.ViewModels;

namespace asagiv.UI.gptAssistant.Web.Client.Pages
{
    public partial class Home
    {
        #region Properties
        public HomeViewModel ViewModel { get; }
        #endregion

        #region Constructor
        public Home()
        {
            ViewModel = ComponentContainer.Container.Build<IMainViewModel>() as HomeViewModel;
        }
        #endregion

        #region Methods
        public void OnSubmit()
        {
            ViewModel.OnSubmitCommand.Execute(null);
        }
        #endregion
    }
}
