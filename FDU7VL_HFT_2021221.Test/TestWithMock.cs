using FDU7VL_HFT_2021221.Logic;
using FDU7VL_HFT_2021221.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDU7VL_HFT_2021221.Test
{
    [TestFixture]
    public class TestWithMock
    {
        BorrowingLogic borrowingLogic;
        StudentLogic studentLogic;
        BookLogic bookLogic;
        public TestWithMock()
        {
            Mock<IBorrowingLogic> mockBorrowingRepository = new();
            Mock<IStudentLogic> mockStudentRepository = new();
            Mock<IBookLogic> mockBookRepositry = new();

            var borrowings = new List<Borrowing>()
            {
                new Borrowing()
                {
                    StudentID = 1,
                    Date = new DateTime(2021,11,22),
                    BookID = 1
                },
                new Borrowing()
                {
                    StudentID = 1,
                    Date = new DateTime(2021,11,30),
                    BookID = 2
                },
                new Borrowing()
                {
                    StudentID = 2,
                    Date = new DateTime(2021,6,5),
                    BookID = 1
                }
            }.AsQueryable();
            var students = new List<Student>()
            {
                new Student()
                {
                    Name = "Name1",
                    Class = "A",
                    StudentID = 1
                },
                new Student()
                {
                    Name = "Name2",
                    Class = "B",
                    StudentID = 2
                }
            }.AsQueryable();
            var books = new List<Book>()
            {
                new Book()
                {
                    Title = "Title1",
                    Author = "Author1",
                    BookID = 1
                },
                new Book()
                {
                    Title = "Title2",
                    Author = "Author2",
                    BookID = 2
                }

            }.AsQueryable();


            mockBorrowingRepository.Setup(t => t.Create(It.IsAny<Borrowing>()));
            mockStudentRepository.Setup(t => t.Create(It.IsAny<Student>()));
            mockBookRepositry.Setup(t => t.Create(It.IsAny<Book>()));
        }

        public void CreateBookTest(string title, string author, bool exception)
        {

        }
    }
}
