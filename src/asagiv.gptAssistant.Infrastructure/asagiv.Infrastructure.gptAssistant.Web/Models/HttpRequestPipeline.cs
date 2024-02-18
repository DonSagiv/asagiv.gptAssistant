using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Appl.gptAssistant.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace asagiv.Infrastructure.gptAssistant.Web.Models
{
    internal class HttpRequestPipeline
    {
        #region Properties
        public IList<GptResponse> Responses { get; }
        public GptRequest GptRequest { get; set; }
        public HttpRequestProcessorOptions Options { get; set; }
        public HttpResponseMessage HttpResponse { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsComplete { get; set; }
        #endregion

        #region Constructor
        public HttpRequestPipeline()
        {
            Responses = new List<GptResponse>();
        }
        #endregion

        #region Methods
        public void AppendResponse(GptResponse response)
        {
            Responses.Add(response);
        }

        public IEnumerable<GptResponse> GetResponses()
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
