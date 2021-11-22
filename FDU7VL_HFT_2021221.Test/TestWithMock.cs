using FDU7VL_HFT_2021221.Logic;
using FDU7VL_HFT_2021221.Models;
using FDU7VL_HFT_2021221.Repository;
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
            Mock<IBorrowingRepository> mockBorrowingRepository = new();
            Mock<IStudentRepository> mockStudentRepository = new();
            Mock<IBookRepository> mockBookRepositry = new();

            var students = new List<Student>()
            {
                new Student()
                {
                    Name = "Péter",
                    Class = "A",
                },
                new Student()
                {
                    Name = "Anna",
                    Class = "B",
                }
            }.AsQueryable();
            var books = new List<Book>()
            {
                new Book()
                {
                    Title = "Oghma Infinium",
                    Author = "Author1",
                },
                new Book()
                {
                    Title = "Könyv2",
                    Author = "Author2",
                }

            }.AsQueryable();
            var borrowings = new List<Borrowing>()
            {
                new Borrowing()
                {
                    Student = students.ElementAt(0),
                    Date = new DateTime(2021,11,22),
                    Book = books.ElementAt(0)
                },
                new Borrowing()
                {
                    Student = students.ElementAt(0),
                    Date = new DateTime(2021,11,30),
                    Book = books.ElementAt(1)
                },
                new Borrowing()
                {
                    Student = students.ElementAt(1),
                    Date = new DateTime(2019,6,5),
                    Book = books.ElementAt(0)
                }
            }.AsQueryable();
            
            


            mockBorrowingRepository.Setup(t => t.Create(It.IsAny<Borrowing>()));
            mockStudentRepository.Setup(t => t.Create(It.IsAny<Student>()));
            mockBookRepositry.Setup(t => t.Create(It.IsAny<Book>()));

            mockBorrowingRepository.Setup(t => t.ReadAll()).Returns(borrowings);
            mockStudentRepository.Setup(t => t.ReadAll()).Returns(students);
            mockBookRepositry.Setup(t => t.ReadAll()).Returns(books);

            borrowingLogic = new BorrowingLogic(mockBorrowingRepository.Object);
            studentLogic = new StudentLogic(mockStudentRepository.Object);
            bookLogic = new BookLogic(mockBookRepositry.Object);
        }
        [TestCase("", "author", true)]
        [TestCase("title", "", false)]
        [TestCase(null, "author", true)]
        [TestCase("title", null, false)]
        public void CreateBookTest(string title, string author, bool exception)
        {
            if (exception)
            {
                Assert.That(() => bookLogic.Create(new Book()
                {
                    Title = title,
                    Author = author
                }), Throws.Exception);
            }
            else
            {
                Assert.That(() => bookLogic.Create(new Book()
                {
                    Title = title,
                    Author = author
                }), Throws.Nothing);
            }
        }
        [Test]
        public void CreateStudentTest(string name, bool exception)
        {

        }
        [Test]
        public void CreateBorrowingTest(DateTime date, bool excepion)
        {

        }
        [Test]
        public void MostPopularBookTest()
        {
            //ACT
            var result = borrowingLogic.MostPopularBook();
            //ASSERT
            Assert.That(result.Title == "Oghma Infinium");
        }
        [Test]
        public void FirstBorrowerTest()
        {
            var result = borrowingLogic.FirstBorrower();

            Assert.That(result.Name == "Anna");
        }
        [Test]
        public void BiggestBorrowerTest()
        {
            var result = borrowingLogic.BiggestBorrower();

            Assert.That(result.Name == "Péter");
        }
        [Test]
        public void BorrowingPerBookTest()
        {
            
        }
        [Test]
        public void BooksBorrowedByTest(Student student)
        {
            throw new NotImplementedException();
        }

    }
}
