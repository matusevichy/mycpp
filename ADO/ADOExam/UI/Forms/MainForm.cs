using BLL.DTO;
using BLL.Services;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class MainForm : Form
    {
        List<BookDTO> Books;
        List<SaleDTO> Sales;
        AuthorService authorService = new AuthorService();
        BookService bookService = new BookService();
        GenreService genreService = new GenreService();
        SaleService saleService = new SaleService();
        PromoService promoService = new PromoService();
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
                Books = bookService.GetAll();
                lbBooksList.DataSource = Books;
                if (Account.IsAdmin)
                {
                    btnAddBook.Enabled = btnEditBook.Enabled = btnRemoveBook.Enabled = btnSaleBook.Enabled = true;
                }
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
            PromoService promoService = new PromoService();
            var promos = promoService.GetAll();
            ;
        }

        private void CloseOnStart(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbBooksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = lbBooksList.SelectedItem as BookDTO;
            lbName.Text = selected?.Name;
            lbAuthor.Text = selected?.Author.ToString();
            lbGenre.Text = selected?.Genre.Name;
            lbCreator.Text = selected?.Creator.Name;
            lbDateCreate.Text = selected?.DateCreate.ToString();
            lbBasePrice.Text = selected?.BasePrice.ToString();
            lbPrice.Text = selected?.Price.ToString();
            lbPrevBook.Text = selected?.PrevBook?.ToString();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            lbBooksList.DataSource = null;
            if (rbByName.Checked) lbBooksList.DataSource = Books.FindAll(b => b.Name.ToLower().Contains(tbFind.Text.ToLower()));
            else if(rbByAuthor.Checked)
            {
                lbBooksList.DataSource = Books.FindAll(b => b.Author.FirstName.ToLower().Contains(tbFind.Text.ToLower())||b.Author.LastName.ToLower().Contains(tbFind.Text.ToLower()) ||b.Author.MiddleName.ToLower().Contains(tbFind.Text.ToLower()));
            }
            else if (rbByGenre.Checked)
            {
                lbBooksList.DataSource = Books.FindAll(b => b.Genre.Name.ToLower().Contains(tbFind.Text.ToLower()));
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            lbBooksList.DataSource = null;
            string offset = "";
            if (rbOfDay.Checked) offset = "day";
            else if (rbOfWeek.Checked) offset = "week";
            else if (rbOfMonth.Checked) offset = "month";
            else if (rbOfYear.Checked) offset = "year";
            if (rbLatest.Checked)
            {
                lbBooksList.DataSource = bookService.GetLatest(offset);
            }
            else if (rbMostSales.Checked)
            {
                var bookIds = saleService.GetMostPopularBooks(offset);
                lbBooksList.DataSource = bookService.GetBooksOfListBookId(bookIds);
            }
            else if (rbMostPopularAuthor.Checked)
            {
                var id = saleService.GetMostPopularAuthorId(offset);
                lbBooksList.DataSource = bookService.GetBooksByAuthorId(id);
            }
            else if (rbMostPopularGenre.Checked)
            {
                var id = saleService.GetMostPopularGenreId(offset);
                lbBooksList.DataSource = bookService.GetBooksByGenreId(id);
            }
        }

        private void btnRemoveBook_Click(object sender, EventArgs e)
        {
            //Books.RemoveAt(lbBooksList.SelectedIndex);
            bookService.Delete(lbBooksList.SelectedIndex);
            lbBooksList.DataSource = null;
            lbBooksList.DataSource = Books;
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            using (AddBookForm addForm = new AddBookForm(new BookDTO()))
            {
                addForm.ShowDialog();
                if (addForm.DialogResult == DialogResult.OK)
                {
                    Books.Add(addForm.book);
                    lbBooksList.DataSource = null;
                    lbBooksList.DataSource = Books;
                }

            }
        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            var book = new BookDTO();
            book = Books[lbBooksList.SelectedIndex];
            using (AddBookForm addForm = new AddBookForm(book))
            {
                addForm.ShowDialog();
                if (addForm.DialogResult == DialogResult.OK)
                {
                    Books[lbBooksList.SelectedIndex] = book;
                    lbBooksList.DataSource = null;
                    lbBooksList.DataSource = Books;
                }
            }
        }

        private void btnSaleBook_Click(object sender, EventArgs e)
        {            
            using(SaleBookForm saleBookForm = new SaleBookForm())
            {
                saleBookForm.ShowDialog();
                if (saleBookForm.DialogResult == DialogResult.OK)
                {
                    var sale = new SaleDTO();
                    sale = saleBookForm.sale;
                    saleService.Create(sale);
                }
            }
        }

        private void btnSaleInfo_Click(object sender, EventArgs e)
        {
            using (SaleInfoForm saleInfoForm = new SaleInfoForm())
            {
                saleInfoForm.ShowDialog();
            }
        }

        private void btnAddPromo_Click(object sender, EventArgs e)
        {
            PromoDTO promo = new PromoDTO();
            using (AddPromoForm addPromoForm = new AddPromoForm(promo))
            {
                addPromoForm.ShowDialog();
                if (addPromoForm.DialogResult == DialogResult.OK)
                {
                    promo = addPromoForm.Promo;
                    promoService.Create(promo);
                }
            }
        }

        private void btnPromoList_Click(object sender, EventArgs e)
        {
            using (PromoListForm promoListForm = new PromoListForm())
            {
                promoListForm.isAdmin = this.Account.IsAdmin;
                promoListForm.ShowDialog();
            }
        }
    }
}
