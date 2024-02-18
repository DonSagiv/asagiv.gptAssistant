using asagiv.Appl.gptAssistant.Models;

namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptRequestViewModel : IGptChatMessageViewModel 
    {
        GptRequest GptRequest { get; set; }
    }
}
