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
            Student peter = new Student() { StudentID = 1, Name = "Péter", Class = "A" };
            Student lilla = new Student() { StudentID = 2, Name = "Lilla", Class = "B" };
            Student gabor = new Student() { StudentID = 3, Name = "Gábor", Class = "C" };

            Borrowing peter1 = new Borrowing() { StudentID = 1, Date = new DateTime(2021, 10, 10), BookID = 1 };
            Borrowing lilla1 = new Borrowing() { StudentID = 2, Date = new DateTime(2021, 10, 17), BookID = 1 };
            Borrowing lilla2 = new Borrowing() { StudentID = 2, Date = new DateTime(2021, 10, 17), BookID = 2 };
            Borrowing gabor1 = new Borrowing() { StudentID = 3, Date = new DateTime(2021, 10, 15), BookID = 3 };

            Book book1 = new Book() { BookID = 1, Title = "Head First C", Author = "David Griffith and Dawn Griffith"};
            Book book2 = new Book() { BookID = 2, Title = "The Call of Cthulhu", Author = "H. P. Lovecraft" };
            Book book3 = new Book() { BookID = 3, Title = "A study in Scarlet", Author = "Conan Doyle" };

            modelBuilder.Entity<Student>().HasData(peter, lilla, gabor);
            modelBuilder.Entity<Borrowing>().HasData(peter1, lilla1, lilla2, gabor1);
            modelBuilder.Entity<Book>().HasData(book1, book2, book3);
        }
    }
}
