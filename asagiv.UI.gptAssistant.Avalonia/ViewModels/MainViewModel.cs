using ReactiveUI;

namespace asagiv.UI.gptAssistant.Avalonia.ViewModels;

public class MainViewModel : ReactiveObject
{
    #region Fields
    private string _promptString;
    #endregion

    #region Properties
    public string PromptString 
    {
        get => _promptString; 
        set => this.RaiseAndSetIfChanged(ref _promptString, value); 
    }
    #endregion
}
