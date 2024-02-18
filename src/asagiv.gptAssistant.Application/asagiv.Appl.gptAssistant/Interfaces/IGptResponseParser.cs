using asagiv.Appl.gptAssistant.Models;

namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptResponseParser
    {
        GptResponse ParseResponse(string input);
    }
}
