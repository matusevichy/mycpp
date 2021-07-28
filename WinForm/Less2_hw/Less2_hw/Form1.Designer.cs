
namespace Less2_hw
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.rbSum = new System.Windows.Forms.RadioButton();
            this.rbCount = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbCocaCola = new System.Windows.Forms.CheckBox();
            this.tbCocaColaCount = new System.Windows.Forms.TextBox();
            this.tbCocaColaCost = new System.Windows.Forms.TextBox();
            this.cbFries = new System.Windows.Forms.CheckBox();
            this.tbFriesCount = new System.Windows.Forms.TextBox();
            this.tbFriesCost = new System.Windows.Forms.TextBox();
            this.cbHamburger = new System.Windows.Forms.CheckBox();
            this.tbHamburgerCount = new System.Windows.Forms.TextBox();
            this.tbHamburgerCost = new System.Windows.Forms.TextBox();
            this.cbHotDog = new System.Windows.Forms.CheckBox();
            this.tbHotDogCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbHotDogCost = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 305);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Автозаправка";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.ForeColor = System.Drawing.Color.Red;
            this.groupBox3.Location = new System.Drawing.Point(6, 156);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(196, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "До сплати";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(163, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "грн.";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(6, 34);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(151, 37);
            this.label3.TabIndex = 1;
            this.label3.Text = "0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.rbSum);
            this.groupBox2.Controls.Add(this.rbCount);
            this.groupBox2.Location = new System.Drawing.Point(6, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 74);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(77, 42);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(113, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.TextChanged += new System.EventHandler(this.textBoxFuelCount_TextChanged);
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDouble_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(77, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(113, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBoxFuelCount_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDouble_KeyPress);
            // 
            // rbSum
            // 
            this.rbSum.AutoSize = true;
            this.rbSum.Location = new System.Drawing.Point(6, 42);
            this.rbSum.Name = "rbSum";
            this.rbSum.Size = new System.Drawing.Size(51, 17);
            this.rbSum.TabIndex = 2;
            this.rbSum.TabStop = true;
            this.rbSum.Text = "Сума";
            this.rbSum.UseVisualStyleBackColor = true;
            this.rbSum.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rbCount
            // 
            this.rbCount.AutoSize = true;
            this.rbCount.Location = new System.Drawing.Point(6, 19);
            this.rbCount.Name = "rbCount";
            this.rbCount.Size = new System.Drawing.Size(65, 17);
            this.rbCount.TabIndex = 1;
            this.rbCount.TabStop = true;
            this.rbCount.Text = "Кілкість";
            this.rbCount.UseVisualStyleBackColor = true;
            this.rbCount.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(56, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ціна";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Бензин";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(56, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbCocaCola);
            this.groupBox4.Controls.Add(this.tbCocaColaCount);
            this.groupBox4.Controls.Add(this.tbCocaColaCost);
            this.groupBox4.Controls.Add(this.cbFries);
            this.groupBox4.Controls.Add(this.tbFriesCount);
            this.groupBox4.Controls.Add(this.tbFriesCost);
            this.groupBox4.Controls.Add(this.cbHamburger);
            this.groupBox4.Controls.Add(this.tbHamburgerCount);
            this.groupBox4.Controls.Add(this.tbHamburgerCost);
            this.groupBox4.Controls.Add(this.cbHotDog);
            this.groupBox4.Controls.Add(this.tbHotDogCount);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.tbHotDogCost);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(228, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(210, 305);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Кафе";
            // 
            // cbCocaCola
            // 
            this.cbCocaCola.AutoSize = true;
            this.cbCocaCola.Location = new System.Drawing.Point(3, 105);
            this.cbCocaCola.Name = "cbCocaCola";
            this.cbCocaCola.Size = new System.Drawing.Size(78, 17);
            this.cbCocaCola.TabIndex = 14;
            this.cbCocaCola.Text = "Кока-кола";
            this.cbCocaCola.UseVisualStyleBackColor = true;
            this.cbCocaCola.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // tbCocaColaCount
            // 
            this.tbCocaColaCount.Enabled = false;
            this.tbCocaColaCount.Location = new System.Drawing.Point(153, 103);
            this.tbCocaColaCount.Name = "tbCocaColaCount";
            this.tbCocaColaCount.Size = new System.Drawing.Size(49, 20);
            this.tbCocaColaCount.TabIndex = 13;
            this.tbCocaColaCount.TextChanged += new System.EventHandler(this.textBoxFoodCount_TextChanged);
            this.tbCocaColaCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDouble_KeyPress);
            // 
            // tbCocaColaCost
            // 
            this.tbCocaColaCost.Enabled = false;
            this.tbCocaColaCost.Location = new System.Drawing.Point(98, 103);
            this.tbCocaColaCost.Name = "tbCocaColaCost";
            this.tbCocaColaCost.Size = new System.Drawing.Size(49, 20);
            this.tbCocaColaCost.TabIndex = 12;
            // 
            // cbFries
            // 
            this.cbFries.AutoSize = true;
            this.cbFries.Location = new System.Drawing.Point(3, 82);
            this.cbFries.Name = "cbFries";
            this.cbFries.Size = new System.Drawing.Size(93, 17);
            this.cbFries.TabIndex = 11;
            this.cbFries.Text = "Картопля фрі";
            this.cbFries.UseVisualStyleBackColor = true;
            this.cbFries.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // tbFriesCount
            // 
            this.tbFriesCount.Enabled = false;
            this.tbFriesCount.Location = new System.Drawing.Point(153, 80);
            this.tbFriesCount.Name = "tbFriesCount";
            this.tbFriesCount.Size = new System.Drawing.Size(49, 20);
            this.tbFriesCount.TabIndex = 10;
            this.tbFriesCount.TextChanged += new System.EventHandler(this.textBoxFoodCount_TextChanged);
            this.tbFriesCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDouble_KeyPress);
            // 
            // tbFriesCost
            // 
            this.tbFriesCost.Enabled = false;
            this.tbFriesCost.Location = new System.Drawing.Point(98, 80);
            this.tbFriesCost.Name = "tbFriesCost";
            this.tbFriesCost.Size = new System.Drawing.Size(49, 20);
            this.tbFriesCost.TabIndex = 9;
            // 
            // cbHamburger
            // 
            this.cbHamburger.AutoSize = true;
            this.cbHamburger.Location = new System.Drawing.Point(3, 59);
            this.cbHamburger.Name = "cbHamburger";
            this.cbHamburger.Size = new System.Drawing.Size(80, 17);
            this.cbHamburger.TabIndex = 8;
            this.cbHamburger.Text = "Гамбургер";
            this.cbHamburger.UseVisualStyleBackColor = true;
            this.cbHamburger.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // tbHamburgerCount
            // 
            this.tbHamburgerCount.Enabled = false;
            this.tbHamburgerCount.Location = new System.Drawing.Point(153, 57);
            this.tbHamburgerCount.Name = "tbHamburgerCount";
            this.tbHamburgerCount.Size = new System.Drawing.Size(49, 20);
            this.tbHamburgerCount.TabIndex = 7;
            this.tbHamburgerCount.TextChanged += new System.EventHandler(this.textBoxFoodCount_TextChanged);
            this.tbHamburgerCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDouble_KeyPress);
            // 
            // tbHamburgerCost
            // 
            this.tbHamburgerCost.Enabled = false;
            this.tbHamburgerCost.Location = new System.Drawing.Point(98, 57);
            this.tbHamburgerCost.Name = "tbHamburgerCost";
            this.tbHamburgerCost.Size = new System.Drawing.Size(49, 20);
            this.tbHamburgerCost.TabIndex = 6;
            // 
            // cbHotDog
            // 
            this.cbHotDog.AutoSize = true;
            this.cbHotDog.Location = new System.Drawing.Point(3, 36);
            this.cbHotDog.Name = "cbHotDog";
            this.cbHotDog.Size = new System.Drawing.Size(64, 17);
            this.cbHotDog.TabIndex = 5;
            this.cbHotDog.Text = "Хот-дог";
            this.cbHotDog.UseVisualStyleBackColor = true;
            this.cbHotDog.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tbHotDogCount
            // 
            this.tbHotDogCount.Enabled = false;
            this.tbHotDogCount.Location = new System.Drawing.Point(153, 34);
            this.tbHotDogCount.Name = "tbHotDogCount";
            this.tbHotDogCount.Size = new System.Drawing.Size(49, 20);
            this.tbHotDogCount.TabIndex = 4;
            this.tbHotDogCount.TextChanged += new System.EventHandler(this.textBoxFoodCount_TextChanged);
            this.tbHotDogCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDouble_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(155, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Кілкість";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.ForeColor = System.Drawing.Color.Red;
            this.groupBox5.Location = new System.Drawing.Point(6, 156);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(196, 100);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "До сплати";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(163, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "грн.";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(6, 34);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(151, 37);
            this.label6.TabIndex = 1;
            this.label6.Text = "0";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbHotDogCost
            // 
            this.tbHotDogCost.Enabled = false;
            this.tbHotDogCost.Location = new System.Drawing.Point(98, 34);
            this.tbHotDogCost.Name = "tbHotDogCost";
            this.tbHotDogCost.Size = new System.Drawing.Size(49, 20);
            this.tbHotDogCost.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(108, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Ціна";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.button1);
            this.groupBox6.ForeColor = System.Drawing.Color.Red;
            this.groupBox6.Location = new System.Drawing.Point(12, 323);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(426, 100);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Всього до сплати";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.Location = new System.Drawing.Point(391, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "грн.";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(216, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(169, 37);
            this.label10.TabIndex = 4;
            this.label10.Text = "0";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(24, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 66);
            this.button1.TabIndex = 0;
            this.button1.Text = "Прорахувати";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Green;
            this.label11.Location = new System.Drawing.Point(12, 430);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Всього за зміну:";
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.Green;
            this.label12.Location = new System.Drawing.Point(184, 426);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(254, 17);
            this.label12.TabIndex = 4;
            this.label12.Text = "0";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "BestOil";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton rbSum;
        private System.Windows.Forms.RadioButton rbCount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbCocaCola;
        private System.Windows.Forms.TextBox tbCocaColaCount;
        private System.Windows.Forms.TextBox tbCocaColaCost;
        private System.Windows.Forms.CheckBox cbFries;
        private System.Windows.Forms.TextBox tbFriesCount;
        private System.Windows.Forms.TextBox tbFriesCost;
        private System.Windows.Forms.CheckBox cbHamburger;
        private System.Windows.Forms.TextBox tbHamburgerCount;
        private System.Windows.Forms.TextBox tbHamburgerCost;
        private System.Windows.Forms.CheckBox cbHotDog;
        private System.Windows.Forms.TextBox tbHotDogCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbHotDogCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

