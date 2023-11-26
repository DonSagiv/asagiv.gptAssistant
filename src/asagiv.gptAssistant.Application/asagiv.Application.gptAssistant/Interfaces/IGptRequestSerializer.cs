using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Application.gptAssistant.Interfaces
{
    public interface IGptRequestSerializer
    {
        string Serialize(IGptRequest request);
    }
}
