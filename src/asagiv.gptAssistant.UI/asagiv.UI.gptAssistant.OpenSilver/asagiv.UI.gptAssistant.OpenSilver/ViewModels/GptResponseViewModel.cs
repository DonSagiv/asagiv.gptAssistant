using System;
using System.Reactive.Linq;
using asagiv.Domain.gptAssistant.Interfaces;
using asagiv.UI.gptAssistant.OpenSilver.Interfaces;
using ReactiveUI;

namespace asagiv.UI.gptAssistant.OpenSilver.ViewModels
{
    internal class GptResponseViewModel : ReactiveObject, IGptChatItemViewModel
    {
        #region Fields
        private string _displayValue;
        #endregion

        #region Properties
        public string DisplayValue 
        {
            get => _displayValue;
            set => this.RaiseAndSetIfChanged(ref _displayValue, value);
        }
        #endregion

        #region Methods
        public void SetRequestProcessor(IGptRequestProcessor requestProcessor)
        {
            requestProcessor.ResponseProcessedObservable
                .Subscribe(AppendResponse);
        }

        private void AppendResponse(IGptResponse responseInput)
        {
            if(responseInput?.Choices == null && responseInput.Choices.Length == 0)
            {
                return;
            }

            foreach(var response in responseInput.Choices)
            {
                DisplayValue += response.Payload.Content;
            }
        }
        #endregion
    }
}
