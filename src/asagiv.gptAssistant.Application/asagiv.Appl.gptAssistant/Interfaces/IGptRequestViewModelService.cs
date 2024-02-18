using asagiv.Appl.gptAssistant.Models;

namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptRequestViewModelService
    {
        IGptRequestViewModel GetFromModel(GptRequest requestModelInput);
    }
}
