namespace Less2_cw
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.lvMessageList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgvMessages = new System.Windows.Forms.DataGridView();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tbBody = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFrom = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessages)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(556, 29);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(12, 497);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(1069, 142);
            this.tbLog.TabIndex = 1;
            this.tbLog.TextChanged += new System.EventHandler(this.tbLog_TextChanged);
            // 
            // lvMessageList
            // 
            this.lvMessageList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvMessageList.FullRowSelect = true;
            this.lvMessageList.Location = new System.Drawing.Point(12, 58);
            this.lvMessageList.MultiSelect = false;
            this.lvMessageList.Name = "lvMessageList";
            this.lvMessageList.Size = new System.Drawing.Size(538, 226);
            this.lvMessageList.TabIndex = 2;
            this.lvMessageList.UseCompatibleStateImageBehavior = false;
            this.lvMessageList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Subject";
            this.columnHeader2.Width = 206;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "From";
            this.columnHeader3.Width = 134;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Date";
            this.columnHeader4.Width = 134;
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(196, 29);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(170, 23);
            this.tbUser.TabIndex = 4;
            this.tbUser.Text = "yura";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(380, 29);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(170, 23);
            this.tbPassword.TabIndex = 6;
            this.tbPassword.Text = "12345";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Host";
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(12, 29);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(170, 23);
            this.tbHost.TabIndex = 8;
            this.tbHost.Text = "localhost";
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dgvMessages
            // 
            this.dgvMessages.AllowUserToAddRows = false;
            this.dgvMessages.AllowUserToDeleteRows = false;
            this.dgvMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMessages.Location = new System.Drawing.Point(12, 58);
            this.dgvMessages.Name = "dgvMessages";
            this.dgvMessages.ReadOnly = true;
            this.dgvMessages.RowTemplate.Height = 25;
            this.dgvMessages.Size = new System.Drawing.Size(538, 226);
            this.dgvMessages.TabIndex = 10;
            this.dgvMessages.SelectionChanged += new System.EventHandler(this.dgvMessages_SelectionChanged);
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(12, 290);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMessage.Size = new System.Drawing.Size(538, 201);
            this.tbMessage.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "* From:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tbBody);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbSubject);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbTo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbFrom);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(556, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 433);
            this.panel1.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(210, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Send message";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbBody
            // 
            this.tbBody.Location = new System.Drawing.Point(54, 94);
            this.tbBody.Multiline = true;
            this.tbBody.Name = "tbBody";
            this.tbBody.Size = new System.Drawing.Size(466, 298);
            this.tbBody.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Body:";
            // 
            // tbSubject
            // 
            this.tbSubject.Location = new System.Drawing.Point(54, 65);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(466, 23);
            this.tbSubject.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Subject:";
            // 
            // tbTo
            // 
            this.tbTo.Location = new System.Drawing.Point(54, 36);
            this.tbTo.Name = "tbTo";
            this.tbTo.Size = new System.Drawing.Size(466, 23);
            this.tbTo.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "* To:";
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(54, 7);
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.Size = new System.Drawing.Size(466, 23);
            this.tbFrom.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 651);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvMessages);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbHost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.lvMessageList);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMessages)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnConnect;
        private TextBox tbLog;
        private ListView lvMessageList;
        private TextBox tbUser;
        private Label label1;
        private Label label2;
        private TextBox tbPassword;
        private Label label3;
        private TextBox tbHost;
        private System.Windows.Forms.Timer timer1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private DataGridView dgvMessages;
        private TextBox tbMessage;
        private Label label4;
        private Panel panel1;
        private TextBox tbSubject;
        private Label label6;
        private TextBox tbTo;
        private Label label5;
        private TextBox tbFrom;
        private TextBox tbBody;
        private Label label7;
        private Button button1;
    }
}