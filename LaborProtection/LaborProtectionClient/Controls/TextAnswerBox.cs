using LaborProtectionClient.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaborProtectionClient.Controls
{
    public partial class TextAnswerBox : TextBox, IAnswerBox
    {
        public TextAnswerBox()
        {
            InitializeComponent();
        }

        public bool IsCorrect => Answer.Text == Text;

        public Answer Answer { get; set; }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
