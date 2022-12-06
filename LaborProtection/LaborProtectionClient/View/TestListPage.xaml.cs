using LaborProtectionClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;

namespace LaborProtectionClient.View
{
    /// <summary>
    /// Логика взаимодействия для TestListPage.xaml
    /// </summary>
    public partial class TestListPage : Page
    {
        public TestListPage()
        {
            InitializeComponent();

            DataContext = new TestListViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.MainFrame.Navigate(new LectionPage());
        }
    }
}
