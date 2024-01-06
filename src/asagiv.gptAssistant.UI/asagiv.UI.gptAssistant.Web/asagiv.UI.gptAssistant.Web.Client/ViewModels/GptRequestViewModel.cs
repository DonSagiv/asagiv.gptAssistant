using asagiv.Appl.gptAssistant.Interfaces;

namespace asagiv.UI.gptAssistant.Web.Client.ViewModels
{
    public class GptRequestViewModel : GptChatMessageViewModelBase, IGptRequestViewModel
    {
        public void SetRequest(string requestString)
        {
            DisplayString = requestString;
        }
    }
}
