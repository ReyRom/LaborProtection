using LaborProtectionClient.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace LaborProtectionClient.Controls
{
    /// <summary>
    /// Логика взаимодействия для QuestionBox.xaml
    /// </summary>
    public partial class QuestionBox : UserControl, INotifyPropertyChanged
    {
        private System.Windows.Threading.DispatcherTimer timer;


        private int delay;
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
                OnPropertyChanged("Text");
            }
        }

        public string Text { get => Question?.Text; }

        public int Delay { get => delay; }

        public QuestionBox()
        {
            InitializeComponent();
            DataContext = this;
            timer = new();
            timer.Interval = new TimeSpan(0,0,1);
            timer.Tick += Timer_Tick;
        }

        public event EventHandler TimerEnd;

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (delay == 0)
            {
                timer.Stop();

            }
            delay--;
            OnPropertyChanged("Delay");
        }

        public void Initialize(Question q)
        {
            Question = q;
            GenerateAnswerBoxes(q);
            StartTimer(q);
        }

        public void Initialize()
        {
            GenerateAnswerBoxes(Question);
            StartTimer(Question);
        }

        public event EventHandler SendButton_Click;
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void StartTimer(Question q)
        {
            switch (q.Type)
            {
                case QuestionType.One:
                    delay = 30;
                    break;
                case QuestionType.Many:
                    delay = 45;
                    break;
                case QuestionType.Text:
                    delay = 60;
                    break;
            }
            delay = delay;
            TimerProgressBar.Maximum = delay;
            OnPropertyChanged("Delay");
            timer.Start();
        }

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
                if (answer is ToggleButton b)
                {
                    isCorrect = ((Answer)b.Tag).IsCorrect == (b.IsChecked ?? false);
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
