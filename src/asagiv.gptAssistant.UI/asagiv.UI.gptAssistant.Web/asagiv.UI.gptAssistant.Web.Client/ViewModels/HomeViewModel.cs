using asagiv.Appl.gptAssistant.Interfaces;
using MediatR;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Input;
using Unit = System.Reactive.Unit;

namespace asagiv.UI.gptAssistant.Web.Client.ViewModels;

public class HomeViewModel(IGptRequestBuilderService requestBuilderServiceInput,
    IGptRequestViewModelService requestViewModelServiceInput,
    IMediator medaitor)
    : ReactiveObject, IMainViewModel
{
    #region Fields
    private readonly Subject<Unit> _stateChangedSubject = new();
    private readonly IGptRequestBuilderService _requestBuilderService = requestBuilderServiceInput;
    private readonly IGptRequestViewModelService _requestViewModelService = requestViewModelServiceInput;
    private readonly IMediator _mediator = medaitor;

    private string _promptText;
    #endregion

    #region Properties
    public ObservableCollection<IGptChatMessageViewModel> PromptCollection { get; } = [];
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
    #endregion

    #region Methods
    public async Task OnSubmitAsync()
    {
        // Create and add the GPT Request.
        var requestBuilder = _requestBuilderService.GetBuilder();

        var request = requestBuilder.WithModel("gpt-4")
            .WithSystemMessage("You are a helpful AI assistant")
            .WithUserMessage(PromptText.ToString())
            .Build();

        var requestViewModel = _requestViewModelService.GetFromModel(request);

        PromptCollection.Add(requestViewModel);

        try
        {
            // Process the request.
            var responses = await _mediator.Send(request);
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }
    #endregion
}
