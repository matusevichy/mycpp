namespace StopWatch
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
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbCounter = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(12, 41);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 70);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.lbTime);
            this.panel1.Controls.Add(this.lbCounter);
            this.panel1.Location = new System.Drawing.Point(110, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(377, 241);
            this.panel1.TabIndex = 3;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbTime.ForeColor = System.Drawing.Color.Blue;
            this.lbTime.Location = new System.Drawing.Point(150, 93);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(89, 37);
            this.lbTime.TabIndex = 1;
            this.lbTime.Text = "0:00.0";
            // 
            // lbCounter
            // 
            this.lbCounter.AutoSize = true;
            this.lbCounter.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbCounter.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbCounter.Location = new System.Drawing.Point(328, 0);
            this.lbCounter.Name = "lbCounter";
            this.lbCounter.Padding = new System.Windows.Forms.Padding(0, 10, 10, 0);
            this.lbCounter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbCounter.Size = new System.Drawing.Size(49, 35);
            this.lbCounter.TabIndex = 0;
            this.lbCounter.Text = "0/0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 263);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Button btnReset;
        private Panel panel1;
        private Label lbTime;
        private Label lbCounter;
        private System.Windows.Forms.Timer timer1;
    }
}