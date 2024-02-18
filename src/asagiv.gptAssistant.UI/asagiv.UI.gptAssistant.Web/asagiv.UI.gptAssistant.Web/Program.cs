using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.Core.DependencyInjection;
using asagiv.Infrastructure.gptAssistant.Web.Models;
using asagiv.UI.gptAssistant.Web.Client.ViewModels;
using asagiv.UI.gptAssistant.Web.Components;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

ComponentContainer.Container.Initialize(cb =>
{
    cb.AddSingleton<IMainViewModel, HomeViewModel>();
    
    cb.AddTransient<IGptRequestViewModel, GptRequestViewModel>();
    cb.AddTransient<IGptRequestAuthenticationService, GptAuthetnicationRetriever>();
});

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddBlazorise(o =>
    {
        o.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons()
    .AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(asagiv.UI.gptAssistant.Web.Client._Imports).Assembly);

app.Run();