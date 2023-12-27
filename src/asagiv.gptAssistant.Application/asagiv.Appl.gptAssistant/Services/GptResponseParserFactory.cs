using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.Core.DependencyInjection;
using asagiv.Domain.gptAssistant.Enumerators;

namespace asagiv.Appl.gptAssistant.Services
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
