using Academy.Lib.Models;
using Academy.Lib.UI;
using Common.Lib.Core;
using Common.Lib.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Academy.ViewModels
{
    public class StatsStudentViewModel : ViewModelBase
    {

        public StatsStudentViewModel()
        {
            GetExamsByStudentCommand = new RouteCommand(GetExamsByStudent);
            ClearCboStudentsCommand = new RouteCommand(ClearCboStudents);
            GetSubjectsByStudentCommand = new RouteCommand(GetSubjectsByStudentList);
        }


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

        private List<StudentExam> _examsByStudentList = new List<StudentExam>();
        public List<StudentExam> ExamsByStudentList
        {
            get
            {
                return _examsByStudentList;
            }
            set
            {
                _examsByStudentList = value;
                OnPropertyChanged();
            }
        }

        private List<StudentSubject> _subjectsByStudentList = new List<StudentSubject>();

        public List<StudentSubject> SubjectsByStudentList
        {
            get
            {
                return _subjectsByStudentList;
            }
            set
            {
                _subjectsByStudentList = value;
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

        private Double __minMark;
        public Double MinMark
        {
            get
            {
                return __minMark;
            }
            set
            {
                if (__minMark == value)
                {
                    return;
                }

                __minMark = value;
                OnPropertyChanged();
            }
        }

        private Double __maxMark;
        public Double MaxMark
        {
            get
            {
                return __maxMark;
            }
            set
            {
                if (__maxMark == value)
                {
                    return;
                }

                __maxMark = value;
                OnPropertyChanged();
            }
        }

        private Double __avgMark;
        public Double AvgMark
        {
            get
            {
                return __avgMark;
            }
            set
            {
                if (__avgMark == value)
                {
                    return;
                }

                __avgMark = value;
                OnPropertyChanged();
            }
        }

        public void GetStudentsList()       // Fill the ComboBox Students
        {
            var repo = Student.DepCon.Resolve<IRepository<Student>>();
            StudentsList = repo.QueryAll().ToList();
        }

        public void GetSubjectsByStudentList()
        {
            var repo = Entity.DepCon.Resolve<IRepository<StudentSubject>>();

            SubjectsByStudentList = repo.QueryAll().Where(x => x.StudentId == SelectedItemComboStudent.Id).ToList();
        }

        public void GetExamsByStudent()
        {
            var repo = Entity.DepCon.Resolve<IRepository<StudentExam>>();

            ExamsByStudentList = repo.QueryAll().Where(x => x.StudentId == SelectedItemComboStudent.Id).ToList();

            Stats(ExamsByStudentList);
        }

        public void Stats(List<StudentExam> exams)
        {
            if (exams.Count != 0)
            {
                MinMark = Math.Round(exams.Min(x => x.Mark), 2);
                AvgMark = Math.Round(exams.Average(x => x.Mark), 2);
                MaxMark = Math.Round(exams.Max(x => x.Mark), 2);
            }

        }

        public void ClearCboStudents()
        {
            GetStudentsList();
        }

        public ICommand ClearCboStudentsCommand { get; set; }

        public ICommand GetSubjectsByStudentCommand { get; set; }
        public ICommand GetExamsByStudentCommand { get; set; }

    }
}
