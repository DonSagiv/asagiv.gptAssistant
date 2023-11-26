using asagiv.Domain.gptAssistant.Interfaces;

namespace asagiv.Infrastructure.gptAssistant.Web
{
    public class HttpRequestProcessorOptions : IRequestProcessorOptions
    {
        public string ApiKey { get; set; }
    }
}
