using System.Windows.Controls;
using Tournament_Management_Software.ViewModels;
using Tournament_Management_Software.ViewModels.Home;

namespace Tournament_Management_Software.View
{
    /// <summary>
    /// Interaction logic for DefaultView.xaml
    /// </summary>
    public partial class DefaultView : UserControl
    {
        public DefaultView()
        {
            InitializeComponent();
            DataContext = new DefaultViewModel();
        }
    }
}
