using BLL.DTO;
using BLL.Services;
using System;
using System.Windows.Forms;
using UI.Forms;

namespace UI
{
    public partial class MainForm : Form
    {
        public AccountDTO Account { get; set; }
        public MainForm()
        {
            AuthForm authForm = new AuthForm();
            authForm.ShowDialog();
            if (authForm.DialogResult == DialogResult.OK)
            {
                Account = authForm.Account;
                InitializeComponent();
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.Load += new EventHandler(CloseOnStart);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccountService accountService = new AccountService();
            var res = accountService.GetById(1);
            BookService bookService = new BookService();
            var books = bookService.GetAll();
            PromoService promoService = new PromoService();
            var promos = promoService.GetAll();
            ;
        }

        private void CloseOnStart(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
