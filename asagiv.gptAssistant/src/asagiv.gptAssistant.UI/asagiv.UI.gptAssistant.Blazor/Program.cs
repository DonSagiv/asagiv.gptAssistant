using asagiv.Appl.Core.Interfaces;
using asagiv.Domain.Core.DependencyInjection;
using asagiv.Domain.Core.Extensions;
using asagiv.Infrastructure.logging.serilog.Models;
using asagiv.UI.gptAssistant.Blazor.Components;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(cb =>
{
    ComponentContainer.Container.AddAttributedTypes(cb);
    cb.AddMediatR();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
