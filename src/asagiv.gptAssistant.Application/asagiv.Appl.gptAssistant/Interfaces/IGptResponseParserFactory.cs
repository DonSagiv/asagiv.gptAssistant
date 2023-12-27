using asagiv.Domain.gptAssistant.Enumerators;

namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptResponseParserFactory
    {
        IGptResponseParser OfResponseType(ResponseDeliveryMethod deliveryMethod);
    }
}
