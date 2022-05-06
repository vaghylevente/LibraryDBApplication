using FDU7VL_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FDU7VL_HFT_2021221.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Student> Students { get; set; }
        private Student selectedStudent;

        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set 
            { 
                SetProperty(ref selectedStudent, value);
                (DeleteStudentCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public ICommand CreateStudentCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand UpdateStudentCommand { get; set; }
        public MainWindowViewModel()
        {
           Students = new RestCollection<Student>("http://localhost:20621", "/student");
            CreateStudentCommand = new RelayCommand(() =>
            {
                Students.Add(new Student()
                {
                    Name = "assdasd"
                });
            });

            DeleteStudentCommand = new RelayCommand(() =>
            {
                Students.Delete(SelectedStudent.StudentID);
            },
            () =>
            {
                return SelectedStudent != null;
            });
        }
    }
}
