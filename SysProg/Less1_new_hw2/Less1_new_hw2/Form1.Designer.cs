namespace Less1_new_hw2
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
            this.originalText = new System.Windows.Forms.TextBox();
            this.encryptedText = new System.Windows.Forms.TextBox();
            this.cbCipherType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // originalText
            // 
            this.originalText.Location = new System.Drawing.Point(12, 12);
            this.originalText.Multiline = true;
            this.originalText.Name = "originalText";
            this.originalText.Size = new System.Drawing.Size(334, 333);
            this.originalText.TabIndex = 0;
            // 
            // encryptedText
            // 
            this.encryptedText.Location = new System.Drawing.Point(361, 12);
            this.encryptedText.Multiline = true;
            this.encryptedText.Name = "encryptedText";
            this.encryptedText.Size = new System.Drawing.Size(334, 333);
            this.encryptedText.TabIndex = 1;
            // 
            // cbCipherType
            // 
            this.cbCipherType.FormattingEnabled = true;
            this.cbCipherType.Location = new System.Drawing.Point(12, 366);
            this.cbCipherType.Name = "cbCipherType";
            this.cbCipherType.Size = new System.Drawing.Size(246, 23);
            this.cbCipherType.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 348);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cipher type";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(271, 366);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 4;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 401);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCipherType);
            this.Controls.Add(this.encryptedText);
            this.Controls.Add(this.originalText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox originalText;
        private TextBox encryptedText;
        private ComboBox cbCipherType;
        private Label label1;
        private Button btnEncrypt;
    }
}