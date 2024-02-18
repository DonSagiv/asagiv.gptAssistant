using System.Threading.Tasks;

namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptResponseViewModel : IGptChatMessageViewModel 
    {
        Task AddResponse(IGptResponse response);
    }
}
