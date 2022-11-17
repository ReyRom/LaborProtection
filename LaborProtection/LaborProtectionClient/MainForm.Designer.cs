namespace LaborProtectionClient
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.questionBox1 = new LaborProtectionClient.Controls.QuestionBox();
            this.questionBox2 = new LaborProtectionClient.Controls.QuestionBox();
            this.questionBox3 = new LaborProtectionClient.Controls.QuestionBox();
            this.web1 = new LaborProtectionClient.Controls.Web();
            this.SuspendLayout();
            // 
            // questionBox1
            // 
            this.questionBox1.AutoSize = true;
            this.questionBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.questionBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.questionBox1.Location = new System.Drawing.Point(12, 12);
            this.questionBox1.Name = "questionBox1";
            this.questionBox1.Question = null;
            this.questionBox1.Size = new System.Drawing.Size(54, 25);
            this.questionBox1.TabIndex = 0;
            // 
            // questionBox2
            // 
            this.questionBox2.AutoSize = true;
            this.questionBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.questionBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.questionBox2.Location = new System.Drawing.Point(278, 12);
            this.questionBox2.Name = "questionBox2";
            this.questionBox2.Question = null;
            this.questionBox2.Size = new System.Drawing.Size(54, 25);
            this.questionBox2.TabIndex = 1;
            // 
            // questionBox3
            // 
            this.questionBox3.AutoSize = true;
            this.questionBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.questionBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.questionBox3.Location = new System.Drawing.Point(544, 12);
            this.questionBox3.Name = "questionBox3";
            this.questionBox3.Question = null;
            this.questionBox3.Size = new System.Drawing.Size(54, 25);
            this.questionBox3.TabIndex = 2;
            // 
            // web1
            // 
            this.web1.Location = new System.Drawing.Point(12, 173);
            this.web1.Name = "web1";
            this.web1.Size = new System.Drawing.Size(817, 223);
            this.web1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 417);
            this.Controls.Add(this.web1);
            this.Controls.Add(this.questionBox3);
            this.Controls.Add(this.questionBox2);
            this.Controls.Add(this.questionBox1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.QuestionBox questionBox1;
        private Controls.QuestionBox questionBox2;
        private Controls.QuestionBox questionBox3;
        private Controls.Web web1;
    }
}