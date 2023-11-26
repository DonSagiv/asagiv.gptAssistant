namespace asagiv.Domain.gptAssistant.Interfaces
{
    public interface IGptMessage
    {
        string Role { get; set; }
        string Content { get; set; }
    }
}
