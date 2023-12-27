using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Infrastructure.gptAssistant.Web.Models
{
    public class HttpRequestProcessorOptions : IRequestProcessorOptions
    {
        public string ApiKey { get; set; }
    }
}
