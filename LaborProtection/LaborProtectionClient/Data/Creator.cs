using LaborProtectionClient.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborProtectionClient.Data
{
    internal static class Creator
    {
        public static IAnswerBox Create(this QuestionType type)
        {
            switch (type)
            {
                case QuestionType.One:
                    return new RadioAnswerBox();
                case QuestionType.Many:
                    return new CheckAnswerBox();
                case QuestionType.Text:
                    return new TextAnswerBox();
                default: 
                    return null;
            }
        }
    }
}
