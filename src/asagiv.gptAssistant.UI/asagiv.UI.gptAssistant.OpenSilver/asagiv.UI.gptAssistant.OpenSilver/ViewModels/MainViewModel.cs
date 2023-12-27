using ReactiveUI;
using System.Collections.ObjectModel;
using System.Windows.Input;
using asagiv.UI.gptAssistant.OpenSilver.Interfaces;
using System.Threading.Tasks;
using asagiv.Appl.gptAssistant.Interfaces;
using System.Reactive.Subjects;
using System.Reactive;
using System.Reactive.Linq;
using System;
using asagiv.Infrastructure.gptAssistant.Web.Models;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace asagiv.UI.gptAssistant.OpenSilver.ViewModels
{
    public class MainViewModel : ReactiveObject, IMainViewModel
    {
        #region Fields
        private readonly Subject<Unit> _submitSubject = new Subject<Unit>();
        private readonly IGptRequestBuilderService _requestBuilderService;
        private readonly IGptRequestProcessorService _requestProcessorService;

        private string _requestString;
        #endregion

        #region Properties
        public ObservableCollection<IGptChatItemViewModel> ChatHistory { get; }
        public string RequestString
        {
            get => _requestString;
            set => this.RaiseAndSetIfChanged(ref _requestString, value);
        }
        #endregion

        #region Commands
        public ICommand SubmitCommand { get; }
        #endregion

        #region Constructor
        public MainViewModel(IGptRequestBuilderService requestBuilderServiceInput,
            IGptRequestProcessorService requestProcessorServiceInput)
        {
            ChatHistory = new ObservableCollection<IGptChatItemViewModel>();

            SubmitCommand = ReactiveCommand.CreateFromTask(OnSubmitAsync);

            _submitSubject
                .SelectMany(OnSubmitAsync)
                .Subscribe();

            _requestBuilderService = requestBuilderServiceInput;
            _requestProcessorService = requestProcessorServiceInput;
        }
        #endregion

        #region Methods
        public void Submit()
        {
            _submitSubject.OnNext(Unit.Default);
        }

        private async Task<Unit> OnSubmitAsync(Unit unit)
        {
            await OnSubmitAsync();

            return Unit.Default;
        }

        private async Task OnSubmitAsync()
        {
            var requestStringValue = (string)_requestString.Clone();

            var requestBuilder = _requestBuilderService.GetNew();

            var request = requestBuilder
                .WithModel("gpt-4-1106-preview")
                .WithSystemMessage("You are a helpful AI assistant.")
                .WithUserMessage(requestStringValue)
                .Build();

            var options = new HttpRequestProcessorOptions
            {
                ApiKey = GetApiKey()
            };

            var requestViewModel = new GptRequestViewModel(request)
            {
                DisplayValue = requestStringValue
            };

            ChatHistory.Add(requestViewModel);

            var response = new GptResponseViewModel();

            ChatHistory.Add(response);

            using(var requestProcessor = _requestProcessorService.GetNew())
            {
                response.SetRequestProcessor(requestProcessor);

                requestProcessor.ProcessRequest(request, options);

                await requestProcessor.AwaitCompletion();
            }

            RequestString = string.Empty;
        }

        private string GetApiKey()
        {
            // todo: make secret before committing.
            return "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";
        }
        #endregion
    }
}
