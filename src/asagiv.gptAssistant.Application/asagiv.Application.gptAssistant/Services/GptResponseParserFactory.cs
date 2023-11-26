using asagiv.Application.gptAssistant.Interfaces;
using asagiv.domain.core.DependencyInjection;
using asagiv.Domain.gptAssistant.Enumerators;

namespace asagiv.Application.gptAssistant.Services
{
    [Export(typeof(IGptResponseParserFactory))]
    internal class GptResponseParserFactory : IGptResponseParserFactory
    {
        public IGptResponseParser OfResponseType(ResponseDeliveryMethod deliveryMethod)
        {
            return ComponentContainer.Container.Build<IGptResponseParser>(deliveryMethod);
        }
    }
}
