
namespace Less3_hw.Forms
{
    partial class FindForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbPathFolder = new System.Windows.Forms.Label();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.tbFindMask = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbPathFolder
            // 
            this.lbPathFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPathFolder.Location = new System.Drawing.Point(12, 9);
            this.lbPathFolder.Name = "lbPathFolder";
            this.lbPathFolder.Size = new System.Drawing.Size(339, 23);
            this.lbPathFolder.TabIndex = 0;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(367, 9);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFolder.TabIndex = 1;
            this.btnSelectFolder.Text = "SelectFolder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // tbFindMask
            // 
            this.tbFindMask.Location = new System.Drawing.Point(12, 45);
            this.tbFindMask.Name = "tbFindMask";
            this.tbFindMask.Size = new System.Drawing.Size(339, 20);
            this.tbFindMask.TabIndex = 2;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(367, 42);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 76);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.tbFindMask);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.lbPathFolder);
            this.Name = "FindForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FindForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPathFolder;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TextBox tbFindMask;
        private System.Windows.Forms.Button btnFind;
    }
}