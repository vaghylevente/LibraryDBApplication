using FDU7VL_HFT_2021221.Data;
using FDU7VL_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDU7VL_HFT_2021221.Repository
{
    public class BookRepository : IBookRepository
    {
        LibraryDbContext db;

        public BookRepository(LibraryDbContext db)
        {
            this.db = db;
        }

        public void Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public Book Read(int id)
        {
            return db.Books.FirstOrDefault(x => x.BookID == id);
        }
        public IQueryable<Book> ReadAll()
        {
            return db.Books;
        }

        public void Update(Book book)
        {
            var oldBook = Read(book.BookID);
            oldBook.Title = book.Title;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        
    }
}
