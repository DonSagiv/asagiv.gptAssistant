using asagiv.UI.gptAssistant.OpenSilver.Interfaces;
using ReactiveUI;

namespace asagiv.UI.gptAssistant.OpenSilver.ViewModels
{
    public class MainViewModel : ReactiveObject, IMainViewModel
    {
        #region ViewModels
        public IChatViewModel ChatViewModel { get; }
        #endregion

        #region Constructor
        public MainViewModel(IChatViewModel chatViewModelInput)
        {
            ChatViewModel = chatViewModelInput;
        }
        #endregion
    }
}
