using asagiv.Domain.gptAssistant.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace asagiv.Infrastructure.gptAssistant.Web.Models
{
    internal class HttpRequestPipeline
    {
        #region Fields
        public IList<IGptResponse> _responses { get; }
        #endregion 

        #region Properties
        public IGptRequest GptRequest { get; set; }
        public HttpRequestProcessorOptions Options { get; set; }
        public HttpResponseMessage HttpResponse { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsComplete { get; set; }
        #endregion

        #region Constructor
        public HttpRequestPipeline()
        {
            _responses = new List<IGptResponse>();
        }
        #endregion

        #region Methods
        public void AppendResponse(IGptResponse response)
        {
            _responses.Add(response);
        }

        public IEnumerable<IGptResponse> GetResponses()
        {
            return _responses;
        }

        public bool HasError()
        {
            return !string.IsNullOrWhiteSpace(ErrorMessage);
        }
        #endregion
    }
}
