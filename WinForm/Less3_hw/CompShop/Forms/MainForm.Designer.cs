
namespace CompShop
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbSaleList = new System.Windows.Forms.ListBox();
            this.cbProductsList = new System.Windows.Forms.ComboBox();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.lbPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbFullPrice = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbSaleList
            // 
            this.lbSaleList.FormattingEnabled = true;
            this.lbSaleList.Location = new System.Drawing.Point(12, 12);
            this.lbSaleList.Name = "lbSaleList";
            this.lbSaleList.Size = new System.Drawing.Size(344, 225);
            this.lbSaleList.TabIndex = 0;
            // 
            // cbProductsList
            // 
            this.cbProductsList.FormattingEnabled = true;
            this.cbProductsList.Location = new System.Drawing.Point(362, 12);
            this.cbProductsList.Name = "cbProductsList";
            this.cbProductsList.Size = new System.Drawing.Size(262, 21);
            this.cbProductsList.TabIndex = 1;
            this.cbProductsList.SelectedIndexChanged += new System.EventHandler(this.cbProductsList_SelectedIndexChanged);
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(549, 39);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(75, 23);
            this.btnAddToList.TabIndex = 2;
            this.btnAddToList.Text = "Add to list";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // tbPrice
            // 
            this.tbPrice.Enabled = false;
            this.tbPrice.Location = new System.Drawing.Point(362, 39);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(100, 20);
            this.tbPrice.TabIndex = 3;
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(468, 42);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(31, 13);
            this.lbPrice.TabIndex = 4;
            this.lbPrice.Text = "Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(362, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Full price:";
            // 
            // lbFullPrice
            // 
            this.lbFullPrice.AutoSize = true;
            this.lbFullPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbFullPrice.Location = new System.Drawing.Point(471, 73);
            this.lbFullPrice.Name = "lbFullPrice";
            this.lbFullPrice.Size = new System.Drawing.Size(19, 20);
            this.lbFullPrice.TabIndex = 6;
            this.lbFullPrice.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(524, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Edit products";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 246);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbFullPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.cbProductsList);
            this.Controls.Add(this.lbSaleList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbSaleList;
        private System.Windows.Forms.ComboBox cbProductsList;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbFullPrice;
        private System.Windows.Forms.Button button1;
    }
}

