using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LaborProtectionClient.Model
{
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
    }
}
