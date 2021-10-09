using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    [Table(Name ="Books"), Serializable]
    public class Book
    {
        private EntityRef<Genre> genre;
        private EntitySet<Author2Book> authors;
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string Title { get; set; }
        [Column]
        public int Pages { get; set; }
        [Column]
        public string Description { get; set; }
        [Column]
        public int GenreId { get; set; }
        [Association(Name = "FK__Books__genreid__49C3F6B7", IsForeignKey = true, Storage = "genre", ThisKey = "GenreId", OtherKey = "Id")]
        public Genre Genre
        {
            get
            {
                return this.genre.Entity;
            }
            set
            {
                this.genre.Entity = value;
            }
        }
        [Column]
        public int InStock { get; set; }
        [Association(Storage ="authors", ThisKey ="Id", OtherKey ="BookId")]
        public EntitySet<Author2Book> Authors
        {
            get { return authors; }
            set { authors = value; }
        }
        public Book Clone()
        {
            //using (MemoryStream stream = new MemoryStream())
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    var oldBook = this;
            //    formatter.Serialize(stream, oldBook);
            //    stream.Position = 0;
            //    var book = (Book)formatter.Deserialize(stream);
            //    return book;
            //}
            var book = (Book)this.MemberwiseClone();
            book.Genre = new Genre(this.Genre);
            book.Authors = new EntitySet<Author2Book>();
            this.Authors.ToList().ForEach(i => book.Authors.Add(new Author2Book(i)));
            return book;
        }
    }
}
