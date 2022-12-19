using LaborProtectionClient.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для WebPage.xaml
    /// </summary>
    public partial class LectionPage : Page, INotifyPropertyChanged
    {
        public double ListHeight
        {
            get => (page.ActualHeight==0?450: page.ActualHeight) - 30;
        }

        public LectionPage()
        {
            InitializeComponent();
            DataContext = new LectionViewModel(Viewer);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.MainFrame.Navigate(new TestListPage());
        }

        private void page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("ListHeight"));
        }
    }
}
