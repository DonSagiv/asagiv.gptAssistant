using asagiv.UI.gptAssistant.OpenSilver.Interfaces;
using ReactiveUI;

namespace asagiv.UI.gptAssistant.OpenSilver.ViewModels
{
    public class MainViewModel : ReactiveObject, IMainViewModel
    {
        #region ViewModels
        public IChatViewModel ChatViewModel { get; }
        public ISetupViewModel SetupViewModel { get; }
        #endregion

        #region Constructor
        public MainViewModel(IChatViewModel chatViewModelInput,
            ISetupViewModel setupViewModelInput)
        {
            ChatViewModel = chatViewModelInput;
            SetupViewModel = setupViewModelInput;
        }
        #endregion
    }
}
