using asagiv.Domain.gptAssistant.Interfaces;
using asagiv.UI.gptAssistant.OpenSilver.Interfaces;
using ReactiveUI;

namespace asagiv.UI.gptAssistant.OpenSilver.ViewModels
{
    public class GptRequestViewModel : ReactiveObject, IGptChatItemViewModel
    {
        #region Fields
        private IGptRequest _gptRequest;

        private string _displayValue;
        #endregion

        #region Properties
        public string DisplayValue
        {
            get => _displayValue;
            set => this.RaiseAndSetIfChanged(ref _displayValue, value);
        }
        #endregion

        #region Constructor
        public GptRequestViewModel(IGptRequest gptRequest)
        {
            _gptRequest = gptRequest;
        }
        #endregion
    }
}
