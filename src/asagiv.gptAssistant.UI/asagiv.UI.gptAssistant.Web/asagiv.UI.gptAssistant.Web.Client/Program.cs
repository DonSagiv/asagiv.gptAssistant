using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using asagiv.Domain.Core.DependencyInjection;
using asagiv.UI.gptAssistant.Web.Client.ViewModels;
using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Infrastructure.gptAssistant.Web.Models;
using asagiv.Domain.gptAssistant.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

ComponentContainer.Container.Initialize(cb =>
{
    cb.AddSingleton<IMainViewModel, HomeViewModel>();

    cb.AddTransient<IGptRequestViewModel, GptRequestViewModel>();
    cb.AddTransient<IGptRequestProcessor, HttpGptRequestProcessor>();
});

builder.Services
    .AddBlazorise(o =>
    {
        o.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

await builder.Build().RunAsync();
