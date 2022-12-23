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
    /// Логика взаимодействия для WebPage.xaml
    /// </summary>
    public partial class LectionPage : Page, INotifyPropertyChanged
    {
        public double ListHeight
        {
            get => (page.ActualHeight==0?450: page.ActualHeight) - 30;
        }
        List<Lection> lections;
        public LectionPage()
        {
            InitializeComponent();
            DataContext = this;

            lections = new List<Lection>();
            if (Directory.Exists(lectionsPath))
            {
                foreach (var file in Directory.GetFiles(lectionsPath, "", SearchOption.AllDirectories).Where(x => Path.GetExtension(x) == ".html"))
                {
                    lections.Add(new Lection() { Group = Path.GetDirectoryName(file).Replace(lectionsPath, "").TrimStart('\\'), Name = Path.GetFileNameWithoutExtension(file), Url = file });
                }

                var view = new CollectionViewSource();
                view.GroupDescriptions.Add(new PropertyGroupDescription("Group"));
                view.Source = lections;
                Lections = view;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._MainFrame.Navigate(new StartPage());
        }

        private void page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("ListHeight"));
        }

        private string lectionsPath = Path.Combine(Environment.CurrentDirectory, "Lections");
        public CollectionViewSource Lections { get; set; }

        Command openLectionCommand;
        public Command OpenLectionCommand
        {
            get
            {
                return openLectionCommand ??
                    (openLectionCommand = new Command(obj =>
                    {
                        Viewer.Navigate(new Uri(obj.ToString()));
                    }));
            }
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            if (lections.Count < 1)
            {
                DialogWindow.Show("Файлы лекций не обнаружены");
                MainWindow._MainFrame.Navigate(new StartPage());
            }
        }
    }
}
