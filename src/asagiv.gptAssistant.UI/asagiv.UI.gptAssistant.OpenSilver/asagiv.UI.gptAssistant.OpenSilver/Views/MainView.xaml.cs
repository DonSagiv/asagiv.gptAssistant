using asagiv.Domain.Core.DependencyInjection;
using asagiv.UI.gptAssistant.OpenSilver.Interfaces;
using asagiv.UI.OpenSilver.CustomControls;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace asagiv.UI.gptAssistant.OpenSilver.Views
{
    public partial class MainView : UserControl
    {
        #region Properties
        public IMainViewModel ViewModel => DataContext as IMainViewModel;
        #endregion

        #region Constructor
        public MainView()
        {
            this.InitializeComponent();

            PromptTextBox.KeyDown += PromptKeyDown;

            DataContext = ComponentContainer.Container.Build<IMainViewModel>();
        }
        #endregion

        #region Methods
        private void PromptKeyDown(object sender, KeyEventArgs e)
        {
            var textbox = sender as AsagivTextBox;

            if(e.Key == Key.Enter)
            {
                if(e.KeyModifiers == ModifierKeys.None) 
                {
                    ViewModel.Submit();
                }
                else
                {
                    textbox.Text += "\n";
                }
            }
        }
        #endregion
    }
}
