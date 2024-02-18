using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptResponse
    {
        string Id { get; set; }
        string ObjectType { get; set; }
        long Created { get; set; }
        string Model { get; set; }
        string SystemFingerprint { get; set; }
        IGptResponseChoice[] Choices { get; set; }
        IGptUsage Usage { get; set; }

        string[] GetMessageLines();
    }
}
