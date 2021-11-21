using FDU7VL_HFT_2021221.Models;
using FDU7VL_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDU7VL_HFT_2021221.Logic
{
    public interface IBookLogic
    {
        void Create(Book book);
        Book Read(int id);
        IQueryable<Book> ReadAll();
        void Update(Book book);
        void Delete(int id);
    }
}
