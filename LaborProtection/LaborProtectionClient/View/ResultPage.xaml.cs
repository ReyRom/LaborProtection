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
    /// Логика взаимодействия для ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        public ResultPage(int maxScore, int score)
        {
            InitializeComponent();

            DataContext = this; 
            
            result = GetMark(maxScore, score).ToString();
            Score = $"{score}/{maxScore}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._MainFrame.Navigate(new TestListPage());
        }

        private string result;
        public string Result { get => result; }
        public string Score { get; set; }

        public int GetMark(double maxScore, double score)
        {
            var percent = score / maxScore * 100;
            if (percent >= 85)
            {
                return 5;
            }
            if (percent >= 75)
            {
                return 4;
            }
            if (percent >= 60)
            {
                return 3;
            }
            return 2;
        }
    }
}
