using FDU7VL_HFT_2021221.Models;
using FDU7VL_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDU7VL_HFT_2021221.Logic
{
    public class BookLogic : IBookLogic
    {
        IBookRepository repo;
        public BookLogic(IBookRepository bookRepository)
        {
            repo = bookRepository;
        }
        public void Create(Book book)
        {
            if (book.Title == null || book.Title == "")
            {
                throw new ArgumentException("The book has to have a title!");
            }
            if (book.Author == null || book.Author == "")
            {
                book.Author = "unknown";
                repo.Create(book);
            }
            else
            {
                repo.Create(book);
            }
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Book Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Book> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Book book)
        {
            repo.Update(book);
        }
    }
}
