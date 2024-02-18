using asagiv.Appl.gptAssistant.Interfaces;
using System;

namespace asagiv.Infrastructure.gptAssistant.Web.Models
{
    public class GptAuthetnicationRetriever : IGptRequestAuthenticationService
    {
        public string GetApiKey()
        {
            return string.Empty;
        }
    }
}
