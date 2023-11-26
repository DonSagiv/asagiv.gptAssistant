using asagiv.Domain.gptAssistant.Enumerators;

namespace asagiv.Application.gptAssistant.Interfaces
{
    public interface IGptResponseParserFactory
    {
        IGptResponseParser OfResponseType(ResponseDeliveryMethod deliveryMethod);
    }
}
