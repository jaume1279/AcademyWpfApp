using Academy.Lib.Models;
using Academy.Lib.UI;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Common.Lib.Infrastructure;
using Common.Lib.Core.Context;
using System.Windows;

namespace Academy.ViewModels
{
    public class StudentsViewModel : ViewModelBase
    {
        private List<Student> _students;
        public List<Student> Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        public StudentsViewModel()
        {
            AddStudentCommand = new RouteCommand(AddStudent);
            GetStudentsCommand = new RouteCommand(GetStudents);
            DeleteStudentsCommand = new RouteCommand(DelStudent);
            UpdateStudentsCommand = new RouteCommand(UpdateStudent);
        }

        private Student _selectedItem = null;
        public Student SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem == value)
                {
                    return;
                }

                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        private string newName;
        public string NewName
        {
            get { return this.newName; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this.newName, value))
                {
                    this.newName = value;
                    this.OnPropertyChanged(); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }

        private string newDni;
        public string NewDni
        {
            get { return this.newDni; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this.newDni, value))
                {
                    this.newDni = value;
                    this.OnPropertyChanged(); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }

        private string newEmail;
        public string NewEmail
        {
            get { return this.newEmail; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this.newEmail, value))
                {
                    this.newEmail = value;
                    this.OnPropertyChanged(); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }

        private string newChair;
        public string NewChair
        {
            get { return this.newChair; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this.newChair, value))
                {
                    this.newChair = value;
                    this.OnPropertyChanged(); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }


        private bool datagridStudents;
        public bool DatagridStudents
        {
            get { return this.datagridStudents; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this.datagridStudents, value))
                {
                    this.datagridStudents = value;
                    this.OnPropertyChanged(); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }

        private string _errorMessages = null;
        public string ErrorMessages
        {
            get
            {
                return _errorMessages;
            }
            set
            {
                if (_errorMessages == value)
                {
                    return;
                }

                _errorMessages = value;
                OnPropertyChanged();
            }
        }

        public void AddStudent()
        {
            ValidationResult<int> vrChair = Student.ValidateChairNumber(NewChair);
            if (vrChair.IsSuccess)
            {
                var student = new Student
                {
                    Dni = NewDni,
                    Name = NewName,
                    Email = NewEmail,
                    ChairNumber = vrChair.ValidatedResult
                };

                var sr = student.Save();

                if (sr.IsSuccess == true)
                {
                    ClearTxtBox();
                }
                else
                {
                    ErrorMessages = sr.AllErrors;
                    MessageBoxResult result = MessageBox.Show(ErrorMessages, "Add Error!!:");
                }

                GetStudents();
            }
            else
            {
                ErrorMessages = vrChair.AllErrors;
                MessageBoxResult result = MessageBox.Show(ErrorMessages, "Add Error!!:");
            }
        }

        public void GetStudents()
        {

            var repo = Student.DepCon.Resolve<IRepository<Student>>();
            Students = repo.QueryAll().ToList();

        }

        public void DelStudent()
        {
            var stud = new Student();
            stud = SelectedItem;
            if (SelectedItem != null)
            {
                var dr = stud.Delete();

                if (dr.IsSuccess == true)
                {
                    ClearTxtBox();
                }
                else
                {
                    ErrorMessages = dr.AllErrors;
                    MessageBoxResult result = MessageBox.Show(ErrorMessages, "Delete Error!!:");
                }
            }
            else
            {
                ErrorMessages = "Please, select a register to delete";
                MessageBoxResult result = MessageBox.Show(ErrorMessages, "Delete Error!!:");
            }


            GetStudents();
        }

        public void UpdateStudent()
        {
            if (SelectedItem != null)
            {
                ValidationResult<int> vrChair;

                if (NewChair != null)
                {
                    vrChair = Student.ValidateChairNumber(NewChair);
                }
                else
                {
                    vrChair = Student.ValidateChairNumber(SelectedItem.ChairNumber.ToString(), SelectedItem.Id);
                }

                if (NewName == null)
                {
                    NewName = SelectedItem.Name;
                }
                if (NewEmail == null)
                {
                    NewEmail = SelectedItem.Email;
                }
                if (NewDni == null)
                {
                    NewDni = SelectedItem.Dni;
                }

                if (vrChair.IsSuccess)
                {
                    var student = new Student
                    {
                        Id = SelectedItem.Id,
                        Dni = NewDni,
                        Name = NewName,
                        Email = NewEmail,
                        ChairNumber = vrChair.ValidatedResult
                    };
                    var sr = student.Save();
                    ErrorMessages = sr.AllErrors;
                    if (ErrorMessages != "")
                    {
                        MessageBoxResult result = MessageBox.Show(ErrorMessages, "Update Error!!:");
                    }

                }
                else
                {
                    ErrorMessages = vrChair.AllErrors;
                    MessageBoxResult result = MessageBox.Show(ErrorMessages, "Update Error!!:");
                }

                ClearTxtBox();
                GetStudents();
            }
        }

        public void ClearTxtBox()
        {
            NewName = null;
            NewDni = null;
            NewEmail = null;
            NewChair = null;
        }

        #region Commands
        public ICommand AddStudentCommand { get; set; }
        public ICommand GetStudentsCommand { get; set; }
        public ICommand DeleteStudentsCommand { get; set; }
        public ICommand UpdateStudentsCommand { get; set; }

        #endregion

    }
}
