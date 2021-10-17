using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDU7VL_HFT_2021221.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        public string Title { get; set; }
    }
}
