using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDU7VL_HFT_2021221.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public virtual ICollection<Borrowing> Borrowings { get; set; }

        public Student()
        {
            Borrowings = new HashSet<Borrowing>();
        }
    }
}
