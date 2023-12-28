using asagiv.UI.gptAssistant.OpenSilver.Interfaces;
using ReactiveUI;
using System.Windows.Input;

namespace asagiv.UI.gptAssistant.OpenSilver.ViewModels
{
    public class SetupViewModel : ReactiveObject, ISetupViewModel
    {
        #region Fields
        private string _apiKey;
        private string _gptSystemParameter;
        #endregion

        #region Properties
        public string ApiKey
        {
            get => _apiKey;
            set => this.RaiseAndSetIfChanged(ref _apiKey, value);
        }
        public string GptSystemParameter
        {
            get => _gptSystemParameter;
            set => this.RaiseAndSetIfChanged(ref _gptSystemParameter, value);
        }
        #endregion

        #region Commands
        public ICommand OkCommand { get; }
        #endregion

        #region Constructor
        public SetupViewModel()
        {
            OkCommand = ReactiveCommand.Create(OnOkClicked);
        }
        #endregion

        #region Methods
        private void OnOkClicked()
        {

        }
        #endregion
    }
}