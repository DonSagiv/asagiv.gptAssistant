using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptResponseParser
    {
        IGptResponse ParseResponse(string input);
    }
}
