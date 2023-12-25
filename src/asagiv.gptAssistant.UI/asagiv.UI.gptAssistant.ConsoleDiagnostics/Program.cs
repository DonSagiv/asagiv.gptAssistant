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

            Console.Write("What am I?: ");

            var systemMessage = Console.ReadLine();

            while (true)
            {
                Console.Write("What is your request?: ");

                var userMessage = Console.ReadLine();

                if(userMessage == "quit" || userMessage == "exit")
                {
                    break;
                }

                var request = builder.WithModel("gpt-4-1106-preview")
                    .WithSystemMessage(systemMessage)
                    .WithUserMessage(userMessage)
                    .UseStream()
                    .Build();

                var responseEnumerable = await requestProcessor
                    .ProcessAsync(request, options);

                var responseList = responseEnumerable
                    .Where(x => x != null)
                    .ToArray();

                Console.WriteLine();

                foreach (var item in responseList)
                {
                    foreach (var choice in item.Choices)
                    {
                        Thread.Sleep(100);

                        Console.Write(choice.Payload.Content);
                    }
                }

                Console.WriteLine();
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