using asagiv.Appl.gptAssistant.Models;
using System.Threading.Tasks;

namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptResponseViewModel : IGptChatMessageViewModel 
    {
        Task AddResponse(GptResponse response);
    }
}
