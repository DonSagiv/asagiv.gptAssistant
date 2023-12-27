using System;
using System.Threading.Tasks;

namespace asagiv.Domain.gptAssistant.Interfaces
{
    public interface IGptRequestProcessor : IDisposable
    {
        IObservable<IGptResponse> ResponseProcessedObservable { get; }

        void ProcessRequest(IGptRequest request, IRequestProcessorOptions options);
        Task AwaitCompletion();
    }
}
