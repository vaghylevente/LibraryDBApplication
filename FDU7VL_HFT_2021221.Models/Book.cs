using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FDU7VL_HFT_2021221.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }

        [NotMapped]
        public virtual ICollection<Borrowing> Borrowings { get; set; }
    }
}
