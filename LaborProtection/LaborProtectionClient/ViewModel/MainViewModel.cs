using LaborProtectionClient.Extensions;
using LaborProtectionClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LaborProtectionClient.ViewModel
{
    public class MainViewModel
    {
        public MainViewModel(Frame mainFrame)
        {
            MainFrame = mainFrame;
        }

        public static Frame MainFrame { get; set; }
    }
}
