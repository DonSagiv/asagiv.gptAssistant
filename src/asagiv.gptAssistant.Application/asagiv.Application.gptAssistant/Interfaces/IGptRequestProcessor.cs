using asagiv.Domain.gptAssistant.Interfaces;
using System;
using System.Threading.Tasks;

namespace asagiv.Application.gptAssistant.Interfaces
{
    public interface IGptRequestProcessor : IDisposable
    {
        IObservable<IGptResponse> ResponseProcessedObservable { get; }

        void ProcessRequest(IGptRequest request, IRequestProcessorOptions options);
        Task AwaitCompletion();
    }
}
