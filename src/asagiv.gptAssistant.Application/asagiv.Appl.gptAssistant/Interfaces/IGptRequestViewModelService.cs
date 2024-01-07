using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptRequestViewModelService
    {
        IGptRequestViewModel GetFromModel(IGptRequest requestModelInput);
    }
}
