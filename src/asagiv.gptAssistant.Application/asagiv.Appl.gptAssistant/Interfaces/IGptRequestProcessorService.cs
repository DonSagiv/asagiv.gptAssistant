using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptRequestProcessorService
    {
        IGptRequestProcessor GetNew();
    }
}
