using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    [Serializable]
    [Table(Name = "Author2Book")]
    public class Author2Book
    {
        private EntityRef<Author> author;

        public Author2Book()
        {
        }

        public Author2Book(Author2Book authors)
        {
            AuthorId = authors.AuthorId;
            BookId = authors.BookId;
            Author = authors.Author;
            this.author = authors.author;
        }

        [Column(IsPrimaryKey =true)]
        public int AuthorId { get; set; }
        [Column(IsPrimaryKey = true)]
        public int BookId { get; set; }
        [Association(IsForeignKey = true, ThisKey = "AuthorId", OtherKey = "Id", Storage = "author")]
        public Author Author
        {
            get
            {
                return this.author.Entity;
            }
            set
            {
                author.Entity = value;
            }
        }
    }
}
