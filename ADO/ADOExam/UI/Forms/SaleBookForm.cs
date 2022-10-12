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
    public partial class SaleBookForm : Form
    {
        BookService bookService = new BookService();
        UserService userService = new UserService();
        public SaleDTO sale { get; set; } = new SaleDTO();
        public SaleBookForm()
        {

            InitializeComponent();
            var books = bookService.GetAll();
            cbBookList.DataSource = books;
            cbBookList.DisplayMember = "Name";
            cbBookList.ValueMember = "Id";
            var users = userService.GetAll();
            cbUserList.DataSource = users;
            cbUserList.DisplayMember = "LastName";
            cbUserList.ValueMember = "Id";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            sale.Book = bookService.GetById((int)cbBookList.SelectedValue);
            sale.BookId = (int?)cbBookList.SelectedValue;
            sale.Count = (int)nudSaleCount.Value;
            sale.User = userService.GetById((int)cbUserList.SelectedValue);
            sale.UserId = (int?)cbUserList.SelectedValue;
            this.DialogResult = DialogResult.OK;
        }
    }
}
