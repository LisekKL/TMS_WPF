using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Tournament_Management_Software.Helpers
{
    public class ButtonItem
    {
        public ButtonItem()
        {
            Visibility = Visibility.Visible;
            IsActive = true;
        }
        public string Label { get; set; }
        public ICommand Command { get; set; }
        public Visibility Visibility { get; set; }
        public bool IsActive { get; set; }
    }
}
