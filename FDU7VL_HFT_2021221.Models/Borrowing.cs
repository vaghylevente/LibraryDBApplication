using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDU7VL_HFT_2021221.Models
{
    public class Borrowing
    {
        [Key]
        public int BorrowingID { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentID { get; set; }

        [ForeignKey(nameof(Book))]
        public int BookID { get; set; }
        public DateTime Date { get; set; }
    }
}
