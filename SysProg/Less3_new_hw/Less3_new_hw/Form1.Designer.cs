namespace Less3_new_hw
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDirFrom = new System.Windows.Forms.TextBox();
            this.tbDirTo = new System.Windows.Forms.TextBox();
            this.btnSelDirFrom = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbState = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnStartEnd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Copy from:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Copy to:";
            // 
            // tbDirFrom
            // 
            this.tbDirFrom.Enabled = false;
            this.tbDirFrom.Location = new System.Drawing.Point(12, 18);
            this.tbDirFrom.Name = "tbDirFrom";
            this.tbDirFrom.PlaceholderText = "Select output directory";
            this.tbDirFrom.ReadOnly = true;
            this.tbDirFrom.Size = new System.Drawing.Size(357, 23);
            this.tbDirFrom.TabIndex = 2;
            this.tbDirFrom.TabStop = false;
            this.tbDirFrom.TextChanged += new System.EventHandler(this.tbDirFrom_TextChanged);
            // 
            // tbDirTo
            // 
            this.tbDirTo.Enabled = false;
            this.tbDirTo.Location = new System.Drawing.Point(12, 62);
            this.tbDirTo.Name = "tbDirTo";
            this.tbDirTo.PlaceholderText = "Select input directory";
            this.tbDirTo.ReadOnly = true;
            this.tbDirTo.Size = new System.Drawing.Size(357, 23);
            this.tbDirTo.TabIndex = 3;
            this.tbDirTo.TabStop = false;
            this.tbDirTo.TextChanged += new System.EventHandler(this.tbDirFrom_TextChanged);
            // 
            // btnSelDirFrom
            // 
            this.btnSelDirFrom.Location = new System.Drawing.Point(384, 18);
            this.btnSelDirFrom.Name = "btnSelDirFrom";
            this.btnSelDirFrom.Size = new System.Drawing.Size(98, 23);
            this.btnSelDirFrom.TabIndex = 4;
            this.btnSelDirFrom.Text = "Select directory";
            this.btnSelDirFrom.UseVisualStyleBackColor = true;
            this.btnSelDirFrom.Click += new System.EventHandler(this.btnSelDirFrom_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Select directory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbState
            // 
            this.lbState.AutoSize = true;
            this.lbState.Location = new System.Drawing.Point(12, 99);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(27, 15);
            this.lbState.TabIndex = 6;
            this.lbState.Text = "text";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 126);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(470, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 7;
            // 
            // btnStartEnd
            // 
            this.btnStartEnd.Enabled = false;
            this.btnStartEnd.Location = new System.Drawing.Point(215, 166);
            this.btnStartEnd.Name = "btnStartEnd";
            this.btnStartEnd.Size = new System.Drawing.Size(75, 23);
            this.btnStartEnd.TabIndex = 8;
            this.btnStartEnd.Text = "Start";
            this.btnStartEnd.UseVisualStyleBackColor = true;
            this.btnStartEnd.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 201);
            this.Controls.Add(this.btnStartEnd);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lbState);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSelDirFrom);
            this.Controls.Add(this.tbDirTo);
            this.Controls.Add(this.tbDirFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tbDirFrom;
        private TextBox tbDirTo;
        private Button btnSelDirFrom;
        private Button button1;
        private Label lbState;
        private ProgressBar progressBar1;
        private Button btnStartEnd;
    }
}