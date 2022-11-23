using LaborProtectionClient.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

namespace LaborProtectionClient.Controls
{
    /// <summary>
    /// Логика взаимодействия для QuestionBox.xaml
    /// </summary>
    public partial class QuestionBox : UserControl
    {
        private Question? question;

        public Question? Question 
        { 
            get => question;
            set
            {
                question = value;
                GenerateAnswerBoxes(value);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SendButton_Click?.Invoke(sender, e);
        }
    }
}
