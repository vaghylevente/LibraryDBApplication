﻿using FDU7VL_HFT_2021221.Models;
using FDU7VL_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDU7VL_HFT_2021221.Logic
{
    public class BorrowingLogic : IBorrowingLogic
    {
        IBorrowingRepository repo;
        public BorrowingLogic(IBorrowingRepository borrowingRepository)
        {
            repo = borrowingRepository;
        }
        public void Create(Borrowing borrowing)
        {
            repo.Create(borrowing);
        }

        public Borrowing Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Borrowing> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Borrowing borrowing)
        {
            repo.Update(borrowing);
        }
        public void Delete(int id)
        {
            repo.Delete(id);
        }
        //non-crud
        public Book MostPopularBook()
        {
            var query = (from x in ReadAll()
                         group x by x.Book into g
                         orderby g.Count() descending
                         select g.Key).FirstOrDefault();
            return query;

        }
        public Student FirstBorrowing()
        {
            var query = (from x in ReadAll()
                         orderby x.Date
                         select x.Student).FirstOrDefault();
            return query;
        }
        public Student BiggestBorrower()
        {
            var query = (from x in ReadAll()
                         group x by x.Student into g
                         orderby g.Count() descending
                         select g.Key).FirstOrDefault();
            return query;
        }
        public IEnumerable<KeyValuePair<Book, int>> BorrowingPerBook()
        {
            var query = from x in ReadAll()
                        group x by x.Book into g
                        select new KeyValuePair<Book, int>(
                            g.Key, 
                            g.Count()
                        );
            return query;
        }
        public IEnumerable<Book> BooksBorrowedBy(Student student)
        {
            var query = from x in ReadAll()
                        where x.StudentID == student.StudentID
                        select x.Book;
            return query;

        }
    }
}
