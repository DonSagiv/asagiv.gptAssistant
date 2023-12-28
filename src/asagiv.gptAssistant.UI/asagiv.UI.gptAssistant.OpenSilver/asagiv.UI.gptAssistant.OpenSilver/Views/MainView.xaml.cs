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
            InitializeComponent();

            DataContext = ComponentContainer.Container.Build<IMainViewModel>();
        }
        #endregion
    }
}
