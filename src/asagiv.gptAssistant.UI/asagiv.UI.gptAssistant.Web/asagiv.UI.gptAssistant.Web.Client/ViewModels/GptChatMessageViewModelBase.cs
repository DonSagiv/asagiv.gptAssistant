using asagiv.UI.gptAssistant.Interfaces;
using ReactiveUI;

namespace asagiv.UI.gptAssistant.Web.Client.ViewModels
{
    public abstract class GptChatMessageViewModelBase : ReactiveObject, IGptChatMessageViewModel
    {
        #region Fields
        private string _displayString;
        #endregion

        #region Properties
        public string DisplayString
        {
            get => _displayString;
            protected set => this.RaiseAndSetIfChanged(ref _displayString, value);
        }
        #endregion
    }
}
