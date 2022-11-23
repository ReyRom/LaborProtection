using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborProtectionClient.Model
{
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
