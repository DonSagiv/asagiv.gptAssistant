using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.Core.DependencyInjection;
using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Infrastructure.gptAssistant.Models
{
    [Export(typeof(IGptRequestProcessor))]
    internal class OpenAiRequestProcessor : IGptRequestProcessor
    {
        public Task ProcessGptRequestAsync(IGptRequestModel gptRequestModel)
        {
            // todo: process request.
            return Task.CompletedTask;
        }
    }
}
