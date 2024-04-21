using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptRequestProcessor
    {
        Task ProcessGptRequestAsync(IGptRequestModel gptRequestModel);
    }
}
