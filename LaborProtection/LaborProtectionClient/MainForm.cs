using LaborProtectionClient.Controls;
using LaborProtectionClient.Data;

namespace LaborProtectionClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Question question1 = new Question();
            question1.Text = "Яблоко?";
            question1.Type = QuestionType.One;
            question1.Answers = new List<Answer>()
            {
                new Answer() { IsCorrect = false, Text="Тыблоко"} ,
                new Answer() { IsCorrect = true, Text="Яблоко"} ,
                new Answer() { IsCorrect = false, Text="Тыблоко"} ,
                new Answer() { IsCorrect = false, Text="Тыблоко"}
            };
            questionBox1.Initialize(question1);

            Question question2 = new Question();
            question2.Text = "Яблоко?";
            question2.Type = QuestionType.Many;
            question2.Answers = new List<Answer>()
            {
                new Answer() { IsCorrect = false, Text="Тыблоко"} ,
                new Answer() { IsCorrect = true, Text="Яблоко"} ,
                new Answer() { IsCorrect = false, Text="Тыблоко"} ,
                new Answer() { IsCorrect = true, Text="Яблоко"}
            };
            questionBox2.Initialize(question2);

            Question question3 = new Question();
            question3.Text = "Яблоко?";
            question3.Type = QuestionType.Text;
            question3.Answers = new List<Answer>()
            {
                new Answer() { IsCorrect = true, Text="Яблоко"} 
            };
            questionBox3.Initialize(question3);
            //web1.webBrowser.Url = new Uri("C:\\Users\\s03ro\\OneDrive\\Рабочий стол\\1.html");
        }
    }
}