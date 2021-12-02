using ConsoleTools;
using FDU7VL_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace FDU7VL_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:20621/");


            var student = new ConsoleMenu(args, level: 1)
                                .Add("ReadAll", () => 
                                {
                                    foreach (var item in rest.Get<Student>("student"))
                                    {
                                        Console.WriteLine(@"{0} from class {1}, StudentID: {2}", item.Name,item.Class, item.StudentID);
                                    }
                                    Console.ReadKey();
                                })
                                .Add("Read", () =>
                                {
                                    Console.Write("Input a studentID: ");
                                    string id = Console.ReadLine();
                                    var student = rest.GetSingle<Student>("student/" + id);
                                    Console.WriteLine(@"{0} from class {1}", student.Name, student.Class);
                                    Console.ReadLine();
                                })
                                .Add("Create", () =>
                                {
                                    Student newStudent = new();
                                    
                                    Console.Write("Name: ");
                                    newStudent.Name = Console.ReadLine();
                                    Console.Write("Class: ");
                                    newStudent.Class = Console.ReadLine();
                                    rest.Post<Student>(newStudent, "student");
                                })
                                .Add("Update", () =>
                                {
                                    Student newStudent = new();
                                    Console.Write("StudentID: ");
                                    newStudent.StudentID = int.Parse(Console.ReadLine());
                                    Console.Write("Name: ");
                                    newStudent.Name = Console.ReadLine();
                                    Console.Write("Class: ");
                                    newStudent.Class = Console.ReadLine();
                                    rest.Put<Student>(newStudent, "student");
                                })
                                .Add("Delete", () =>
                                {
                                    Console.Write("Student to delete (id): ");
                                    int id = int.Parse(Console.ReadLine());
                                    rest.Delete(id, "student");
                                })
                                .Add("Back to main", ConsoleMenu.Close);
            var borrowing = new ConsoleMenu(args, level: 1)
                                .Add("ReadAll", () =>
                                {
                                    foreach (var item in rest.Get<Borrowing>("borrowing"))
                                    {
                                        Console.WriteLine(item.Student.Name + " borrowed " + item.Book.Title + " on " + item.Date.ToShortDateString() + ", BorrowingID: " + item.BorrowingID);
                                    }
                                    Console.ReadKey();
                                })
                                .Add("Read", () =>
                                {
                                    Console.Write("Input a BorrowingID: ");
                                    string id = Console.ReadLine();
                                    var borrowing = rest.GetSingle<Borrowing>("borrowing/" + id);
                                    Console.WriteLine(borrowing.Student.Name + " borrowed " + borrowing.Book.Title + " on " + borrowing.Date.ToShortDateString());
                                    Console.ReadLine();
                                })
                                .Add("Create", () =>
                                {
                                    Borrowing newBorrowing = new();
                                    Console.Write("StudentID: ");
                                    newBorrowing.StudentID = int.Parse(Console.ReadLine());
                                    Console.Write("BookID: ");
                                    newBorrowing.BookID= int.Parse(Console.ReadLine());
                                    newBorrowing.Date = DateTime.Today;
                                    rest.Post<Borrowing>(newBorrowing, "borrowing");
                                })
                                .Add("Update", () =>
                                {
                                    Borrowing newBorrowing = new();
                                    Console.Write("BorrowingID: ");
                                    newBorrowing.BorrowingID = int.Parse(Console.ReadLine());
                                    Console.Write("StudentID: ");
                                    newBorrowing.StudentID = int.Parse(Console.ReadLine());
                                    Console.Write("BookID: ");
                                    newBorrowing.BookID = int.Parse(Console.ReadLine());
                                    newBorrowing.Date = DateTime.Today;
                                    rest.Put<Borrowing>(newBorrowing, "borrowing");
                                })
                                .Add("Delete", () =>
                                {
                                    Console.Write("Borrowing to delete (id): ");
                                    int id = int.Parse(Console.ReadLine());
                                    rest.Delete(id, "borrowing");
                                })
                                .Add("MostPopularBook", () =>
                                {
                                    var mostPopularBook = rest.GetSingle<Book>("stat/mostpopularbook");
                                    Console.WriteLine("The most popular book is " + mostPopularBook.Title + " by " + mostPopularBook.Author);
                                    Console.ReadLine();
                                })
                                .Add("FirstBorrower", () =>
                                {
                                    var firstBorrower = rest.GetSingle<Student>("stat/firstborrower");
                                    Console.WriteLine("The first book was borrowed by " + firstBorrower.Name);
                                    Console.ReadLine();
                                })
                                .Add("BiggestBorrower", () =>
                                {
                                    var biggetBorrower = rest.GetSingle<Student>("stat/biggestBorrower");
                                    Console.WriteLine(biggetBorrower.Name + " borrowed the most books.");
                                    Console.ReadLine();
                                })
                                .Add("BorrowingPerBook", () =>
                                {
                                    var borrowingPerBook = rest.Get<KeyValuePair<Book, int>>("stat/borrowingperbook");
                                    foreach (var item in borrowingPerBook)
                                    {
                                        Console.WriteLine(item.Key.Title + ": " + item.Value);
                                    }
                                    Console.ReadLine();
                                })
                                .Add("BooksBorrowedBy", () =>
                                {
                                    Console.Write("Student Name: ");
                                    string name = Console.ReadLine();
                                    var bookBorrowedBy = rest.Get<Book>("stat/booksborrowedby/"+name);
                                    Console.WriteLine(name + " borrowed the following books:");
                                    foreach (var item in bookBorrowedBy)
                                    {
                                        Console.WriteLine(item.Title + " by " + item.Author);
                                    }
                                    Console.ReadLine();
                                })
                                .Add("Back to main", ConsoleMenu.Close);
            var book = new ConsoleMenu(args, level: 1)
                                .Add("ReadAll", () =>
                                {
                                    foreach (var item in rest.Get<Book>("book"))
                                    {
                                        Console.WriteLine(item.Title + " by " + item.Author + ", BookID" + item.BookID);
                                    }
                                    Console.ReadKey();
                                })
                                .Add("Read", () =>
                                {
                                    Console.Write("Input a BookID: ");
                                    string id = Console.ReadLine();
                                    var book = rest.GetSingle<Book>("book/" + id);
                                    Console.WriteLine(book.Title + " by " + book.Author);
                                    Console.ReadLine();
                                })
                                .Add("Create", () =>
                                {
                                    Book newBook = new();
                                    Console.Write("Title: ");
                                    newBook.Title = Console.ReadLine();
                                    Console.Write("Author: ");
                                    newBook.Author = Console.ReadLine();
                                    rest.Post<Book>(newBook, "book");
                                })
                                .Add("Update", () =>
                                {
                                    Book newBook = new();
                                    Console.WriteLine("BookID: ");
                                    newBook.BookID = int.Parse(Console.ReadLine());
                                    Console.Write("Title: ");
                                    newBook.Title = Console.ReadLine();
                                    Console.Write("Author: ");
                                    newBook.Author = Console.ReadLine();
                                    rest.Put<Book>(newBook, "book");
                                })
                                .Add("Delete", () =>
                                {
                                    Console.Write("Book to delete (id): ");
                                    int id = int.Parse(Console.ReadLine());
                                    rest.Delete(id, "book");
                                })
                                .Add("Back to main", ConsoleMenu.Close);

            var main_menu = new ConsoleMenu(args, level: 0)
                                .Add("Student methods", () => student.Show())
                                .Add("Borrowing methods", () => borrowing.Show())
                                .Add("Book methods", () => book.Show())
                                .Add("Close", ConsoleMenu.Close);
            main_menu.Show();

        }
    }
}
