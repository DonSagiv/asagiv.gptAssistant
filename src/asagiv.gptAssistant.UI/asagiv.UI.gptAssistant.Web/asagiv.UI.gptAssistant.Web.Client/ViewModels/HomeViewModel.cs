using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.gptAssistant.Interfaces;
using asagiv.Infrastructure.gptAssistant.Web.Models;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Input;

namespace asagiv.UI.gptAssistant.Web.Client.ViewModels
{
    public class HomeViewModel : ReactiveObject, IMainViewModel
    {
        #region Fields
        private readonly Subject<Unit> _stateChangedSubject = new();
        private readonly IGptRequestBuilderService _requestBuilderService;
        private readonly IGptRequestViewModelService _requestViewModelService;
        private readonly IGptRequestProcessorService _requestProcessorService;
        private readonly string _apiKey;

        private string _promptText;
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
        public HomeViewModel(IGptRequestBuilderService requestBuilderServiceInput,
            IGptRequestViewModelService requestViewModelServiceInput,
            IGptRequestProcessorService gptRequestProcessorServiceInput)
        {
            _apiKey ??= Environment.GetEnvironmentVariable("GPT_BEARER_KEY");

            _requestBuilderService = requestBuilderServiceInput;
            _requestViewModelService = requestViewModelServiceInput;
            _requestProcessorService = gptRequestProcessorServiceInput;

            PromptCollection = [];

            OnSubmitCommand = ReactiveCommand.CreateFromTask(OnSubmitAsync);
        }
        #endregion

        #region Methods
        private async Task OnSubmitAsync()
        {
            // Create and add the GPT Request.
            var requestBuilder = _requestBuilderService.GetBuilder();

            var request = requestBuilder.WithModel("gpt-4")
                .WithSystemMessage("You are a helpful AI assistant")
                .WithUserMessage(PromptText.ToString())
                .Build();

            var requestViewModel = _requestViewModelService.GetFromModel(request);

            PromptCollection.Add(requestViewModel);

            // Process the request.
            var requestProcesor = _requestProcessorService.GetNew();

            var options = new HttpRequestProcessorOptions
            {
                ApiKey = _apiKey,
            };

            /*
            requestProcesor.ProcessRequest(request, options);

            PromptText = string.Empty;

            var response = new GptResponseViewModel();
            PromptCollection.Add(response);

            response.WhenAnyValue(x => x.DisplayString)
                .Subscribe(DisplayStringChanged);
            */
        }

        private void OnResponseProcessed(IGptResponse response)
        {

        }

        private void DisplayStringChanged(string _)
        {
            _stateChangedSubject.OnNext(Unit.Default);
        }
        #endregion
    }
}
