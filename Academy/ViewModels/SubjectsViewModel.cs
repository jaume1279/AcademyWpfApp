using Academy.Lib.Models;
using Academy.Lib.UI;
using Common.Lib.Core.Context;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Academy.ViewModels
{
    public class SubjectsViewModel : ViewModelBase
    {
        private List<Subject> _subjects;
        public List<Subject> Subjects
        {
            get
            {
                return _subjects;
            }
            set
            {
                _subjects = value;
                OnPropertyChanged();
            }
        }



        public SubjectsViewModel()
        {
            AddSubjectCommand = new RouteCommand(AddSubject);
            GetSubjectsCommand = new RouteCommand(GetSubjects);
            DeleteSubjectsCommand = new RouteCommand(DelSubject);
            UpdateSubjectsCommand = new RouteCommand(UpdateSubject);
        }

        public const string SelectedItemPropertyName = "SelectedItem";
        private Subject _selectedItem = null;
        public Subject SelectedItem
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

        private string newTeacher;
        public string NewTeacher
        {
            get { return this.newTeacher; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this.newTeacher, value))
                {
                    this.newTeacher = value;
                    this.OnPropertyChanged(); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }

        private bool btnUpdateSubject;
        public bool BtnUpdateSubject
        {
            get { return this.btnUpdateSubject; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this.btnUpdateSubject, value))
                {
                    this.btnUpdateSubject = value;
                    this.OnPropertyChanged(); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }

        private bool datagridSubjects;
        public bool DatagridSubjects
        {
            get { return this.datagridSubjects; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this.datagridSubjects, value))
                {
                    this.datagridSubjects = value;
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

        public void AddSubject()
        {
            var subject = new Subject
            {
                Teacher = NewTeacher,
                Name = NewName
            };

            var sr = subject.Save();

            if (sr.IsSuccess == true)
            {
                ClearTxtBox();
            }
            else
            {
                ErrorMessages = sr.AllErrors;
                MessageBoxResult result = MessageBox.Show(ErrorMessages, "Add Error!!:");
            }

            ClearTxtBox();
            GetSubjects();
        }

        public void GetSubjects()
        {
            var repo = Subject.DepCon.Resolve<IRepository<Subject>>();
            Subjects = repo.QueryAll().ToList();
        }

        public void DelSubject()
        {
            var subj = new Subject();
            subj = SelectedItem;
            if (SelectedItem != null)
            {
                var dr = subj.Delete();

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
            GetSubjects();
        }

        public void UpdateSubject()
        {

            if (SelectedItem != null)
            {
                if (NewName == null)
                {
                    NewName = SelectedItem.Name;
                }

                if (newTeacher == null)
                {
                    NewTeacher = SelectedItem.Teacher;
                }

                var subject = new Subject
                {
                    Id = SelectedItem.Id,
                    Teacher = NewTeacher,
                    Name = NewName
                };

                var sr = subject.Save();

                ErrorMessages = sr.AllErrors;
                if (ErrorMessages != "")
                {
                    MessageBoxResult result = MessageBox.Show(ErrorMessages, "Update Error!!:");
                }

                ClearTxtBox();
                GetSubjects();
            }
        }

        public void ClearTxtBox()
        {
            NewName = null;
            NewTeacher = null;
        }

        #region Commands
        public ICommand AddSubjectCommand { get; set; }
        public ICommand GetSubjectsCommand { get; set; }
        public ICommand DeleteSubjectsCommand { get; set; }
        public ICommand UpdateSubjectsCommand { get; set; }

        #endregion

    }
}
