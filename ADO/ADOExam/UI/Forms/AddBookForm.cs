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
    public partial class AddBookForm : Form
    {
        public BookDTO book;
        AuthorService authorService = new AuthorService();
        BookService bookService = new BookService();
        GenreService genreService = new GenreService();
        CreatorService creatorService = new CreatorService();
        public AddBookForm(BookDTO book)
        {
            this.book = book;
            InitializeComponent();
            var authors = authorService.GetAll();
            var creators = creatorService.GetAll();
            var books = bookService.GetAll();
            var genres = genreService.GetAll();
            cbAuthor.DataSource = authors;
            cbAuthor.DisplayMember = "LastName";
            cbAuthor.ValueMember = "Id";
            cbCreator.DataSource = creators;
            cbCreator.DisplayMember = "Name";
            cbCreator.ValueMember = "Id";
            cbPrevBook.DataSource = books;
            cbPrevBook.DisplayMember = "Name";
            cbPrevBook.ValueMember = "Id";
            cbGenre.DataSource = genres;
            cbGenre.DisplayMember = "Name";
            cbGenre.ValueMember = "Id";
            if (book.PrevBookId != null) cbPrevBook.SelectedValue = book.PrevBookId; else cbPrevBook.SelectedIndex = -1;
            if (book.CreatorId != null) cbCreator.SelectedValue = book.CreatorId; else cbCreator.SelectedIndex = -1;
            if (book.AuthorId != null) cbAuthor.SelectedValue = book.AuthorId; else cbAuthor.SelectedIndex = -1;
            if (book.GenreId != null) cbGenre.SelectedValue = book.GenreId; else cbGenre.SelectedIndex = -1;
            nudBasePrice.Value = (decimal)book.BasePrice;
            nudPrice.Value = (decimal)book.Price;
            tbName.Text = book.Name;
            dtpDateCreate.Value = book.DateCreate;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "" || cbAuthor.SelectedIndex == -1 || cbGenre.SelectedIndex == -1 || cbCreator.SelectedIndex == -1)
            {
                MessageBox.Show("Fill all fields!!!");
            }
            else
            {
                book.Name = tbName.Text;
                book.Author = authorService.GetById((int)cbAuthor.SelectedValue);
                book.AuthorId = (int)cbAuthor.SelectedValue;
                book.Creator = creatorService.GetById((int)cbCreator.SelectedValue);
                book.CreatorId = (int)cbCreator.SelectedValue;
                book.Genre = genreService.GetById((int)cbGenre.SelectedValue);
                book.GenreId = (int)cbGenre.SelectedValue;
                try
                {
                    book.PrevBook = bookService.GetById((int)cbPrevBook.SelectedValue);
                    book.PrevBookId = (int)cbPrevBook.SelectedValue;
                }
                catch { }
                book.BasePrice = (double)nudBasePrice.Value;
                book.Price = (double)nudPrice.Value;
                book.DateCreate = dtpDateCreate.Value;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
