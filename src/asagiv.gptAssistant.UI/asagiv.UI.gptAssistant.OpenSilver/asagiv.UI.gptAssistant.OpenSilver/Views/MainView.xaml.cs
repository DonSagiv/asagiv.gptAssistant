using asagiv.UI.gptAssistant.OpenSilver.ViewModels;
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
        private void KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                ViewModel.OnSubmit();
            }
        }
        #endregion
    }
}
