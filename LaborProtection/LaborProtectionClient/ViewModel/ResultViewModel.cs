using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborProtectionClient.ViewModel
{
    public class ResultViewModel
    {
        private string result;
        public string Result { get => result; }
        public string Score { get; set; }
        public ResultViewModel(int maxScore, int score) 
        { 
            result = GetMark(maxScore, score).ToString();
            Score = $"{score}/{maxScore}";
        }

        public int GetMark(double maxScore, double score)
        {
            var percent = score/maxScore*100;
            if (percent >= 85)
            {
                return 5;
            }
            if (percent >= 75)
            {
                return 4;
            }
            if (percent >= 60)
            {
                return 3;
            }
            return 2;
        }
    }
}
