using ReactiveUI;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace asagiv.UI.gptAssistant.OpenSilver.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        #region Fields
        private string _textBoxString;
        #endregion

        #region Properties
        public ObservableCollection<string> ChatHistory { get; }
        public string TextBoxString
        {
            get => _textBoxString;
            set => this.RaiseAndSetIfChanged(ref _textBoxString, value);
        }
        #endregion

        #region Commands
        public ICommand SubmitCommand { get; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            ChatHistory = new ObservableCollection<string>();

            SubmitCommand = ReactiveCommand.Create(OnSubmit);
        }
        #endregion

        #region Methods
        public void OnSubmit()
        {
            ChatHistory.Add((string)TextBoxString?.Clone());

            TextBoxString = string.Empty;
        }
        #endregion
    }
}
