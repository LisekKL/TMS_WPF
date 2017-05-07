using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament_Management_Software.Model;

namespace Tournament_Management_Software.ViewModels
{
    public class DefaultViewModel : ObservableObject
    {
        public string Text { get; set; }


        public DefaultViewModel()
        {
            Text = "Hello,\n\nThis is the Tournament Management Software\n It was created for educational purposed by \nKarolina Lisowska\n\nPlease explore :)";
            RaisePropertyChangedEvent("DefaultDataList");
        }
    }
}
