namespace CopyFile
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
            this.tbFileFrom = new System.Windows.Forms.TextBox();
            this.btnSelDirFrom = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            // tbFileFrom
            // 
            this.tbFileFrom.Enabled = false;
            this.tbFileFrom.Location = new System.Drawing.Point(12, 18);
            this.tbFileFrom.Name = "tbFileFrom";
            this.tbFileFrom.PlaceholderText = "Select output file";
            this.tbFileFrom.ReadOnly = true;
            this.tbFileFrom.Size = new System.Drawing.Size(357, 23);
            this.tbFileFrom.TabIndex = 2;
            this.tbFileFrom.TabStop = false;
            this.tbFileFrom.TextChanged += new System.EventHandler(this.tbDirFrom_TextChanged);
            // 
            // btnSelDirFrom
            // 
            this.btnSelDirFrom.Location = new System.Drawing.Point(384, 18);
            this.btnSelDirFrom.Name = "btnSelDirFrom";
            this.btnSelDirFrom.Size = new System.Drawing.Size(98, 23);
            this.btnSelDirFrom.TabIndex = 4;
            this.btnSelDirFrom.Text = "Select file";
            this.btnSelDirFrom.UseVisualStyleBackColor = true;
            this.btnSelDirFrom.Click += new System.EventHandler(this.btnSelDirFrom_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(188, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Save as";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 90);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSelDirFrom);
            this.Controls.Add(this.tbFileFrom);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox tbFileFrom;
        private Button btnSelDirFrom;
        private Button button1;
    }
}