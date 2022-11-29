using LaborProtectionClient.Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LaborProtectionClient.Controls
{
    /// <summary>
    /// Логика взаимодействия для QuestionBox.xaml
    /// </summary>
    public partial class QuestionBox : UserControl
    {
        public static readonly DependencyProperty QuestionProperty =
            DependencyProperty.Register("Question", typeof(Question), typeof(QuestionBox));
        public Question Question
        {
            get
            {
                return (Question)GetValue(QuestionProperty);
            }
            set
            {
                SetValue(QuestionProperty, value);
            }
        }

        public string Text { get => Question?.Text; }


        public QuestionBox()
        {
            InitializeComponent();
            DataContext = this;
        }
        public void Initialize(Question q)
        {
            Question = q;
            GenerateAnswerBoxes(q);
        }

        public void Initialize()
        {
            GenerateAnswerBoxes(Question);
        }

        public event EventHandler SendButton_Click;

        public void GenerateAnswerBoxes(Question q)
        {
            AnswersPanel.Children.Clear();
            foreach (var answer in q.Answers)
            {
                Control item;
                switch (q.Type)
                {
                    case QuestionType.One:
                        var r = new RadioButton();
                        r.Content = answer.Text;
                        item = r;
                        break;
                    case QuestionType.Many:
                        var c = new CheckBox();
                        item = c;
                        c.Content = answer.Text;
                        break;
                    case QuestionType.Text:
                        var t = new TextBox();
                        item = t;
                        break;
                    default:
                        item = null;
                        break;
                }

                item.Tag = answer;
                AnswersPanel.Children.Add(item);
            }
        }

        public bool CheckAnswer()
        {
            bool isCorrect = true;
            foreach (var answer in AnswersPanel.Children)
            {
                if (answer is RadioButton rb)
                {
                    isCorrect = ((Answer)rb.Tag).IsCorrect == (rb.IsChecked ?? false);
                }
                else if (answer is CheckBox cb)
                {
                    isCorrect = ((Answer)cb.Tag).IsCorrect == (cb.IsChecked ?? false);
                }
                else if (answer is TextBox tb)
                {
                    isCorrect = ((Answer)tb.Tag).Text == tb.Text;
                }
                if (!isCorrect) return false;
            }
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SendButton_Click?.Invoke(sender, e);
        }
    }
}
