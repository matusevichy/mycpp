namespace Less4_new_hw
{
    partial class Form1
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
            this.tbText = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.btnSaveReport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbExclamatorySentences = new System.Windows.Forms.CheckBox();
            this.cbQuestionSentences = new System.Windows.Forms.CheckBox();
            this.cbWords = new System.Windows.Forms.CheckBox();
            this.cbCharacters = new System.Windows.Forms.CheckBox();
            this.cbSentences = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(12, 12);
            this.tbText.Multiline = true;
            this.tbText.Name = "tbText";
            this.tbText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbText.Size = new System.Drawing.Size(776, 272);
            this.tbText.TabIndex = 0;
            this.tbText.TextChanged += new System.EventHandler(this.tbText_TextChanged);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(362, 290);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnViewReport
            // 
            this.btnViewReport.Enabled = false;
            this.btnViewReport.Location = new System.Drawing.Point(3, 143);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(75, 23);
            this.btnViewReport.TabIndex = 2;
            this.btnViewReport.Text = "View report";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // btnSaveReport
            // 
            this.btnSaveReport.Enabled = false;
            this.btnSaveReport.Location = new System.Drawing.Point(122, 143);
            this.btnSaveReport.Name = "btnSaveReport";
            this.btnSaveReport.Size = new System.Drawing.Size(75, 23);
            this.btnSaveReport.TabIndex = 3;
            this.btnSaveReport.Text = "Save report";
            this.btnSaveReport.UseVisualStyleBackColor = true;
            this.btnSaveReport.Click += new System.EventHandler(this.btnSaveReport_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnViewReport);
            this.panel1.Controls.Add(this.btnSaveReport);
            this.panel1.Location = new System.Drawing.Point(588, 290);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 169);
            this.panel1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbExclamatorySentences);
            this.groupBox1.Controls.Add(this.cbQuestionSentences);
            this.groupBox1.Controls.Add(this.cbWords);
            this.groupBox1.Controls.Add(this.cbCharacters);
            this.groupBox1.Controls.Add(this.cbSentences);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 134);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report with:";
            // 
            // cbExclamatorySentences
            // 
            this.cbExclamatorySentences.AutoSize = true;
            this.cbExclamatorySentences.Checked = true;
            this.cbExclamatorySentences.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbExclamatorySentences.Location = new System.Drawing.Point(6, 115);
            this.cbExclamatorySentences.Name = "cbExclamatorySentences";
            this.cbExclamatorySentences.Size = new System.Drawing.Size(146, 19);
            this.cbExclamatorySentences.TabIndex = 4;
            this.cbExclamatorySentences.Text = "exclamatory sentences";
            this.cbExclamatorySentences.UseVisualStyleBackColor = true;
            // 
            // cbQuestionSentences
            // 
            this.cbQuestionSentences.AutoSize = true;
            this.cbQuestionSentences.Checked = true;
            this.cbQuestionSentences.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbQuestionSentences.Location = new System.Drawing.Point(6, 95);
            this.cbQuestionSentences.Name = "cbQuestionSentences";
            this.cbQuestionSentences.Size = new System.Drawing.Size(127, 19);
            this.cbQuestionSentences.TabIndex = 3;
            this.cbQuestionSentences.Text = "question sentences";
            this.cbQuestionSentences.UseVisualStyleBackColor = true;
            // 
            // cbWords
            // 
            this.cbWords.AutoSize = true;
            this.cbWords.Checked = true;
            this.cbWords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWords.Location = new System.Drawing.Point(6, 70);
            this.cbWords.Name = "cbWords";
            this.cbWords.Size = new System.Drawing.Size(92, 19);
            this.cbWords.TabIndex = 2;
            this.cbWords.Text = "words count";
            this.cbWords.UseVisualStyleBackColor = true;
            // 
            // cbCharacters
            // 
            this.cbCharacters.AutoSize = true;
            this.cbCharacters.Checked = true;
            this.cbCharacters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCharacters.Location = new System.Drawing.Point(6, 45);
            this.cbCharacters.Name = "cbCharacters";
            this.cbCharacters.Size = new System.Drawing.Size(114, 19);
            this.cbCharacters.TabIndex = 1;
            this.cbCharacters.Text = "characters count";
            this.cbCharacters.UseVisualStyleBackColor = true;
            // 
            // cbSentences
            // 
            this.cbSentences.AutoSize = true;
            this.cbSentences.Checked = true;
            this.cbSentences.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSentences.Location = new System.Drawing.Point(6, 20);
            this.cbSentences.Name = "cbSentences";
            this.cbSentences.Size = new System.Drawing.Size(112, 19);
            this.cbSentences.TabIndex = 0;
            this.cbSentences.Text = "sentences count";
            this.cbSentences.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 471);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tbText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbText;
        private Button btnStart;
        private Button btnViewReport;
        private Button btnSaveReport;
        private Panel panel1;
        private GroupBox groupBox1;
        private CheckBox cbSentences;
        private CheckBox cbExclamatorySentences;
        private CheckBox cbQuestionSentences;
        private CheckBox cbWords;
        private CheckBox cbCharacters;
    }
}