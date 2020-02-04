using Academy.Lib.Models;
using Academy.Lib.UI;
using Common.Lib.Core.Context;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Academy.ViewModels
{
    public class ExamViewModel : ViewModelBase
    {
        public ExamViewModel()
        {
            AddExamCommand = new RouteCommand(AddExam);
            GetExamsCommand = new RouteCommand(GetExams);
            DeleteExamCommand = new RouteCommand(DelExam);
            UpdateExamCommand = new RouteCommand(UpdateExam);

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

        private bool datagridExams;
        public bool DatagridExams
        {
            get { return this.datagridExams; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this.datagridExams, value))
                {
                    this.datagridExams = value;
                    this.OnPropertyChanged(); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }

        public const string SelectedItemPropertyName = "SelectedItem";

        private Exam _selectedItem = null;
        public Exam SelectedItem
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

        private string title;
        public string Title
        {
            get { return this.title; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this.title, value))
                {
                    this.title = value;
                    this.OnPropertyChanged(); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }

        private string text;
        public string Text
        {
            get { return this.text; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this.text, value))
                {
                    this.text = value;
                    this.OnPropertyChanged(); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }

        private string date;
        public string Date
        {
            get { return this.date; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this.date, value))
                {
                    this.date = value;
                    this.OnPropertyChanged(); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }


        private Subject selectedItemComboSubject = null;
        public Subject SelectedItemComboSubject
        {
            get { return this.selectedItemComboSubject; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this.selectedItemComboSubject, value))
                {
                    this.selectedItemComboSubject = value;
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

        public void GetExams()
        {
            GetSubjectsList();

            var repo = Exam.DepCon.Resolve<IRepository<Exam>>();
            ExamsList = repo.QueryAll().ToList();
        }

        public void GetSubjectsList()       // Fill the ComboBox Subjects
        {
            var repo = Subject.DepCon.Resolve<IRepository<Subject>>();
            SubjectsList = repo.QueryAll().ToList();
        }

        public void AddExam()
        {

            if (Date != null)
            {
                DateTime datum = DateTime.Parse(Date, CultureInfo.CreateSpecificCulture("en-US"));
                Date = datum.ToString("dd/MM/yyyy");
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

            var exam = new Exam
            {
                Title = Title,
                Text = Text,
                Date = Date,
                SubjectId = SelSubject.Id
            };

            var sr = exam.Save();

            if (sr.IsSuccess != true)
            {
                ErrorMessages = sr.AllErrors;
                MessageBoxResult result = MessageBox.Show(ErrorMessages, "Add Error!!:");
            }

            GetExams();
            ClearTxtBox();
        }

        public void UpdateExam()
        {
            if (SelectedItem != null)
            {
                if (Title == null)
                {
                    Title = SelectedItem.Title;
                }

                if (Text == null)
                {
                    Text = SelectedItem.Text;
                }


                if (Date != null)
                {
                    DateTime datum = DateTime.Parse(Date, CultureInfo.CreateSpecificCulture("en-US"));
                    Date = datum.ToString("dd/MM/yyyy");
                }

                if (Date == null)
                {
                    Date = SelectedItem.Date;
                }

                var SelSubj = new Subject();

                if (SelectedItemComboSubject == null)
                {
                    SelSubj.Id = SelectedItem.SubjectId;
                }
                else
                {
                    SelSubj.Id = SelectedItemComboSubject.Id;
                }
                var exam = new Exam
                {
                    Id = SelectedItem.Id,
                    Title = Title,
                    Text = Text,
                    Date = Date,
                    SubjectId = SelSubj.Id
                };

                var sr = exam.Save();

                if (sr.IsSuccess != true)
                {
                    ErrorMessages = sr.AllErrors;
                    MessageBoxResult result = MessageBox.Show(ErrorMessages, "Update Error!!:");
                }

                GetExams();
                ClearTxtBox();
            }
            else
            {
                ErrorMessages = "Select a register, then write only the fields to modify";
                MessageBoxResult result = MessageBox.Show(ErrorMessages, "Update Error!!:");
            }
        }

        public void DelExam()
        {
            var exam = new Exam();
            exam = SelectedItem;
            if (SelectedItem != null)
            {
                var dr = exam.Delete();

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
                MessageBoxResult message = MessageBox.Show("Please, select a register to delete", "Delete Error!!:");
            }

            GetExams();
        }

        public void ClearTxtBox()
        {
            Title = null;
            Text = null;
            Date = null;
        }

        public ICommand AddExamCommand { get; set; }
        public ICommand GetExamsCommand { get; set; }
        public ICommand DeleteExamCommand { get; set; }
        public ICommand UpdateExamCommand { get; set; }

    }
}
