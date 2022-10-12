
namespace UI.Forms
{
    partial class PromoListForm
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
            this.lbPromos = new System.Windows.Forms.ListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbPromos
            // 
            this.lbPromos.FormattingEnabled = true;
            this.lbPromos.Location = new System.Drawing.Point(12, 12);
            this.lbPromos.Name = "lbPromos";
            this.lbPromos.Size = new System.Drawing.Size(319, 394);
            this.lbPromos.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(256, 415);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 415);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Detail/Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // PromoListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 450);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lbPromos);
            this.Name = "PromoListForm";
            this.Text = "PromoListForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbPromos;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnEdit;
    }
}