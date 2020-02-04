using Academy.Lib.Models;
using Academy.Lib.UI;
using Common.Lib.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Academy.ViewModels
{
    public class StudentSubjectViewModel : ViewModelBase
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

        private List<Subject> _subjectsList;
        public List<Subject> SubjectsList
        {
            get
            {
                return _subjectsList;
            }
            set
            {
                _subjectsList = value;
                OnPropertyChanged();
            }
        }

        private List<StudentSubject> _studentSubjectList;
        public List<StudentSubject> StudentSubjectList
        {
            get
            {
                return _studentSubjectList;
            }
            set
            {
                _studentSubjectList = value;
                OnPropertyChanged();
            }
        }

        private bool datagridStudentSubject;
        public bool DatagridStudentSubject
        {
            get { return this.datagridStudentSubject; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this.datagridStudentSubject, value))
                {
                    this.datagridStudentSubject = value;
                    this.OnPropertyChanged(); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }

        private StudentSubject _selectedItemStudSubj = null;
        public StudentSubject SelectedItemStudSubj
        {
            get
            {
                return _selectedItemStudSubj;
            }
            set
            {
                if (_selectedItemStudSubj == value)
                {
                    return;
                }

                _selectedItemStudSubj = value;
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

        private Subject _selectedItemComboSubject = null;
        public Subject SelectedItemComboSubject
        {
            get
            {
                return _selectedItemComboSubject;
            }
            set
            {
                if (_selectedItemComboSubject == value)
                {
                    return;
                }

                _selectedItemComboSubject = value;
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

        public StudentSubjectViewModel()
        {


            AddStudentSubjectCommand = new RouteCommand(AddStudentSubject);
            GetStudentSubjectCommand = new RouteCommand(GetStudentSubjects);
            ClearCboStudentsCommand = new RouteCommand(ClearCboStudents);
            ClearCboSubjectsCommand = new RouteCommand(ClearCboSubjects);
            DeleteStudentSubjectCommand = new RouteCommand(DelStudentSubject);
        }

        public void GetStudentsList()       // Fill the ComboBox Students
        {
            var repo = Student.DepCon.Resolve<IRepository<Student>>();
            StudentsList = repo.QueryAll().ToList();
        }
        public void GetSubjectsList()       // Fill the ComboBox Subjects
        {
            var repo = Subject.DepCon.Resolve<IRepository<Subject>>();
            SubjectsList = repo.QueryAll().ToList();
        }


        public void GetStudentSubjects()
        {
            GetStudentsList();
            GetSubjectsList();

            var repo = StudentSubject.DepCon.Resolve<IRepository<StudentSubject>>();
            StudentSubjectList = repo.QueryAll().ToList();
        }


        public void AddStudentSubject()
        {
            var SelSTud = new Student();

            if (SelectedItemComboStudent == null)
            {

                SelSTud.Id = Guid.Empty;
            }
            else
            {
                SelSTud.Id = SelectedItemComboStudent.Id;
            }

            var SelSubject = new Subject();

            if (SelectedItemComboSubject == null)
            {

                SelSubject.Id = Guid.Empty;
            }
            else
            {
                SelSubject.Id = SelectedItemComboSubject.Id;
            }

            var studSubj = new StudentSubject
            {
                StudentId = SelSTud.Id,
                SubjectId = SelSubject.Id
            };

            var sr = studSubj.Save();

            if (sr.IsSuccess != true)
            {
                ErrorMessages = sr.AllErrors;
                MessageBoxResult result = MessageBox.Show(ErrorMessages, "Add Error!!:");
            }


            GetStudentSubjects();
        }

        public void DelStudentSubject()
        {
            var studSubj = new StudentSubject();
            studSubj = SelectedItemStudSubj;
            if (SelectedItemStudSubj != null)
            {
                var dr = studSubj.Delete();

                if (dr.IsSuccess != true)
                {
                    ErrorMessages = dr.AllErrors;
                    MessageBoxResult result = MessageBox.Show(ErrorMessages, "Delete Error!!:");
                }
            }



            GetStudentSubjects();
        }

        public void ClearCboStudents()
        {
            GetStudentsList();
        }

        public void ClearCboSubjects()
        {
            GetSubjectsList();
        }

        public ICommand AddStudentSubjectCommand { get; set; }
        public ICommand GetStudentSubjectCommand { get; set; }
        public ICommand ClearCboStudentsCommand { get; set; }
        public ICommand ClearCboSubjectsCommand { get; set; }
        public ICommand DeleteStudentSubjectCommand { get; set; }
    }
}
