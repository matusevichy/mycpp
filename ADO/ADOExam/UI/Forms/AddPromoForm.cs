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
    public partial class AddPromoForm : Form
    {
        BookService bookService = new BookService();
        public bool IsAdmin { get; set; }
        public PromoDTO Promo { get; set; }
        public AddPromoForm(PromoDTO promo)
        {
            this.Promo = promo;
            InitializeComponent();
            tbName.Text = promo.Name;
            dtpDateBegin.Value = promo.DateBegin;
            dtpDateBegin.Value = promo.DateEnd;
            var books = bookService.GetAll().ToArray();
            clbBookList.Items.Clear();
            clbBookList.Items.AddRange(books);
            if (promo.Books.Count() > 0)
            {
                foreach (var book in promo.Books)
                {
                    var i = -1;
                    var book1 = clbBookList.Items[0];
                    if ((i = clbBookList.Items.IndexOf(book)) != -1)
                    {
                        clbBookList.SetItemChecked(i, true);
                    }
                }
            }
            this.Load += AddPromoForm_Load;
        }

        private void AddPromoForm_Load(object sender, EventArgs e)
        {
            tbName.Enabled = dtpDateBegin.Enabled = dtpDateEnd.Enabled = clbBookList.Enabled = IsAdmin;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Promo.Books = clbBookList.CheckedItems.OfType<BookDTO>().ToList();
            Promo.DateBegin = dtpDateBegin.Value;
            Promo.DateEnd = dtpDateEnd.Value;
            Promo.Name = tbName.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
