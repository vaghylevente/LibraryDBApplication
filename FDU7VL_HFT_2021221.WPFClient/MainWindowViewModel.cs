using FDU7VL_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FDU7VL_HFT_2021221.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Student> Students { get; set; }
        public RestCollection<Borrowing> Borrowings { get; set; }
        public RestCollection<Book> Books { get; set; }

        private Student selectedStudent;
        private Borrowing selectedBorrowing;
        private Book selectedBook;

        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set 
            {
                if (value != null)
                {
                    selectedStudent = new Student()
                    {
                        StudentID = value.StudentID,
                        Name = value.Name,
                        StudentClass = value.StudentClass
                    };
                    OnPropertyChanged();
                    (DeleteStudentCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateStudentCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public Borrowing SelectedBorrowing
        {
            get { return selectedBorrowing; }
            set
            {
                if (value != null)
                {
                    selectedBorrowing = new Borrowing()
                    {
                        BorrowingID = value.BorrowingID,
                        StudentID = value.StudentID,
                        BookID = value.BookID,
                        Date = value.Date
                    };
                    OnPropertyChanged();
                    (DeleteBorrowingCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateBorrowingCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                if (value != null)
                {
                    selectedBook = new Book()
                    {
                        BookID = value.BookID,
                        Title = value.Title,
                        Author = value.Author
                    };
                    OnPropertyChanged();
                    (DeleteBookCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateBookCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        //Student
        public ICommand CreateStudentCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand UpdateStudentCommand { get; set; }

        //Borrowing
        public ICommand CreateBorrowingCommmand { get; set; }
        public ICommand DeleteBorrowingCommand { get; set; }
        public ICommand UpdateBorrowingCommand { get; set; }

        //Book
        public ICommand CreateBookCommand { get; set; }
        public ICommand DeleteBookCommand { get; set; }
        public ICommand UpdateBookCommand { get; set; }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                //Student
                Students = new RestCollection<Student>("http://localhost:20621/", "student", "hub");
                CreateStudentCommand = new RelayCommand(
                    () => Students.Add(new Student()
                    {
                        Name = SelectedStudent.Name,
                        StudentClass= SelectedStudent.StudentClass
                    })
                    );
                DeleteStudentCommand = new RelayCommand(
                    () => Students.Delete(SelectedStudent.StudentID),
                    () => SelectedStudent != null
                    );
                UpdateStudentCommand = new RelayCommand(
                    () => Students.Update(SelectedStudent),
                    () => SelectedStudent != null
                    );
                SelectedStudent = new Student();
                //Borrowing
                Borrowings = new RestCollection<Borrowing>("http://localhost:20621/", "borrowing", "hub");
                CreateBorrowingCommmand = new RelayCommand(
                    () => Borrowings.Add(new Borrowing()
                    {
                        StudentID = SelectedBorrowing.StudentID,
                        BookID = SelectedBorrowing.BookID,
                        Date = SelectedBorrowing.Date
                    })
                    );
                DeleteBorrowingCommand = new RelayCommand(
                    () => Borrowings.Delete(SelectedBorrowing.BorrowingID),
                    () => SelectedBorrowing != null
                    );
                UpdateBorrowingCommand = new RelayCommand(
                    () => Borrowings.Update(SelectedBorrowing),
                    () => SelectedBorrowing != null
                    );
                SelectedBorrowing = new Borrowing();
                //Book
                Books = new RestCollection<Book>("http://localhost:20621/", "book", "hub");
                CreateBookCommand = new RelayCommand(
                    () => Books.Add(new Book()
                    {
                        BookID = SelectedBook.BookID,
                        Title = SelectedBook.Title,
                        Author = SelectedBook.Author
                    })
                    );
                DeleteBookCommand = new RelayCommand(
                    () => Books.Delete(SelectedBook.BookID),
                    () => SelectedBook != null
                    );
                UpdateBookCommand = new RelayCommand(
                    () => Books.Update(SelectedBook),
                    () => SelectedBook != null
                    );
                SelectedBook = new Book();
            }
        }
    }
}
