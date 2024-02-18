namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptRequestViewModel : IGptChatMessageViewModel 
    {
        IGptRequest GptRequest { get; set; }
    }
}
