using Academy.Lib.Models;
using Academy.Lib.UI;
using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Academy.ViewModels
{
    public class StudentExamViewModel : ViewModelBase
    {
        private List<Student> _studentsList;
        public List<Student> StudentsList
        {
            get
            {
                return _studentsList;
            }
            set
            {
                _studentsList = value;
                OnPropertyChanged();
            }
        }

        private List<Exam> _examsList;
        public List<Exam> ExamsList
        {
            get
            {
                return _examsList;
            }
            set
            {
                _examsList = value;
                OnPropertyChanged();
            }
        }

        private List<StudentExam> _studentExamList;
        public List<StudentExam> StudentExamList
        {
            get
            {
                return _studentExamList;
            }
            set
            {
                _studentExamList = value;
                OnPropertyChanged();
            }
        }


        private Student _selectedItemComboStudent = null;
        public Student SelectedItemComboStudent
        {
            get
            {
                return _selectedItemComboStudent;
            }
            set
            {
                if (_selectedItemComboStudent == value)
                {
                    return;
                }

                _selectedItemComboStudent = value;
                OnPropertyChanged();
            }
        }

        private Exam _selectedItemComboExam = null;
        public Exam SelectedItemComboExam
        {
            get
            {
                return _selectedItemComboExam;
            }
            set
            {
                if (_selectedItemComboExam == value)
                {
                    return;
                }

                _selectedItemComboExam = value;
                OnPropertyChanged();
            }
        }


        private string mark;
        public string Mark
        {
            get { return this.mark; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this.mark, value))
                {
                    this.mark = value;
                    this.OnPropertyChanged(); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }

        private bool hasCheated = true;
        public bool HasCheated
        {
            get
            {
                return this.hasCheated;
            }

            set
            {
                this.hasCheated = value;
                this.OnPropertyChanged(); // Method to raise the PropertyChanged event in your BaseViewModel class...

            }
        }

        private StudentExam _selectedItemStudExam = null;
        public StudentExam SelectedItemStudExam
        {
            get
            {
                return _selectedItemStudExam;
            }
            set
            {
                if (_selectedItemStudExam == value)
                {
                    return;
                }

                _selectedItemStudExam = value;
                OnPropertyChanged();
            }
        }


        private StudentExam _selectedItem = null;
        public StudentExam SelectedItem
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


        public StudentExamViewModel()
        {
            AddStudentExamCommand = new RouteCommand(AddStudentExam);
            GetStudentExamCommand = new RouteCommand(GetStudentExam);
            UpdateStudentExamCommand = new RouteCommand(UpdateStudentExam);
            DeleteStudentExamCommand = new RouteCommand(DelStudentExam);
        }
        public void GetStudentExam()
        {
            GetStudentsList();
            GetExamsList();
            Mark = "";

            var repo = StudentExam.DepCon.Resolve<IRepository<StudentExam>>();
            StudentExamList = repo.QueryAll().ToList();
        }

        public void GetStudentsList()       // Fill the ComboBox Students
        {
            var repo = Student.DepCon.Resolve<IRepository<Student>>();
            StudentsList = repo.QueryAll().ToList();
        }

        public void GetExamsList()       // Fill the ComboBox Exam
        {
            var repo = Exam.DepCon.Resolve<IRepository<Exam>>();
            ExamsList = repo.QueryAll().ToList();
        }

        public void AddStudentExam()
        {
            var SelStud = new Student();

            if (SelectedItemComboStudent == null)
            {

                SelStud.Id = Guid.Empty;
            }
            else
            {
                SelStud.Id = SelectedItemComboStudent.Id;
            }

            var SelExam = new Exam();

            if (SelectedItemComboExam == null)
            {

                SelExam.Id = Guid.Empty;
            }
            else
            {
                SelExam.Id = SelectedItemComboExam.Id;
            }


            ValidationResult<string> vrMark = StudentExam.ValidateMark(Mark);
            if (vrMark.IsSuccess)
            {
                var studExam = new StudentExam
                {
                    StudentId = SelStud.Id,
                    ExamId = SelExam.Id,
                    Mark = Double.Parse(vrMark.ValidatedResult),
                    HasCheated = this.HasCheated
                };

                var sr = studExam.Save();

                if (sr.IsSuccess == true)
                {
                    GetStudentExam();
                }
                else
                {
                    ErrorMessages = sr.AllErrors;
                    MessageBoxResult result = MessageBox.Show(ErrorMessages, "Add Error!!:");
                }
            }
            else
            {
                ErrorMessages = vrMark.AllErrors;
                MessageBoxResult result = MessageBox.Show(ErrorMessages, "Add Error!!:");
            }

            GetStudentExam();
        }

        public void UpdateStudentExam()
        {
            if (SelectedItem != null)
            {
                var SelStud = new Student();

                if (SelectedItemComboStudent == null)
                {
                    SelStud.Id = SelectedItem.StudentId;
                }
                else
                {
                    SelStud.Id = SelectedItemComboStudent.Id;
                }

                var SelExam = new Exam();

                if (SelectedItemComboExam == null)
                {
                    SelExam.Id = SelectedItem.ExamId;
                }
                else
                {
                    SelExam.Id = SelectedItemComboExam.Id;
                }

                ValidationResult<string> vrMark;

                if (Mark != "")
                {
                    vrMark = StudentExam.ValidateMark(Mark);
                }
                else
                {
                    vrMark = StudentExam.ValidateMark(SelectedItem.Mark.ToString(), SelectedItem.Id);
                }

                var studExam = new StudentExam()
                {
                    Id = SelectedItem.Id,
                    StudentId = SelStud.Id,
                    ExamId = SelExam.Id,
                    Mark = Double.Parse(vrMark.ValidatedResult),
                    HasCheated = HasCheated
                };

                var sr = studExam.Save();

                if (sr.IsSuccess != true)
                {
                    ErrorMessages = sr.AllErrors;
                    MessageBoxResult result = MessageBox.Show(ErrorMessages, "Update Error!!:");
                }

                GetStudentExam();
            }
        }

        public void DelStudentExam()
        {
            var studExam = new StudentExam();
            studExam = SelectedItem;
            if (SelectedItem != null)
            {
                var dr = studExam.Delete();
            }


            GetStudentExam();
        }


        public ICommand AddStudentExamCommand { get; set; }
        public ICommand GetStudentExamCommand { get; set; }
        public ICommand UpdateStudentExamCommand { get; set; }
        public ICommand DeleteStudentExamCommand { get; set; }


    }
}
