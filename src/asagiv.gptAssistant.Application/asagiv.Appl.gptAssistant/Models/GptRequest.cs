using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.gptAssistant.Enumerators;
using asagiv.Domain.gptAssistant.Interfaces;
using MediatR;
using System.Collections.Generic;

namespace asagiv.Appl.gptAssistant.Models
{
    public class GptRequest : IRequest<List<GptResponse>>
    {
        #region Properties
        public string Model { get; set; }
        public IGptMessage[] Messages { get; set; }
        public bool Stream { get; set; }
        #endregion

        #region Methods
        public ResponseDeliveryMethod GetRequestDeliveryMechanism()
        {
            return Stream ? ResponseDeliveryMethod.Stream : ResponseDeliveryMethod.Bulk;
        }
        #endregion
    }
}