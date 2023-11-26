using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Application.gptAssistant.Interfaces
{
    public interface IGptRequestBuilderService
    {
        IGptRequestBuilder GetNew();
    }
}
