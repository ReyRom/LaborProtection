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
using System.Windows.Shapes;

namespace LaborProtectionClient.Controls
{
    /// <summary>
    /// Логика взаимодействия для DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public MessageBoxResult DialogResult { get; set; }
        private DialogWindow(string message, string title, MessageBoxButton button)
        {
            InitializeComponent();
            DataContext= this;
            Title = title;
            Message = message;
            switch (button)
            {
                case MessageBoxButton.OK:
                    Ok.Visibility = Visibility.Visible;
                    Yes.Visibility = No.Visibility = Visibility.Collapsed;
                    break;
                case MessageBoxButton.YesNo:
                    Ok.Visibility = Visibility.Collapsed;
                    Yes.Visibility = No.Visibility = Visibility.Visible;
                    break;
                default:
                    Ok.Visibility = Yes.Visibility = No.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        public static MessageBoxResult Show(string message, string title = "", MessageBoxButton button=MessageBoxButton.OK)
        {
            var window = new DialogWindow(message, title,button);
            window.ShowDialog();
            return window.DialogResult;
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= MessageBoxResult.Yes;
            Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= MessageBoxResult.No;
            Close();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= MessageBoxResult.OK;
            Close();
        }
    }
}
