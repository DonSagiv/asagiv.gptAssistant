using asagiv.Domain.gptAssistant.Interfaces;
using System;
using System.Threading.Tasks;

namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptRequestProcessor : IDisposable
    {
        IObservable<IGptResponse> ResponseProcessedObservable { get; }

        void ProcessRequest(IGptRequest request, IRequestProcessorOptions options);
        Task AwaitCompletion();
    }
}
