using asagiv.Domain.Core.DependencyInjection;
using asagiv.Domain.gptAssistant.Interfaces;
using asagiv.Infrastructure.gptAssistant.Web.Models;
using asagiv.UI.gptAssistant.OpenSilver.Interfaces;
using asagiv.UI.gptAssistant.OpenSilver.ViewModels;
using System.Windows;

namespace asagiv.UI.gptAssistant.OpenSilver
{
    public sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();

            ComponentContainer.Container.Initialize(cb =>
            {
                cb.AddSingleton<IMainViewModel, MainViewModel>();
                cb.AddSingleton<IChatViewModel, ChatViewModel>();
                cb.AddSingleton<ISetupViewModel, SetupViewModel>();

                cb.AddTransient<IGptRequestProcessor, HttpGptRequestProcessor>();
            });

            var mainPage = new MainPage();

            Window.Current.Content = mainPage;
        }
    }
}
