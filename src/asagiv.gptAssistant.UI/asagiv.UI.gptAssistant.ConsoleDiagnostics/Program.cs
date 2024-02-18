using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.Core.DependencyInjection;
using asagiv.Infrastructure.gptAssistant.Serialization.Models;
using asagiv.Infrastructure.gptAssistant.Web.Models;
using MediatR;

namespace asagiv.UI.gptAssistant.ConsoleDiagnostics
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ComponentContainer.Container.Initialize(cb =>
            {
                cb.AddSingleton<IGptRequestSerializer, GptRequestSerializer>();

                cb.AddTransient<IGptRequestAuthenticationService, GptAuthetnicationRetriever>();
            });

            var medaitor = ComponentContainer.Container.Build<IMediator>();
            var requestBuilderService = ComponentContainer.Container.Build<IGptRequestBuilderService>();

            var requestBuilder = requestBuilderService.GetBuilder();

            var request = requestBuilder.WithModel("gpt-4")
                .WithSystemMessage("You are a helpful AI assistant")
                .WithUserMessage("Write 3 random words in the English language")
                .Build();

            var responses = await medaitor.Send(request);

            Console.WriteLine(responses);
        }
    }
}