using BLL.DTO;
using BLL.Services;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.Forms;

namespace UI
{
    public partial class MainForm : Form
    {
        List<BookDTO> Books;
        AuthorService authorService = new AuthorService();
        BookService bookService = new BookService();
        GenreService genreService = new GenreService();

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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void lbDateCreate_Click(object sender, EventArgs e)
        {

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
    }
}
