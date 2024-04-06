using asagiv.Domain.Core.DependencyInjection;
using asagiv.Domain.Core.Extensions;
using asagiv.UI.gptAssistant.Blazor.Components;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
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
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
