using FDU7VL_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDU7VL_HFT_2021221.Repository
{
    public interface IBookRepository
    {
        void Create(Book book);
        Book Read(int id);
        void Update(Book book);
        void Delete(int id);
    }
}
