using LaborProtectionClient.Controls;
using LaborProtectionClient.Model;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LaborProtectionClient.View
{
    /// <summary>
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page, INotifyPropertyChanged
    {
        int score = 0;
        int maxScore = 0;
        public TestPage(Test test)
        {
            InitializeComponent();
            this.test = test;
            maxScore = test.Questions.Count;
            DataContext = this;
        }

        private void QuestionBox_Loaded(object sender, RoutedEventArgs e)
        {
            QuestionBox.Initialize();
        }

        private void QuestionBox_NextQuestion(object sender, EventArgs e)
        {
            if (QuestionBox.CheckAnswer()) score++;
            var q = Increment();
            if (q != null)
            {
                QuestionBox.Initialize(q);
            }
            else
            {
                QuestionBox.Reset();
                MainWindow._MainFrame.Navigate(new ResultPage(maxScore, score));
            }
        }

        private Test test;
        private int qNumber = 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Question CurrentQuestion
        {
            get => test.Questions[qNumber];
        }

        public Question Increment()
        {
            if (qNumber == test.Questions.Count - 1)
            {
                return null;
            }
            return test.Questions[++qNumber];
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (DialogWindow.Show("Вы уверены, что хотите завершить тест?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                QuestionBox.Reset();
                MainWindow._MainFrame.Navigate(new ResultPage(maxScore, score));
            }
        }
    }
}
