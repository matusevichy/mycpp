
namespace UI.Forms
{
    partial class SaleBookForm
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
            this.cbBookList = new System.Windows.Forms.ComboBox();
            this.nudSaleCount = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbUserList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudSaleCount)).BeginInit();
            this.SuspendLayout();
            // 
            // cbBookList
            // 
            this.cbBookList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBookList.FormattingEnabled = true;
            this.cbBookList.Location = new System.Drawing.Point(12, 12);
            this.cbBookList.Name = "cbBookList";
            this.cbBookList.Size = new System.Drawing.Size(265, 21);
            this.cbBookList.TabIndex = 0;
            // 
            // nudSaleCount
            // 
            this.nudSaleCount.Location = new System.Drawing.Point(12, 66);
            this.nudSaleCount.Name = "nudSaleCount";
            this.nudSaleCount.Size = new System.Drawing.Size(265, 20);
            this.nudSaleCount.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(203, 92);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 92);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbUserList
            // 
            this.cbUserList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserList.FormattingEnabled = true;
            this.cbUserList.Location = new System.Drawing.Point(12, 39);
            this.cbUserList.Name = "cbUserList";
            this.cbUserList.Size = new System.Drawing.Size(265, 21);
            this.cbUserList.TabIndex = 4;
            // 
            // SaleBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 122);
            this.Controls.Add(this.cbUserList);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.nudSaleCount);
            this.Controls.Add(this.cbBookList);
            this.Name = "SaleBookForm";
            this.Text = "SaleBookForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudSaleCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBookList;
        private System.Windows.Forms.NumericUpDown nudSaleCount;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbUserList;
    }
}