namespace asagiv.Domain.gptAssistant.Interfaces
{
    public interface IGptResponseChoice
    {
        int Index { get; set; }
        IGptMessage Payload { get; set; }
        string FinishReason { get; set; }
    }
}
