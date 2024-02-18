using asagiv.Domain.gptAssistant.Enumerators;
using asagiv.Domain.gptAssistant.Interfaces;
using MediatR;
using System.Collections.Generic;

namespace asagiv.Appl.gptAssistant.Interfaces
{
    public interface IGptRequest : IRequest<IEnumerable<IGptResponse>>
    {
        string Model { get; set; }
        IGptMessage[] Messages { get; set; }
        bool Stream { get; set; }

        ResponseDeliveryMethod GetRequestDeliveryMechanism();
    }
}
