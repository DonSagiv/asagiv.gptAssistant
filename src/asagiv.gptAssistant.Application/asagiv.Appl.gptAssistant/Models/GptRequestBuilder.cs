using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.Core.DependencyInjection;
using asagiv.Domain.gptAssistant.Interfaces;
using asagiv.Domain.gptAssistant.Models;
using System.Collections.Generic;
using System.Linq;

namespace asagiv.Appl.gptAssistant.Models
{
    [Export(typeof(IGptRequestBuilder), creationPolicy: CreationPolicy.Transient)]
    internal class GptRequestBuilder : IGptRequestBuilder
    {
        #region Fields
        private readonly IList<IGptMessage> _messages;
        private string _model;
        private bool _useStream;
        #endregion

        #region Constructor
        public GptRequestBuilder()
        {
            _messages = new List<IGptMessage>();
        }
        #endregion

        #region Methods
        public IGptRequestBuilder WithModel(string model)
        {
            _model = model;

            return this;
        }

        public IGptRequestBuilder WithSystemMessage(string systemContent)
        {
            var systemMessage = new GptMessage
            {
                Role = "system",
                Content = systemContent
            };

            _messages.Add(systemMessage);

            return this;
        }

        public IGptRequestBuilder WithUserMessage(string userContent)
        {
            var userMessage = new GptMessage
            {
                Role = "user",
                Content = userContent,
            };

            _messages.Add(userMessage);

            return this;
        }

        public IGptRequestBuilder UseStream()
        {
            _useStream = true;

            return this;
        }

        public GptRequest Build()
        {
            var request = new GptRequest()
            {
                Model = _model,
                Messages = _messages.ToArray(),
                Stream = _useStream,
            };

            return request;
        }
        #endregion
    }
}
