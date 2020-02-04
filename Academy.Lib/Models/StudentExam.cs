using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.Lib.Models
{
    public class StudentExam : Entity
    {
        public Exam Exam
        {
            get
            {
                var repo = Entity.DepCon.Resolve<IRepository<Exam>>();
                var exam = repo.Find(ExamId);
                return exam;
            }
        }
        public Guid ExamId { get; set; }

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

        public double Mark { get; set; }

        public bool HasCheated { get; set; }

        public StudentExam()
        {

        }

        public static ValidationResult<string> ValidateHasCheated(bool hasCheated)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(hasCheated.ToString()))
            {
                output.IsSuccess = false;
                output.Errors.Add("HasCheated is empty");
            }

            if (output.IsSuccess)
                output.ValidatedResult = hasCheated.ToString();


            return output;
        }


        public void ValidateHasCheated(ValidationResult validationResult)
        {
            var validateHasCheatedResult = ValidateHasCheated(this.HasCheated);
            if (!validateHasCheatedResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateHasCheatedResult.Errors);
            }
        }

        public static ValidationResult<string> ValidateMark(string markTxt, Guid currentId = default)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };
            Double mark;
            if (double.TryParse(markTxt.Replace(".", ","), out mark))    //Es numero
            {
                if ((mark < 0.0) || (mark > 10.0))
                {
                    output.IsSuccess = false;
                    output.Errors.Add("Out of Range: Mark must be between 0.0 and 10.0");
                }

            }
            else    // TryParse False
            {
                output.IsSuccess = false;
                output.Errors.Add($"[{markTxt}] is not a valid Mark");
            }
            if (currentId == default)            // Only check if it's empty when Add. On Update don't check
            {
                if (string.IsNullOrEmpty(markTxt))
                {
                    output.IsSuccess = false;
                    output.Errors.Add("Mark is empty");
                }
            }


            if (output.IsSuccess)
                output.ValidatedResult = mark.ToString();


            return output;
        }


        public void ValidateMark(ValidationResult validationResult)
        {
            var validateMarkResult = ValidateMark(this.Mark.ToString());
            if (!validateMarkResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateMarkResult.Errors);
            }
        }

        public static ValidationResult<string> ValidateStudent(Guid stud)
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

        public void ValidateStudent(ValidationResult validationResult)
        {
            var validateStudentResult = ValidateStudent(this.StudentId);
            if (!validateStudentResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateStudentResult.Errors);
            }
        }

        public static ValidationResult<string> ValidateExam(Guid exam)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if ((string.IsNullOrEmpty(exam.ToString())) || (exam == Guid.Empty))
            {
                output.IsSuccess = false;
                output.Errors.Add("Exam is empty");
            }

            if (output.IsSuccess)
                output.ValidatedResult = exam.ToString();

            return output;
        }

        public void ValidateExam(ValidationResult validationResult)
        {
            var validateExamResult = ValidateExam(this.ExamId);
            if (!validateExamResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateExamResult.Errors);
            }
        }

        public static ValidationResult<string> ValidateExists(Guid student, Guid exam, Guid currentId = default)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            #region check if StudentExam (StudentId & ExamId) exists

            var repoSet = Entity.DepCon.Resolve<IRepository<StudentExam>>();

            foreach (var item in repoSet.QueryAll())
            {
                if ((item.StudentId == student) && (item.ExamId == exam))
                {
                    if (currentId == default)   // Add
                    {
                        output.IsSuccess = false;
                        output.Errors.Add($"There exists this element in StudentExam in {item.Id}");
                        return output;
                    }
                    else if (item.Id != currentId)  // Update
                    {
                        output.IsSuccess = false;
                        output.Errors.Add($"Couldn't Update. The same data exists in StudentExam: {item.Id} ");
                        return output;
                    }
                }
            }


            var repoExam = Entity.DepCon.Resolve<IRepository<Exam>>();
            foreach (var itemExam in repoExam.QueryAll())
            {
                if (itemExam.Id == exam)
                {
                    var repoRegister = Entity.DepCon.Resolve<IRepository<StudentSubject>>();
                    foreach (var itemReg in repoRegister.QueryAll())
                    {
                        if (itemReg.StudentId == student)
                        {
                            if (itemExam.SubjectId == itemReg.SubjectId)
                            {
                                return output;
                            }
                        }
                    }
                    output.IsSuccess = false;
                    output.Errors.Add($"This Student is not registered in {itemExam.Subject.Name}. Register before assign exams");
                    return output;
                }
            }

            return output;

            #endregion
        }

        public void ValidateExists(ValidationResult validationResult)
        {
            var validateStudentExamResult = ValidateExists(this.StudentId, this.ExamId, this.Id);
            if (!validateStudentExamResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateStudentExamResult.Errors);
            }
        }


        public SaveResult<StudentExam> Save()
        {
            var saveResult = base.Save<StudentExam>();
            return saveResult;
        }

        public override ValidationResult Validate()
        {
            var output = base.Validate();

            ValidateHasCheated(output);
            ValidateMark(output);
            ValidateExam(output);
            ValidateStudent(output);
            ValidateExists(output);

            return output;
        }

        public DeleteResult<StudentExam> Delete()
        {
            var deleteResult = base.Delete<StudentExam>();
            return deleteResult;
        }

    }
}
