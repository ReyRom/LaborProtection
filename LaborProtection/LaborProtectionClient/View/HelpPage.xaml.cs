using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace LaborProtectionClient.View
{
    /// <summary>
    /// Логика взаимодействия для HelpPage.xaml
    /// </summary>
    public partial class HelpPage : Page
    {
        public string Version
        {
            get => Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        public HelpPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._MainFrame.Navigate(new StartPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var x = Path.Combine(Environment.CurrentDirectory, "help.html");
            Viewer.NavigateToString(Properties.Resources.help);
        }
    }
}
