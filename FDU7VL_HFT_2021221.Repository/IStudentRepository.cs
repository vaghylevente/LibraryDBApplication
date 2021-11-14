using FDU7VL_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDU7VL_HFT_2021221.Repository
{
    public interface IStudentRepository
    {
        void Create(Student student);
        Student Read(int id);
        void Update(Student student);
        void Delete(int id);
    }
}
