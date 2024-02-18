using System.Collections.ObjectModel;
using System.Text;
using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Appl.gptAssistant.Models;

namespace asagiv.UI.gptAssistant.Web.Client.ViewModels
{
    public class GptResponseViewModel : GptChatMessageViewModelBase, IGptResponseViewModel 
    {
        #region Fields
        private readonly StringBuilder _responseStringBuilder = new();
        #endregion

        #region Properties
        public Queue<GptResponse> Responses = [];
        #endregion

        #region Constructor

        #endregion

        #region Methods
        public async Task AddResponse(GptResponse gptResponse)
        {
            Responses.Enqueue(gptResponse);

            foreach(var item in gptResponse.Choices)
            {
                _responseStringBuilder.Append(item.Payload.Content);

                DisplayString = _responseStringBuilder.ToString();

                await Task.Delay(100);
            }
        }
        #endregion
    }
}
