using LaborProtectionClient.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaborProtectionClient.Controls
{
    public partial class QuestionBox : UserControl
    {
        public Question? Question { get; set; }
        public QuestionBox()
        {
            InitializeComponent();
        }

        public void Initialize(Question q)
        {
            Question = q;
            QuestionLabel.Text = q?.Text;
            
            GenerateAnswerBoxes(q);
        }

        public void GenerateAnswerBoxes(Question q) 
        {
            foreach (Control item in Controls)
            {
                if (item is IAnswerBox)
                {
                    Controls.Remove(item);
                }
            }
            foreach (var answer in q.Answers)
            {
                IAnswerBox answerBox = q.Type.Create();
                answerBox.Answer = answer;
                var item = (Control)answerBox;
                Controls.Add(item);
                item.Parent = flowLayoutPanel;
            }
        }
    }
}
