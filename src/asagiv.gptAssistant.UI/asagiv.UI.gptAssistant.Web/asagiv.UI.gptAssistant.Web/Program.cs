using asagiv.Appl.gptAssistant.Interfaces;
using asagiv.Domain.Core.DependencyInjection;
using asagiv.UI.gptAssistant.Web.Client.ViewModels;
using asagiv.UI.gptAssistant.Web.Components;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

namespace asagiv.UI.gptAssistant.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ComponentContainer.Container.Initialize(cb =>
            {
                cb.AddSingleton<IMainViewModel, HomeViewModel>();
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
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
}
