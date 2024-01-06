using asagiv.Appl.gptAssistant.Interfaces;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace asagiv.UI.gptAssistant.Web.Client.ViewModels
{
    public class HomeViewModel : ReactiveObject, IMainViewModel
    {
        #region Fields
        private string _promptText;
        #endregion

        #region Properties
        public ObservableCollection<IGptChatMessageViewModel> PromptCollection { get; }
        public string PromptText
        {
            get => _promptText;
            set => this.RaiseAndSetIfChanged(ref _promptText, value);
        }
        #endregion

        #region Commands
        public ICommand OnSubmitCommand { get; }
        #endregion

        #region Constructor
        public HomeViewModel()
        {
            PromptCollection = [];

            OnSubmitCommand = ReactiveCommand.Create(OnSubmit);
        }
        #endregion

        #region Methods
        private void OnSubmit()
        {
            var promptToAdd = new GptRequestViewModel();
            promptToAdd.SetRequest(PromptText.ToString());

            PromptCollection.Add(promptToAdd);

            PromptText = string.Empty;
        }
        #endregion
    }
}
