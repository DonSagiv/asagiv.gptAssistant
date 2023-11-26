using asagiv.Domain.gptAssistant.Interfaces;
using System.Collections.Generic;

namespace asagiv.Application.gptAssistant.Interfaces
{
    public interface IGptRequestProcessor
    {
        IAsyncEnumerable<IGptResponse> ProcessAsync(IGptRequest gptRequest, IRequestProcessorOptions options);
    }
}
