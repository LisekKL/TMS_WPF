using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Tournament_Management_Software.Helpers.Messages;
using Tournament_Management_Software.ViewModels.AgeClasses.WeightClasses;

namespace Tournament_Management_Software.View.AgeClasses.WeightClasses
{
    /// <summary>
    /// Interaction logic for ShowAllWeightClassesView.xaml
    /// </summary>
    public partial class ShowAllWeightClassesView : UserControl
    {
        public ShowAllWeightClassesView()
        {
            InitializeComponent();
            Messenger.Default.Register<ActiveAgeClassId>(this, SetContext);
        }

        public void SetContext(ActiveAgeClassId action)
        {
            DataContext = new ShowAllWeightClassesViewModel(action.AgeClassId);
        }
    }
}
