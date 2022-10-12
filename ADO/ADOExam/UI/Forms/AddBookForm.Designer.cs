
namespace UI.Forms
{
    partial class AddBookForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cbAuthor = new System.Windows.Forms.ComboBox();
            this.cbGenre = new System.Windows.Forms.ComboBox();
            this.cbCreator = new System.Windows.Forms.ComboBox();
            this.dtpDateCreate = new System.Windows.Forms.DateTimePicker();
            this.nudBasePrice = new System.Windows.Forms.NumericUpDown();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.cbPrevBook = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudBasePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Prev. Book";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Price";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(12, 240);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Base Price";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(12, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "DateCreate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(12, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Creator";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Genre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Author";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(15, 25);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(344, 20);
            this.tbName.TabIndex = 23;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(15, 378);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(284, 378);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 32;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cbAuthor
            // 
            this.cbAuthor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuthor.FormattingEnabled = true;
            this.cbAuthor.Location = new System.Drawing.Point(15, 69);
            this.cbAuthor.Name = "cbAuthor";
            this.cbAuthor.Size = new System.Drawing.Size(344, 21);
            this.cbAuthor.TabIndex = 33;
            // 
            // cbGenre
            // 
            this.cbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenre.FormattingEnabled = true;
            this.cbGenre.Location = new System.Drawing.Point(15, 114);
            this.cbGenre.Name = "cbGenre";
            this.cbGenre.Size = new System.Drawing.Size(344, 21);
            this.cbGenre.TabIndex = 34;
            // 
            // cbCreator
            // 
            this.cbCreator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCreator.FormattingEnabled = true;
            this.cbCreator.Location = new System.Drawing.Point(15, 162);
            this.cbCreator.Name = "cbCreator";
            this.cbCreator.Size = new System.Drawing.Size(344, 21);
            this.cbCreator.TabIndex = 35;
            // 
            // dtpDateCreate
            // 
            this.dtpDateCreate.Location = new System.Drawing.Point(15, 207);
            this.dtpDateCreate.Name = "dtpDateCreate";
            this.dtpDateCreate.Size = new System.Drawing.Size(344, 20);
            this.dtpDateCreate.TabIndex = 36;
            // 
            // nudBasePrice
            // 
            this.nudBasePrice.DecimalPlaces = 2;
            this.nudBasePrice.Location = new System.Drawing.Point(15, 256);
            this.nudBasePrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudBasePrice.Name = "nudBasePrice";
            this.nudBasePrice.Size = new System.Drawing.Size(344, 20);
            this.nudBasePrice.TabIndex = 37;
            this.nudBasePrice.ThousandsSeparator = true;
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(15, 302);
            this.nudPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(344, 20);
            this.nudPrice.TabIndex = 38;
            this.nudPrice.ThousandsSeparator = true;
            // 
            // cbPrevBook
            // 
            this.cbPrevBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrevBook.FormattingEnabled = true;
            this.cbPrevBook.Location = new System.Drawing.Point(15, 348);
            this.cbPrevBook.Name = "cbPrevBook";
            this.cbPrevBook.Size = new System.Drawing.Size(344, 21);
            this.cbPrevBook.TabIndex = 39;
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 413);
            this.Controls.Add(this.cbPrevBook);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.nudBasePrice);
            this.Controls.Add(this.dtpDateCreate);
            this.Controls.Add(this.cbCreator);
            this.Controls.Add(this.cbGenre);
            this.Controls.Add(this.cbAuthor);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "AddForm";
            this.Text = "AddForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudBasePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cbAuthor;
        private System.Windows.Forms.ComboBox cbGenre;
        private System.Windows.Forms.ComboBox cbCreator;
        private System.Windows.Forms.DateTimePicker dtpDateCreate;
        private System.Windows.Forms.NumericUpDown nudBasePrice;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.ComboBox cbPrevBook;
    }
}