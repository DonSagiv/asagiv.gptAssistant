namespace asagiv.Domain.gptAssistant.Interfaces;

public interface IGptRequestModel
{
    string RequestString { get; }
    string RequestProcessorName { get; }
}
