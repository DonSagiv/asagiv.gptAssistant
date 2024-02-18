using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.Core.DependencyInjection;
using asagiv.UI.gptAssistant.Web.Client.ViewModels;
using Microsoft.AspNetCore.Components.Web;

namespace asagiv.UI.gptAssistant.Web.Client.Pages
{
    public partial class Home
    {
        #region Fields
        private bool _preventDefault;
        #endregion

        #region Constructor
        public Home()
        {
            ViewModel = ComponentContainer.Container.Build<IMainViewModel>() as HomeViewModel;

            ViewModel.StateChangedObservable
                .Subscribe(x => StateHasChanged());
        }
        #endregion

        #region Methods
        private async Task OnSubmitAsync()
        {
            await ViewModel.OnSubmitAsync();
        }

        private Task OnKeyDownAsync(KeyboardEventArgs e)
        {
            if (e.Key == "Enter" &&
                e.ShiftKey == false &&
                e.CtrlKey == false &&
                e.AltKey == false)
            {
                _preventDefault = true;

                return OnSubmitAsync();
            }

            return Task.CompletedTask;
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (_preventDefault)
            {
                _preventDefault = false;
            }
        }
        #endregion
    }
}
