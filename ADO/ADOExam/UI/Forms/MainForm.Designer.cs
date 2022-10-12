
namespace UI.Forms
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.книгиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pMainBook = new System.Windows.Forms.Panel();
            this.btnEditBook = new System.Windows.Forms.Button();
            this.btnRemoveBook = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbOfYear = new System.Windows.Forms.RadioButton();
            this.rbOfMonth = new System.Windows.Forms.RadioButton();
            this.rbOfWeek = new System.Windows.Forms.RadioButton();
            this.rbOfDay = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbMostPopularGenre = new System.Windows.Forms.RadioButton();
            this.rbMostPopularAuthor = new System.Windows.Forms.RadioButton();
            this.rbMostSales = new System.Windows.Forms.RadioButton();
            this.rbLatest = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFind = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbByGenre = new System.Windows.Forms.RadioButton();
            this.rbByAuthor = new System.Windows.Forms.RadioButton();
            this.rbByName = new System.Windows.Forms.RadioButton();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbPrevBook = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbBasePrice = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbDateCreate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbCreator = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbGenre = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbAuthor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbBooksList = new System.Windows.Forms.ListBox();
            this.btnSaleBook = new System.Windows.Forms.Button();
            this.btnSaleList = new System.Windows.Forms.Button();
            this.btnAddPromo = new System.Windows.Forms.Button();
            this.btnPromoList = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.pMainBook.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.книгиToolStripMenuItem,
            this.справочникиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1180, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // книгиToolStripMenuItem
            // 
            this.книгиToolStripMenuItem.Name = "книгиToolStripMenuItem";
            this.книгиToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.книгиToolStripMenuItem.Text = "Книги";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // pMainBook
            // 
            this.pMainBook.Controls.Add(this.btnPromoList);
            this.pMainBook.Controls.Add(this.btnAddPromo);
            this.pMainBook.Controls.Add(this.btnSaleList);
            this.pMainBook.Controls.Add(this.btnSaleBook);
            this.pMainBook.Controls.Add(this.btnEditBook);
            this.pMainBook.Controls.Add(this.btnRemoveBook);
            this.pMainBook.Controls.Add(this.btnAddBook);
            this.pMainBook.Controls.Add(this.groupBox2);
            this.pMainBook.Controls.Add(this.panel2);
            this.pMainBook.Controls.Add(this.panel1);
            this.pMainBook.Controls.Add(this.lbBooksList);
            this.pMainBook.Location = new System.Drawing.Point(0, 27);
            this.pMainBook.Name = "pMainBook";
            this.pMainBook.Size = new System.Drawing.Size(1178, 601);
            this.pMainBook.TabIndex = 2;
            // 
            // btnEditBook
            // 
            this.btnEditBook.Enabled = false;
            this.btnEditBook.Location = new System.Drawing.Point(718, 175);
            this.btnEditBook.Name = "btnEditBook";
            this.btnEditBook.Size = new System.Drawing.Size(75, 23);
            this.btnEditBook.TabIndex = 6;
            this.btnEditBook.Text = "Edit book";
            this.btnEditBook.UseVisualStyleBackColor = true;
            this.btnEditBook.Click += new System.EventHandler(this.btnEditBook_Click);
            // 
            // btnRemoveBook
            // 
            this.btnRemoveBook.Enabled = false;
            this.btnRemoveBook.Location = new System.Drawing.Point(799, 175);
            this.btnRemoveBook.Name = "btnRemoveBook";
            this.btnRemoveBook.Size = new System.Drawing.Size(84, 23);
            this.btnRemoveBook.TabIndex = 5;
            this.btnRemoveBook.Text = "Remove book";
            this.btnRemoveBook.UseVisualStyleBackColor = true;
            this.btnRemoveBook.Click += new System.EventHandler(this.btnRemoveBook_Click);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Enabled = false;
            this.btnAddBook.Location = new System.Drawing.Point(637, 175);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(75, 23);
            this.btnAddBook.TabIndex = 4;
            this.btnAddBook.Text = "Add book";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFilter);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(873, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 163);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter books by";
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFilter.Location = new System.Drawing.Point(117, 124);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbOfYear);
            this.groupBox4.Controls.Add(this.rbOfMonth);
            this.groupBox4.Controls.Add(this.rbOfWeek);
            this.groupBox4.Controls.Add(this.rbOfDay);
            this.groupBox4.Location = new System.Drawing.Point(155, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(146, 102);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // rbOfYear
            // 
            this.rbOfYear.AutoSize = true;
            this.rbOfYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbOfYear.Location = new System.Drawing.Point(6, 78);
            this.rbOfYear.Name = "rbOfYear";
            this.rbOfYear.Size = new System.Drawing.Size(57, 17);
            this.rbOfYear.TabIndex = 3;
            this.rbOfYear.TabStop = true;
            this.rbOfYear.Text = "of year";
            this.rbOfYear.UseVisualStyleBackColor = true;
            // 
            // rbOfMonth
            // 
            this.rbOfMonth.AutoSize = true;
            this.rbOfMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbOfMonth.Location = new System.Drawing.Point(6, 55);
            this.rbOfMonth.Name = "rbOfMonth";
            this.rbOfMonth.Size = new System.Drawing.Size(66, 17);
            this.rbOfMonth.TabIndex = 2;
            this.rbOfMonth.TabStop = true;
            this.rbOfMonth.Text = "of month";
            this.rbOfMonth.UseVisualStyleBackColor = true;
            // 
            // rbOfWeek
            // 
            this.rbOfWeek.AutoSize = true;
            this.rbOfWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbOfWeek.Location = new System.Drawing.Point(6, 32);
            this.rbOfWeek.Name = "rbOfWeek";
            this.rbOfWeek.Size = new System.Drawing.Size(63, 17);
            this.rbOfWeek.TabIndex = 1;
            this.rbOfWeek.TabStop = true;
            this.rbOfWeek.Text = "of week";
            this.rbOfWeek.UseVisualStyleBackColor = true;
            // 
            // rbOfDay
            // 
            this.rbOfDay.AutoSize = true;
            this.rbOfDay.Checked = true;
            this.rbOfDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbOfDay.Location = new System.Drawing.Point(6, 9);
            this.rbOfDay.Name = "rbOfDay";
            this.rbOfDay.Size = new System.Drawing.Size(54, 17);
            this.rbOfDay.TabIndex = 0;
            this.rbOfDay.TabStop = true;
            this.rbOfDay.Text = "of day";
            this.rbOfDay.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbMostPopularGenre);
            this.groupBox3.Controls.Add(this.rbMostPopularAuthor);
            this.groupBox3.Controls.Add(this.rbMostSales);
            this.groupBox3.Controls.Add(this.rbLatest);
            this.groupBox3.Location = new System.Drawing.Point(6, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(146, 102);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // rbMostPopularGenre
            // 
            this.rbMostPopularGenre.AutoSize = true;
            this.rbMostPopularGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbMostPopularGenre.Location = new System.Drawing.Point(6, 78);
            this.rbMostPopularGenre.Name = "rbMostPopularGenre";
            this.rbMostPopularGenre.Size = new System.Drawing.Size(115, 17);
            this.rbMostPopularGenre.TabIndex = 3;
            this.rbMostPopularGenre.TabStop = true;
            this.rbMostPopularGenre.Text = "most popular genre";
            this.rbMostPopularGenre.UseVisualStyleBackColor = true;
            // 
            // rbMostPopularAuthor
            // 
            this.rbMostPopularAuthor.AutoSize = true;
            this.rbMostPopularAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbMostPopularAuthor.Location = new System.Drawing.Point(6, 55);
            this.rbMostPopularAuthor.Name = "rbMostPopularAuthor";
            this.rbMostPopularAuthor.Size = new System.Drawing.Size(118, 17);
            this.rbMostPopularAuthor.TabIndex = 2;
            this.rbMostPopularAuthor.TabStop = true;
            this.rbMostPopularAuthor.Text = "most popular author";
            this.rbMostPopularAuthor.UseVisualStyleBackColor = true;
            // 
            // rbMostSales
            // 
            this.rbMostSales.AutoSize = true;
            this.rbMostSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbMostSales.Location = new System.Drawing.Point(6, 32);
            this.rbMostSales.Name = "rbMostSales";
            this.rbMostSales.Size = new System.Drawing.Size(74, 17);
            this.rbMostSales.TabIndex = 1;
            this.rbMostSales.TabStop = true;
            this.rbMostSales.Text = "most sales";
            this.rbMostSales.UseVisualStyleBackColor = true;
            // 
            // rbLatest
            // 
            this.rbLatest.AutoSize = true;
            this.rbLatest.Checked = true;
            this.rbLatest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbLatest.Location = new System.Drawing.Point(6, 9);
            this.rbLatest.Name = "rbLatest";
            this.rbLatest.Size = new System.Drawing.Size(50, 17);
            this.rbLatest.TabIndex = 0;
            this.rbLatest.TabStop = true;
            this.rbLatest.Text = "latest";
            this.rbLatest.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnFind);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.tbFind);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(637, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 162);
            this.panel2.TabIndex = 2;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(84, 123);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbByGenre);
            this.groupBox1.Controls.Add(this.rbByAuthor);
            this.groupBox1.Controls.Add(this.rbByName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(6, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 58);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find by";
            // 
            // rbByGenre
            // 
            this.rbByGenre.AutoSize = true;
            this.rbByGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbByGenre.Location = new System.Drawing.Point(157, 18);
            this.rbByGenre.Name = "rbByGenre";
            this.rbByGenre.Size = new System.Drawing.Size(54, 17);
            this.rbByGenre.TabIndex = 2;
            this.rbByGenre.Text = "Genre";
            this.rbByGenre.UseVisualStyleBackColor = true;
            // 
            // rbByAuthor
            // 
            this.rbByAuthor.AutoSize = true;
            this.rbByAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbByAuthor.Location = new System.Drawing.Point(78, 18);
            this.rbByAuthor.Name = "rbByAuthor";
            this.rbByAuthor.Size = new System.Drawing.Size(56, 17);
            this.rbByAuthor.TabIndex = 1;
            this.rbByAuthor.Text = "Author";
            this.rbByAuthor.UseVisualStyleBackColor = true;
            // 
            // rbByName
            // 
            this.rbByName.AutoSize = true;
            this.rbByName.Checked = true;
            this.rbByName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbByName.Location = new System.Drawing.Point(6, 18);
            this.rbByName.Name = "rbByName";
            this.rbByName.Size = new System.Drawing.Size(53, 17);
            this.rbByName.TabIndex = 0;
            this.rbByName.TabStop = true;
            this.rbByName.Text = "Name";
            this.rbByName.UseVisualStyleBackColor = true;
            // 
            // tbFind
            // 
            this.tbFind.Location = new System.Drawing.Point(6, 31);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(216, 20);
            this.tbFind.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Find books";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbPrevBook);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lbPrice);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbBasePrice);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lbDateCreate);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lbCreator);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lbGenre);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbAuthor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(322, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 394);
            this.panel1.TabIndex = 1;
            // 
            // lbPrevBook
            // 
            this.lbPrevBook.AutoSize = true;
            this.lbPrevBook.Location = new System.Drawing.Point(3, 357);
            this.lbPrevBook.Name = "lbPrevBook";
            this.lbPrevBook.Size = new System.Drawing.Size(0, 13);
            this.lbPrevBook.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 335);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Prev. Book";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(3, 311);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(0, 13);
            this.lbPrice.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Price";
            // 
            // lbBasePrice
            // 
            this.lbBasePrice.AutoSize = true;
            this.lbBasePrice.Location = new System.Drawing.Point(3, 265);
            this.lbBasePrice.Name = "lbBasePrice";
            this.lbBasePrice.Size = new System.Drawing.Size(0, 13);
            this.lbBasePrice.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(3, 243);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Base Price";
            // 
            // lbDateCreate
            // 
            this.lbDateCreate.AutoSize = true;
            this.lbDateCreate.Location = new System.Drawing.Point(3, 216);
            this.lbDateCreate.Name = "lbDateCreate";
            this.lbDateCreate.Size = new System.Drawing.Size(0, 13);
            this.lbDateCreate.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(3, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "DateCreate";
            // 
            // lbCreator
            // 
            this.lbCreator.AutoSize = true;
            this.lbCreator.Location = new System.Drawing.Point(3, 171);
            this.lbCreator.Name = "lbCreator";
            this.lbCreator.Size = new System.Drawing.Size(0, 13);
            this.lbCreator.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(3, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Creator";
            // 
            // lbGenre
            // 
            this.lbGenre.AutoSize = true;
            this.lbGenre.Location = new System.Drawing.Point(3, 123);
            this.lbGenre.Name = "lbGenre";
            this.lbGenre.Size = new System.Drawing.Size(0, 13);
            this.lbGenre.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Genre";
            // 
            // lbAuthor
            // 
            this.lbAuthor.AutoSize = true;
            this.lbAuthor.Location = new System.Drawing.Point(3, 78);
            this.lbAuthor.Name = "lbAuthor";
            this.lbAuthor.Size = new System.Drawing.Size(0, 13);
            this.lbAuthor.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Author";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(3, 34);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(0, 13);
            this.lbName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // lbBooksList
            // 
            this.lbBooksList.FormattingEnabled = true;
            this.lbBooksList.Location = new System.Drawing.Point(3, 3);
            this.lbBooksList.Name = "lbBooksList";
            this.lbBooksList.Size = new System.Drawing.Size(313, 589);
            this.lbBooksList.TabIndex = 0;
            this.lbBooksList.SelectedIndexChanged += new System.EventHandler(this.lbBooksList_SelectedIndexChanged);
            // 
            // btnSaleBook
            // 
            this.btnSaleBook.Enabled = false;
            this.btnSaleBook.Location = new System.Drawing.Point(637, 204);
            this.btnSaleBook.Name = "btnSaleBook";
            this.btnSaleBook.Size = new System.Drawing.Size(75, 23);
            this.btnSaleBook.TabIndex = 7;
            this.btnSaleBook.Text = "Sale book";
            this.btnSaleBook.UseVisualStyleBackColor = true;
            this.btnSaleBook.Click += new System.EventHandler(this.btnSaleBook_Click);
            // 
            // btnSaleList
            // 
            this.btnSaleList.Location = new System.Drawing.Point(718, 204);
            this.btnSaleList.Name = "btnSaleList";
            this.btnSaleList.Size = new System.Drawing.Size(75, 23);
            this.btnSaleList.TabIndex = 8;
            this.btnSaleList.Text = "Sale list";
            this.btnSaleList.UseVisualStyleBackColor = true;
            this.btnSaleList.Click += new System.EventHandler(this.btnSaleInfo_Click);
            // 
            // btnAddPromo
            // 
            this.btnAddPromo.Location = new System.Drawing.Point(637, 233);
            this.btnAddPromo.Name = "btnAddPromo";
            this.btnAddPromo.Size = new System.Drawing.Size(75, 23);
            this.btnAddPromo.TabIndex = 9;
            this.btnAddPromo.Text = "Add promo";
            this.btnAddPromo.UseVisualStyleBackColor = true;
            this.btnAddPromo.Click += new System.EventHandler(this.btnAddPromo_Click);
            // 
            // btnPromoList
            // 
            this.btnPromoList.Location = new System.Drawing.Point(718, 233);
            this.btnPromoList.Name = "btnPromoList";
            this.btnPromoList.Size = new System.Drawing.Size(75, 23);
            this.btnPromoList.TabIndex = 10;
            this.btnPromoList.Text = "Promo list";
            this.btnPromoList.UseVisualStyleBackColor = true;
            this.btnPromoList.Click += new System.EventHandler(this.btnPromoList_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 629);
            this.Controls.Add(this.pMainBook);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pMainBook.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem книгиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.Panel pMainBook;
        private System.Windows.Forms.ListBox lbBooksList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbGenre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbAuthor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbBasePrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbDateCreate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbCreator;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbPrevBook;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbByGenre;
        private System.Windows.Forms.RadioButton rbByAuthor;
        private System.Windows.Forms.RadioButton rbByName;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbOfYear;
        private System.Windows.Forms.RadioButton rbOfMonth;
        private System.Windows.Forms.RadioButton rbOfWeek;
        private System.Windows.Forms.RadioButton rbOfDay;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbMostPopularGenre;
        private System.Windows.Forms.RadioButton rbMostPopularAuthor;
        private System.Windows.Forms.RadioButton rbMostSales;
        private System.Windows.Forms.RadioButton rbLatest;
        private System.Windows.Forms.Button btnEditBook;
        private System.Windows.Forms.Button btnRemoveBook;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnSaleBook;
        private System.Windows.Forms.Button btnSaleList;
        private System.Windows.Forms.Button btnAddPromo;
        private System.Windows.Forms.Button btnPromoList;
    }
}

