using asagiv.Domain.gptAssistant.Enumerators;

namespace asagiv.Domain.gptAssistant.Interfaces
{
    public interface IGptRequest
    {
        string Model { get; set; }
        IGptMessage[] Messages { get; set; }
        bool Stream { get; set; }

        ResponseDeliveryMethod GetRequestDeliveryMechanism();
    }
}
