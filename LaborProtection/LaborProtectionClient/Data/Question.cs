using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LaborProtectionClient.Data
{
    public enum QuestionType
    {
        One,
        Many,
        Text
    }
    public class Question
    {
        public Question()
        {
            Text = "";
            Answers = new List<Answer>();
            Type = QuestionType.One;
        }

        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
        public QuestionType Type { get; set; }


        public static List<Question> ParseFile(string fileName)
        {
            var list = new List<Question>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(File.ReadAllText(fileName));
            var root = doc.DocumentElement;
            var items = root.ChildNodes;
            foreach (XmlElement item in items)
            {
                Question question = new Question();
                question.Text = item.Attributes["Text"].Value;
                question.Type = (QuestionType)Enum.Parse(typeof(QuestionType),item.Attributes["Type"].Value);
                foreach (XmlElement answ in item.ChildNodes)
                {
                    Answer answer = new Answer();
                    answer.Text = answ.Attributes["Text"].Value;
                    answer.IsCorrect = answ.Attributes["IsCorrect"].Value == "true";
                    question.Answers.Add(answer);
                }
                list.Add(question);
            }
            return list;
        }
    }
    public class Answer
    {
        public Answer()
        {
            Text = "";
            IsCorrect = false;
        }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
