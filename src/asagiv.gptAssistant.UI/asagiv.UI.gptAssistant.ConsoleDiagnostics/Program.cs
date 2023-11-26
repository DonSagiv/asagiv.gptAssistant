using asagiv.Application.gptAssistant.Interfaces;
using asagiv.domain.core.DependencyInjection;
using asagiv.Infrastructure.gptAssistant.Web;
using Microsoft.Extensions.Configuration;

namespace asagiv.UI.gptAssistant.ConsoleDiagnostics
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Request
            ComponentContainer.Container.Initialize();

            var builderService = ComponentContainer.Container.Build<IGptRequestBuilderService>();
            var requestProcessor = ComponentContainer.Container.Build<IGptRequestProcessor>();

            var builder = builderService.GetNew();

            var options = new HttpRequestProcessorOptions
            {
                ApiKey = GetApiKey()
            };

            var request = builder.WithModel("gpt-4-1106-preview")
                .WithSystemMessage("You are a C# tester that writes brief responses.")
                .WithUserMessage("Write 3 seldom used words in the English language.")
                .UseStream()
                .Build();

            var responseEnumerable = requestProcessor
                .ProcessAsync(request, options)
                .Where(x => x != null);

            await foreach (var item in responseEnumerable)
            {
                foreach (var choice in item.Choices)
                {
                    Console.Write(choice.Payload.Content);
                }
            }
        }

        private static string GetApiKey()
        {
            var secret = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            var provider = secret.Providers.First();

            provider.TryGet("Bearer", out var apiKey);

            return apiKey;
        }
    }
}