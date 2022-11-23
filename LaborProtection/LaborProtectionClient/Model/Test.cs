using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LaborProtectionClient.Model
{
    public class Test
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Count { get; set; }

        public List<Question> questions;
        public List<Question> Questions
        {
            get { return questions??(questions=ParseFile(Filename)); }
        }
        public string Filename { get; set; }

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
                question.Type = (QuestionType)Enum.Parse(typeof(QuestionType), item.Attributes["Type"].Value);
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
}
