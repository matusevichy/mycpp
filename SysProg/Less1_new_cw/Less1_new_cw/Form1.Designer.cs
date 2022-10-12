
namespace Less1_new_cw
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
            this.processListBox1 = new System.Windows.Forms.ListBox();
            this.killButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // processListBox1
            // 
            this.processListBox1.FormattingEnabled = true;
            this.processListBox1.ItemHeight = 15;
            this.processListBox1.Location = new System.Drawing.Point(12, 12);
            this.processListBox1.Name = "processListBox1";
            this.processListBox1.Size = new System.Drawing.Size(309, 409);
            this.processListBox1.TabIndex = 0;
            // 
            // killButton
            // 
            this.killButton.Location = new System.Drawing.Point(341, 12);
            this.killButton.Name = "killButton";
            this.killButton.Size = new System.Drawing.Size(88, 23);
            this.killButton.TabIndex = 1;
            this.killButton.Text = "Kill process";
            this.killButton.UseVisualStyleBackColor = true;
            this.killButton.Click += new System.EventHandler(this.killButton_Click);
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(341, 41);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(88, 23);
            this.newButton.TabIndex = 2;
            this.newButton.Text = "Start process";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 450);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.killButton);
            this.Controls.Add(this.processListBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox processListBox1;
        private Button killButton;
        private Button newButton;
        private System.Windows.Forms.Timer timer1;
    }
}