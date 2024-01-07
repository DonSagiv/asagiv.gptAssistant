using System.Collections.Generic;
using System.Threading.Tasks;

namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptResponseViewModel : IGptChatMessageViewModel 
    {
        Task WriteResponseAsync(IEnumerable<string> responseEnumerable);
    }
}
