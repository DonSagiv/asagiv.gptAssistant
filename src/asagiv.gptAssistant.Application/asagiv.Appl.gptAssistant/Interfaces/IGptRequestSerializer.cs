using asagiv.Appl.gptAssistant.Models;

namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptRequestSerializer
    {
        string Serialize(GptRequest request);
    }
}
