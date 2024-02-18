using asagiv.Appl.gptAssistant.Interfaces;
using MediatR;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Input;
using Unit = System.Reactive.Unit;

namespace asagiv.UI.gptAssistant.Web.Client.ViewModels;

public class HomeViewModel : ReactiveObject, IMainViewModel
{
    #region Fields
    private readonly Subject<Unit> _stateChangedSubject = new();
    private readonly IGptRequestBuilderService _requestBuilderService;
    private readonly IGptRequestViewModelService _requestViewModelService;
    private readonly IMediator _mediator;

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
        IMediator medaitor)
    {
        _requestBuilderService = requestBuilderServiceInput;
        _requestViewModelService = requestViewModelServiceInput;
        _mediator = medaitor;

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
        var responses = await _mediator.Send(request);
    }
    #endregion
}
