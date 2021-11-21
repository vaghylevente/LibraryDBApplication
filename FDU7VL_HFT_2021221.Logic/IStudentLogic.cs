using FDU7VL_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDU7VL_HFT_2021221.Logic
{
    public interface IStudentLogic
    {
        void Create(Student student);
        Student Read(int id);
        IQueryable<Student> ReadAll();
        void Update(Student student);
        void Delete(int id);
    }
}
