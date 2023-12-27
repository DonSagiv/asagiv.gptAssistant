using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.Core.DependencyInjection;
using asagiv.Domain.gptAssistant.Interfaces;
using asagiv.Infrastructure.gptAssistant.Web.Models;
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

            using(var httpRequestProcessor = ComponentContainer.Container.Build<IGptRequestProcessor>())
            {
                var builder = builderService.GetNew();

                var options = new HttpRequestProcessorOptions
                {
                    ApiKey = GetApiKey()
                };

                Console.Write("What am I?: ");

                var systemMessage = Console.ReadLine();

                Console.Write("What is your request?: ");

                var userMessage = Console.ReadLine();

                var request = builder.WithModel("gpt-4-1106-preview")
                    .WithSystemMessage(systemMessage)
                    .WithUserMessage(userMessage)
                    .UseStream()
                    .Build();

                httpRequestProcessor.ResponseProcessedObservable
                    .Subscribe(WriteResponse);

                httpRequestProcessor.ProcessRequest(request, options);

                await httpRequestProcessor.AwaitCompletion();
            }

            Console.WriteLine();

            Console.ReadKey();
        }

        private static void WriteResponse(IGptResponse response)
        {
            if (response?.Choices == null || response.Choices.Length == 0)
            {
                return;
            }

            foreach(var choice in response.Choices)
            {
                Console.Write(choice.Payload.Content);
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