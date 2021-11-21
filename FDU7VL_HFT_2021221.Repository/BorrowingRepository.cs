using FDU7VL_HFT_2021221.Data;
using FDU7VL_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDU7VL_HFT_2021221.Repository
{
    public class BorrowingRepository : IBorrowingRepository
    {
        LibraryDbContext db;
        public BorrowingRepository(LibraryDbContext db)
        {
            this.db = db;
        }

        public void Create(Borrowing borrowing)
        {
            db.Borrowings.Add(borrowing);
            db.SaveChanges();
        }
        public Borrowing Read(int id)
        {
            return db.Borrowings.FirstOrDefault(x => x.BorrowingID == id);
        }
        public IQueryable<Borrowing> ReadAll()
        {
            return db.Borrowings;
        }
        public void Update(Borrowing borrowing)
        {
            var oldBorrowing = Read(borrowing.BorrowingID);
            oldBorrowing.Date = borrowing.Date;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        
    }
}
