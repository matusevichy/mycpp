using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class AuthForm : Form
    {
        public AccountDTO Account { get; set; }
        public AuthForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            AccountService accountService = new AccountService();
            var account = accountService.Auth(tbLogin.Text, tbPassword.Text);
            if(account != null)
            {
                Account = account;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Login or password incorrect", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
