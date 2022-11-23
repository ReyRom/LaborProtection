using LaborProtectionClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaborProtectionClient.Controls
{
    public interface IAnswerBox
    {
        public bool IsCorrect { get; }
        Answer Answer { get; set; }
    }
}
