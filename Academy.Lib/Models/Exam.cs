using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.Lib.Models
{
    public class Exam : Entity
    {
        public string Title { get; set; }

        public string Text { get; set; }
        public string Date { get; set; }

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


        public Exam()
        {
        }

        #region Static Validations

        public static ValidationResult<string> ValidateTitle(string title, Guid currentId = default)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(title))
            {
                output.IsSuccess = false;
                output.Errors.Add("Exam Title is empty");
            }

            if (output.IsSuccess)
                output.ValidatedResult = title;


            return output;
        }

        #endregion

        public void ValidateTitle(ValidationResult validationResult)
        {
            var validateTitleResult = ValidateTitle(this.Title);
            if (!validateTitleResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateTitleResult.Errors);
            }
        }

        public static ValidationResult<string> ValidateText(string text)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(text))
            {
                output.IsSuccess = false;
                output.Errors.Add("Exam Text is empty");
            }

            if (output.IsSuccess)
                output.ValidatedResult = text;


            return output;
        }


        public void ValidateText(ValidationResult validationResult)
        {
            var validateTextResult = ValidateText(this.Text);
            if (!validateTextResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateTextResult.Errors);
            }
        }

        public static ValidationResult<string> ValidateDate(string date)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(date))
            {
                output.IsSuccess = false;
                output.Errors.Add("Exam Date is empty");
            }

            if (output.IsSuccess)
                output.ValidatedResult = date;


            return output;
        }


        public void ValidateDate(ValidationResult validationResult)
        {
            var validateDateResult = ValidateDate(this.Date);
            if (!validateDateResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateDateResult.Errors);
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

        public static ValidationResult<string> ValidateExists(string title, string text, string date, Guid subject, Guid currentId = default)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            #region check if exam (Title, Text, Date & SubjectId) exists

            var repoSet = Entity.DepCon.Resolve<IRepository<Exam>>();

            foreach (var item in repoSet.QueryAll())
            {
                if ((item.Title == title) && (item.Text == text) && (item.Date == date) && (item.SubjectId == subject))
                {
                    if (currentId == default)           // Add
                    {
                        output.IsSuccess = false;
                        output.Errors.Add($"There exists this element in Exam in {item.Id}");
                        return output;
                    }
                    if (item.Id == currentId)           // Delete. If Update: we allow this validation, so the object is the same
                    {
                        return output;
                    }
                    else            // Update failed, this exam yet exist
                    {
                        output.IsSuccess = false;
                        output.Errors.Add($"Couldn't Update. The same data exists in Exam: {item.Id} ");
                        return output;
                    }
                }
            }

            return output;

            #endregion
        }


        public void ValidateExists(ValidationResult validationResult)
        {
            var validateExamResult = ValidateExists(this.Title, this.Text, this.Date, this.SubjectId, this.Id);
            if (!validateExamResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateExamResult.Errors);
            }
        }

        public SaveResult<Exam> Save()
        {
            var saveResult = base.Save<Exam>();
            return saveResult;
        }


        public override ValidationResult Validate()
        {
            var output = base.Validate();

            ValidateTitle(output);
            ValidateText(output);
            ValidateDate(output);
            ValidateSubject(output);
            ValidateExists(output);
            ValidateExamsIsNotInStudentExam(output);

            return output;
        }

        public DeleteResult<Exam> Delete()
        {
            var deleteResult = base.Delete<Exam>();
            return deleteResult;
        }

        public static ValidationResult<string> ValidateExamsIsNotInStudentExam(Guid exam = default)
        {       // Check before Delete. Exams must not exist in any StudentExam. Otherwise couldn't delete
            if (exam != default)
            {
                var output = new ValidationResult<string>()
                {
                    IsSuccess = true
                };

                var repoStudExams = Entity.DepCon.Resolve<IRepository<StudentExam>>();

                foreach (var item in repoStudExams.QueryAll())
                {
                    if (item.ExamId == exam)
                    {
                        output.IsSuccess = false;
                        output.Errors.Add($"Couldn't delete Exam: {item.Exam.Title} " +
                            $"Date:{item.Exam.Date} because at least one Student has taken it: {item.Student.Name}");
                        return output;
                    }
                }
                return output;
            }
            else
            {
                return null;
            }
        }


        public void ValidateExamsIsNotInStudentExam(ValidationResult validationResult)
        {
            if (this.Id != default)
            {
                var validateExamsNotStudExamsResult = ValidateExamsIsNotInStudentExam(this.Id);
                if (!validateExamsNotStudExamsResult.IsSuccess)
                {
                    validationResult.IsSuccess = false;
                    validationResult.Errors.AddRange(validateExamsNotStudExamsResult.Errors);
                }
            }

        }
    }
}
