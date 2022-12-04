using LaborProtectionClient.Model;
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
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        int score = 0;
        public TestPage(Test test)
        {
            InitializeComponent();
            DataContext = new TestViewModel(test);
        }

        private void QuestionBox_Loaded(object sender, RoutedEventArgs e)
        {
            QuestionBox.Initialize();
        }

        private void QuestionBox_NextQuestion(object sender, EventArgs e)
        {
            if (QuestionBox.CheckAnswer()) score++;
            var q = (DataContext as TestViewModel).Increment();
            if(q != null)
            {
                QuestionBox.Initialize(q);
            }
            else
            {
                MessageBox.Show(score.ToString());
            }
        }
    }
}
