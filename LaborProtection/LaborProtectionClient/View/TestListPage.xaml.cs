using LaborProtectionClient.Controls;
using LaborProtectionClient.Extensions;
using LaborProtectionClient.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

namespace LaborProtectionClient.View
{
    /// <summary>
    /// Логика взаимодействия для TestListPage.xaml
    /// </summary>
    public partial class TestListPage : Page, INotifyPropertyChanged
    {
        public double ListHeight
        {
            get => (page.ActualHeight == 0 ? 450 : page.ActualHeight) - 30;
        }
        public TestListPage()
        {
            InitializeComponent();

            DataContext = this;

            Tests = new List<Test>();
            foreach (var file in Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "Tests")))
            {
                try
                {
                    Tests.Add(new Test(file));
                }
                catch
                {

                }
            }
            if (Tests.Count < 1)
            {
                DialogWindow.Show("Файлы лекций не обнаружены");
            }
            Test = Tests.FirstOrDefault();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._MainFrame.Navigate(new StartPage());
        }

        public List<Test> Tests { get; set; }

        public Test Test
        {
            get => test;
            set
            {
                test = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("Test"));
            }
        }

        Command startTestCommand;
        private Test test;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Command StartTestCommand
        {
            get
            {
                return startTestCommand ??
                    (startTestCommand = new Command(obj =>
                    {
                        MainWindow._MainFrame.Navigate(new TestPage((Test)obj));
                    }));
            }
        }
    }
}
