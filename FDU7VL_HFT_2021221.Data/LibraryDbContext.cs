using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FDU7VL_HFT_2021221.Models;

namespace FDU7VL_HFT_2021221.Data
{
    public class LibraryDbContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Borrowing> Borrowings { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Borrowing>(entity =>
            {
                entity.HasOne(Borrowing => Borrowing.Student)
                    .WithMany(Student => Student.Borrowings)
                    .HasForeignKey(Borrowing => Borrowing.StudentID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(Borrowing => Borrowing.Book)
                    .WithOne(Book => Book.Borrowing)
                    .HasForeignKey<Book>(Borrowing => Borrowing.BookID);
            });
            
            //DbSeed
            Student peter = new() { StudentID = 1, Name = "Péter", Class = "A" };
            Student lilla = new() { StudentID = 2, Name = "Lilla", Class = "B" };
            Student gabor = new() { StudentID = 3, Name = "Gábor", Class = "C" };
            Student igor = new() { StudentID = 4, Name = "Igor", Class = "A" };
            Student chad = new() { StudentID = 5, Name = "Chad", Class = "A" };
            Student viktor = new() { StudentID = 6, Name = "Viktor", Class = "B" };

            Borrowing peter1 = new() { StudentID = 1, Date = new DateTime(2021, 10, 10), BookID = 1 };
            Borrowing lilla1 = new() { StudentID = 2, Date = new DateTime(2021, 10, 17), BookID = 1 };
            Borrowing lilla2 = new() { StudentID = 2, Date = new DateTime(2021, 10, 17), BookID = 2 };
            Borrowing lilla3 = new() { StudentID = 2, Date = new DateTime(2021, 10, 17), BookID = 5 };
            Borrowing gabor1 = new() { StudentID = 3, Date = new DateTime(2021, 10, 15), BookID = 3 };
            Borrowing igor1 = new() { StudentID = 4, Date = new DateTime(1910, 9, 12), BookID = 4 };
            Borrowing viktor1 = new() { StudentID = 1, Date = new DateTime(2021, 11, 5), BookID = 1 };
            

            Book book1 = new() { BookID = 1, Title = "Head First C", Author = "David Griffith and Dawn Griffith"};
            Book book2 = new() { BookID = 2, Title = "The Call of Cthulhu", Author = "H. P. Lovecraft" };
            Book book3 = new() { BookID = 3, Title = "A study in Scarlet", Author = "Conan Doyle" };
            Book book4 = new() { BookID = 4, Title = "666", Author = "unknown" };
            Book book5 = new() { BookID = 5, Title = "Enchanted Book", Author = "unknown" };

            modelBuilder.Entity<Student>().HasData(peter, lilla, gabor, igor, chad, viktor);
            modelBuilder.Entity<Borrowing>().HasData(peter1, lilla1, lilla2, lilla3, gabor1, igor1, viktor1);
            modelBuilder.Entity<Book>().HasData(book1, book2, book3, book4, book5);
        }
    }
}
