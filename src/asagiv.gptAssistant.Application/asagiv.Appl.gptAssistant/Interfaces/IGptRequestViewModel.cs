namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptRequestViewModel : IGptChatMessageViewModel 
    {
        void SetRequest(string requestString);
    }
}
