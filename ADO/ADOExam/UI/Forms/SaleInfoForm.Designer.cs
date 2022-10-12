
namespace UI.Forms
{
    partial class SaleInfoForm
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
            this.lbSales = new System.Windows.Forms.ListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbSales
            // 
            this.lbSales.FormattingEnabled = true;
            this.lbSales.Location = new System.Drawing.Point(12, 12);
            this.lbSales.Name = "lbSales";
            this.lbSales.Size = new System.Drawing.Size(448, 433);
            this.lbSales.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(200, 451);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // SaleInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(472, 486);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lbSales);
            this.Name = "SaleInfoForm";
            this.Text = "SaleInfoForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbSales;
        private System.Windows.Forms.Button btnOk;
    }
}