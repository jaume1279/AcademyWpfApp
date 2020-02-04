using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using System;
using System.Collections.Generic;

namespace Academy.Lib.Models
{
    public class StudentSubject : Entity
    {
        public Student Student
        {
            get
            {
                var repo = Entity.DepCon.Resolve<IRepository<Student>>();
                var student = repo.Find(StudentId);
                return student;
            }
        }
        public Guid StudentId { get; set; }
        public Subject Subject
        {
            get
            {
                var repo = Entity.DepCon.Resolve<IRepository<Subject>>();
                var subject = repo.Find(SubjectId);
                return subject;
            }
        }
        public Guid SubjectId { get; set; }
        public StudentSubject()
        {
        }


        public static ValidationResult<string> ValidateStud(Guid stud)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if ((string.IsNullOrEmpty(stud.ToString())) || (stud == Guid.Empty))
            {
                output.IsSuccess = false;
                output.Errors.Add("Student is empty");
            }

            if (output.IsSuccess)
                output.ValidatedResult = stud.ToString();


            return output;
        }

        public void ValidateStud(ValidationResult validationResult)
        {
            var validateStudResult = ValidateStud(this.StudentId);
            if (!validateStudResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateStudResult.Errors);
            }
        }

        public static ValidationResult<string> ValidateSubject(Guid subj)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if ((string.IsNullOrEmpty(subj.ToString())) || (subj == Guid.Empty))
            {
                output.IsSuccess = false;
                output.Errors.Add("Subject is empty");
            }

            if (output.IsSuccess)
                output.ValidatedResult = subj.ToString();

            return output;
        }

        public void ValidateSubject(ValidationResult validationResult)
        {
            var validateSubjectResult = ValidateSubject(this.SubjectId);
            if (!validateSubjectResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateSubjectResult.Errors);
            }
        }

        public static ValidationResult<string> ValidateExists(Guid student, Guid subject, Guid currentId = default)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            #region check if couple (StudentId & SubjectId) exists

            var repoSet = Entity.DepCon.Resolve<IRepository<StudentSubject>>();

            foreach (var item in repoSet.QueryAll())
            {
                if (item.StudentId == student)
                {
                    if (item.SubjectId == subject)
                    {
                        if (currentId == default)       // Add
                        {
                            output.IsSuccess = false;
                            output.Errors.Add($"There exists this element in StudentSubject in {item.Id}");
                            //  return output;
                        }
                        else    // Delete
                        {
                            return output;
                        }

                    }
                }
            }
            #endregion

            return output;

        }

        public void ValidateExists(ValidationResult validationResult)
        {
            var validateExistsResult = ValidateExists(this.StudentId, this.SubjectId, this.Id);
            if (!validateExistsResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateExistsResult.Errors);
            }
        }

        public override ValidationResult Validate()
        {
            var output = base.Validate();

            ValidateStud(output);
            ValidateSubject(output);
            ValidateExists(output);
            ValidateStudSubjectHasExams(output);

            return output;
        }

        public SaveResult<StudentSubject> Save()
        {
            var saveResult = base.Save<StudentSubject>();
            return saveResult;
        }

        public DeleteResult<StudentSubject> Delete()
        {
            var deleteResult = base.Delete<StudentSubject>();
            return deleteResult;
        }

        public static ValidationResult<string> ValidateStudSubjectHasExams(Guid studSubj = default)
        {
            if (studSubj != default)
            {
                var output = new ValidationResult<string>()
                {
                    IsSuccess = true
                };

                var repoStudExams = Entity.DepCon.Resolve<IRepository<StudentExam>>();
                var repoExams = Entity.DepCon.Resolve<IRepository<Exam>>();
                var repoStudSubject = Entity.DepCon.Resolve<IRepository<StudentSubject>>();

                var StudSubjToEvaluate = repoStudSubject.Find(studSubj);
                var ExamsWithStudent = new List<Exam>();
                if (StudSubjToEvaluate != null)
                {
                    foreach (var item in repoStudExams.QueryAll())
                    {
                        if (item.StudentId == StudSubjToEvaluate.StudentId)
                        {
                            ExamsWithStudent.Add(item.Exam);        // List of exams has made the Student
                            if (ExamsWithStudent.Exists(x => x.SubjectId == StudSubjToEvaluate.SubjectId))
                            {
                                output.IsSuccess = false;
                                output.Errors.Add($"Couldn't Delete {StudSubjToEvaluate.Student.Name}-{StudSubjToEvaluate.Subject.Name} because it has existing Exams");
                                return output;
                            }
                        }
                    }
                }
                return output;
            }
            else
            {
                return null;
            }



        }

        public void ValidateStudSubjectHasExams(ValidationResult validationResult)
        {
            if (this.Id != default)
            {
                var validateStudSubjResult = ValidateStudSubjectHasExams(this.Id);
                if (!validateStudSubjResult.IsSuccess)
                {
                    validationResult.IsSuccess = false;
                    validationResult.Errors.AddRange(validateStudSubjResult.Errors);
                }
            }

        }
    }
}
