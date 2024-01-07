using System.Text;
using asagiv.Appl.gptAssistant.Interfaces;

namespace asagiv.UI.gptAssistant.Web.Client.ViewModels
{
    public class GptResponseViewModel : GptChatMessageViewModelBase, IGptResponseViewModel 
    {
        #region Fields
        private readonly StringBuilder _responseStringBuilder = new();
        #endregion

        #region Methods
        public async Task WriteResponseAsync(IEnumerable<string> responseEnumerable)
        {
            _responseStringBuilder.Clear();

            foreach(var response in responseEnumerable)
            {
                _responseStringBuilder.Append(response);

                DisplayString = _responseStringBuilder.ToString();

                await Task.Delay(100);
            }
        }
        #endregion
    }
}
