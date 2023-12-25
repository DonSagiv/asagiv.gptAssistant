using asagiv.UI.gptAssistant.OpenSilver.ViewModels;
using asagiv.UI.OpenSilver.CustomControls;
using System.Windows.Controls;
using System.Windows.Input;

namespace asagiv.UI.gptAssistant.OpenSilver.Views
{
    public partial class MainView : UserControl
    {
        #region Properties
        public MainViewModel ViewModel => DataContext as MainViewModel;
        #endregion

        #region Constructor
        public MainView()
        {
            this.InitializeComponent();

            DataContext = new MainViewModel();
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
                    ViewModel.OnSubmit();
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
