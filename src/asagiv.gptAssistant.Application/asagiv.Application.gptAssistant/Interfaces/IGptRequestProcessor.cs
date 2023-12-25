using asagiv.Domain.gptAssistant.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace asagiv.Application.gptAssistant.Interfaces
{
    public interface IGptRequestProcessor
    {
        Task<IEnumerable<IGptResponse>> ProcessAsync(IGptRequest gptRequest, IRequestProcessorOptions options);
    }
}
