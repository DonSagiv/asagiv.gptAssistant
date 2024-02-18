using asagiv.Appl.gptAssistant.Interfaces;
using System.Collections.Generic;
using System.Net.Http;

namespace asagiv.Infrastructure.gptAssistant.Web.Models
{
    internal class HttpRequestPipeline
    {
        #region Properties
        public IList<IGptResponse> Responses { get; }
        public IGptRequest GptRequest { get; set; }
        public HttpRequestProcessorOptions Options { get; set; }
        public HttpResponseMessage HttpResponse { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsComplete { get; set; }
        #endregion

        #region Constructor
        public HttpRequestPipeline()
        {
            Responses = new List<IGptResponse>();
        }
        #endregion

        #region Methods
        public void AppendResponse(IGptResponse response)
        {
            Responses.Add(response);
        }

        public IEnumerable<IGptResponse> GetResponses()
        {
            return Responses;
        }

        public bool HasError()
        {
            return !string.IsNullOrWhiteSpace(ErrorMessage);
        }
        #endregion
    }
}
