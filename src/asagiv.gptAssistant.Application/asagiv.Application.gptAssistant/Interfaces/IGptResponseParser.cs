using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Application.gptAssistant.Interfaces
{
    public interface IGptResponseParser
    {
        IGptResponse ParseResponse(string input);
    }
}
