using asagiv.Domain.Core.DependencyInjection;
using System.Windows;

namespace asagiv.UI.gptAssistant.OpenSilver
{
    public sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();

            ComponentContainer.Container.Initialize();

            var mainPage = new MainPage();
            Window.Current.Content = mainPage;
        }
    }
}
