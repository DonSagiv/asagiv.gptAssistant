namespace asagiv.Domain.gptAssistant.Interfaces
{
    public interface IGptUsage
    {
        int PromptTokens { get; set; }
        int CompletionTokens { get; set; }
        int TotalTokens { get; set; }
    }
}
