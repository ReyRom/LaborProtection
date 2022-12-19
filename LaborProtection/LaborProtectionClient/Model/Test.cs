using LaborProtectionClient.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace LaborProtectionClient.Model
{
    public class Test
    {
        public string Name { get; set; }
        public string Description { get; set; }
        private List<Question> questions;
        public List<Question> Questions { get => questions; }
        public string Filename { get; set; }

        public Test(string fileName)
        {
            this.Filename = fileName;
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
                    answer.Text = answ.InnerText;
                    answer.IsCorrect = answ.HasAttribute("IsCorrect");
                    question.Answers.Add(answer);
                }
                question.Answers = question.Answers.Shuffle().ToList();
                list.Add(question);
            }
            var count = root.HasAttribute("Count") ? Convert.ToInt32(root.Attributes["Count"].Value) : list.Count;
            this.questions = list.Shuffle().Take(count).ToList();
            this.Name = root.Attributes["Name"].Value;
            this.Description = root.Attributes["Description"].Value;
        }


        //public static Test ParseFile(string fileName)
        //{
        //    Test test = new Test();
        //    var list = new List<Question>();
        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(File.ReadAllText(fileName));
        //    var root = doc.DocumentElement;
        //    var items = root.ChildNodes;
        //    foreach (XmlElement item in items)
        //    {
        //        Question question = new Question();
        //        question.Text = item.Attributes["Text"].Value;
        //        question.Type = (QuestionType)Enum.Parse(typeof(QuestionType), item.Attributes["Type"].Value);
        //        foreach (XmlElement answ in item.ChildNodes)
        //        {
        //            Answer answer = new Answer();
        //            answer.Text = answ.InnerText;
        //            answer.IsCorrect = answ.HasAttribute("IsCorrect");
        //            question.Answers.Add(answer);
        //        }
        //        list.Add(question);
        //    }
        //    test.Questions = list.Shuffle().Take(Int32.Parse(root.Attributes["Count"].Value)).ToList();

        //    return test;
        //}
    }
}
