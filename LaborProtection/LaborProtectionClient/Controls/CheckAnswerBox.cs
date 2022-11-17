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
    public partial class CheckAnswerBox : CheckBox, IAnswerBox
    {
        public CheckAnswerBox()
        {
            InitializeComponent();
        }

        public bool IsCorrect => Answer.IsCorrect == Checked;
        public override string Text { get => Answer.Text; }
        public Answer Answer { get; set; }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
