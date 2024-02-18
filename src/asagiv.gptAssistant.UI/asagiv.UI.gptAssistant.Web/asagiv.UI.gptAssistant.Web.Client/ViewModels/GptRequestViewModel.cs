using asagiv.Appl.gptAssistant.Interfaces;
using ReactiveUI;

namespace asagiv.UI.gptAssistant.Web.Client.ViewModels
{
    public class GptRequestViewModel : GptChatMessageViewModelBase, IGptRequestViewModel
    {
        #region Fields
        private IGptRequest _gptRequest;
        #endregion

        #region Properties
        public IGptRequest GptRequest 
        {
            get => _gptRequest;
            set => this.RaiseAndSetIfChanged(ref _gptRequest, value);
        }
        #endregion

        #region Constructor
        public GptRequestViewModel()
        {
            this.WhenAnyValue(x => x.GptRequest)
                .Subscribe(OnGptRequestChanged);
        }
        #endregion

        #region Method
        private void OnGptRequestChanged(IGptRequest gptRequestInput)
        {
            if(gptRequestInput == null)
            {
                DisplayString = null;

                return;
            }

            DisplayString = string.Join(",", gptRequestInput
                .Messages
                .Select(x => x.Content));
        }
        #endregion
    }
}
