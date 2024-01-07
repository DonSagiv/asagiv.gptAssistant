using asagiv.Appl.gptAssistant.Interfaces;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Input;

namespace asagiv.UI.gptAssistant.Web.Client.ViewModels
{
    public class HomeViewModel : ReactiveObject, IMainViewModel
    {
        #region Fields
        private string _promptText;
        private readonly Subject<Unit> _stateChangedSubject = new();
        #endregion

        #region Properties
        public ObservableCollection<IGptChatMessageViewModel> PromptCollection { get; }
        public string PromptText
        {
            get => _promptText;
            set => this.RaiseAndSetIfChanged(ref _promptText, value);
        }
        public IObservable<Unit> StateChangedObservable => _stateChangedSubject.AsObservable();
        #endregion

        #region Commands
        public ICommand OnSubmitCommand { get; }
        #endregion

        #region Constructor
        public HomeViewModel()
        {
            PromptCollection = [];

            OnSubmitCommand = ReactiveCommand.CreateFromTask(OnSubmitAsync);
        }
        #endregion

        #region Methods
        private async Task OnSubmitAsync()
        {
            var promptToAdd = new GptRequestViewModel();
            PromptCollection.Add(promptToAdd);

            promptToAdd.SetRequest(PromptText.ToString());

            PromptText = string.Empty;

            var response = new GptResponseViewModel();
            PromptCollection.Add(response);

            response.WhenAnyValue(x => x.DisplayString)
                .Subscribe(DisplayStringChanged);

            await response.WriteResponseAsync(["Hello, ", "and ", "welcome ", "to ", "my ", "world."]);
        }

        private void DisplayStringChanged(string _)
        {
            _stateChangedSubject.OnNext(Unit.Default);
        }
        #endregion
    }
}
