using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using System;
using System.Linq;

namespace Academy.Lib.Models
{
    public class Student : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Dni { get; set; }

        public int ChairNumber { get; set; }

        public Student()
        {
        }

        #region Static Validations

        public static ValidationResult<string> ValidateName(string name)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(name))
            {
                output.IsSuccess = false;
                output.Errors.Add("Student name is empty");
            }

            if (output.IsSuccess)
                output.ValidatedResult = name;


            return output;
        }

        #endregion

        public void ValidateName(ValidationResult validationResult)
        {
            var validateNameResult = ValidateName(this.Name);
            if (!validateNameResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateNameResult.Errors);
            }
        }
        public static ValidationResult<string> ValidateEmail(string email)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(email))
            {
                output.IsSuccess = false;
                output.Errors.Add("Student email is empty");
            }

            if (output.IsSuccess)
                output.ValidatedResult = email;

            return output;
        }

        public void ValidateEmail(ValidationResult validationResult)
        {
            var validateEmailResult = ValidateEmail(this.Email);
            if (!validateEmailResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateEmailResult.Errors);
            }
        }

        public static ValidationResult<string> ValidateDni(string dni, Guid currentId = default)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(dni))
            {
                output.IsSuccess = false;
                output.Errors.Add("Student dni is empty");
            }

            #region check duplication

            var repo = Entity.DepCon.Resolve<IRepository<Student>>();

            var entityWithDni = repo.QueryAll().FirstOrDefault(item => item.Dni == dni);
            if (entityWithDni == null)
            {
                entityWithDni = new Student();
            }

            if (currentId == default && entityWithDni.Dni != null)      // Ok new Student
            {
                // on create
                output.IsSuccess = false;
                output.Errors.Add("There is a Student with this Dni");
            }
            else if (currentId != default && entityWithDni.Id != currentId && entityWithDni.Dni == dni)
            {
                // on update, runs ok for Email, Name & ChairNumber, also for change Dni
                output.IsSuccess = false;
                output.Errors.Add("There is a Student with this Dni");
            }
            #endregion

            if (output.IsSuccess)
            {
                output.ValidatedResult = dni;
            }

            return output;
        }

        public static ValidationResult<int> ValidateChairNumber(string chairNumberText, Guid currentId = default)
        {
            var output = new ValidationResult<int>()
            {
                IsSuccess = true
            };

            var chairNumber = 0;
            var isConversionOk = false;

            #region check null or empty
            if (string.IsNullOrEmpty(chairNumberText))
            {
                output.IsSuccess = false;
                output.Errors.Add("Chair Number couldn't be empty or null");
            }
            #endregion

            #region check format conversion

            isConversionOk = int.TryParse(chairNumberText, out chairNumber);

            if (!isConversionOk)
            {
                output.IsSuccess = false;
                output.Errors.Add($"Chair '{chairNumberText}' its not a Number");
            }

            #endregion

            #region check if the chair is already in use

            if (isConversionOk)
            {
                var repoStudents = Entity.DepCon.Resolve<IRepository<Student>>();
                var currentStudentInChair = repoStudents.QueryAll().FirstOrDefault(s => s.ChairNumber == chairNumber);

                if (currentStudentInChair != null && currentStudentInChair.Id != currentId)
                {
                    output.IsSuccess = false;
                    output.Errors.Add($"There's a Student {currentStudentInChair.Name} in the chair {chairNumber}");
                }
            }
            #endregion

            if (output.IsSuccess)
                output.ValidatedResult = chairNumber;

            return output;
        }

        public void ValidateDni(ValidationResult validationResult)
        {
            var vr = ValidateDni(this.Dni, this.Id);

            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }
        }

        public void ValidateChairNumber(ValidationResult validationResult)
        {
            var vr = ValidateChairNumber(this.ChairNumber.ToString(), this.Id);

            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }
        }

        public static ValidationResult<string> ValidateExists(Guid currentId = default)
        {
            //  Check if this Student exists in StudentsSubject. If exists, return IsSucces=false to Delete request

            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            #region check if StudentId exists in StudentSubject

            if (currentId != default)
            {
                var repoStudSubj = Entity.DepCon.Resolve<IRepository<StudentSubject>>();

                var StudRegisterSubjects = repoStudSubj.QueryAll().Count(x => x.StudentId == currentId);
                if (StudRegisterSubjects > 0)
                {
                    output.IsSuccess = false;
                    output.Errors.Add($"Couldn't Delete this Student. This Student is registered in {StudRegisterSubjects} Subjects.");
                    return output;
                }
            }

            return output;

            #endregion
        }

        public void ValidateExists(ValidationResult validationResult)
        {
            var vr = ValidateExists(this.Id);

            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }
        }

        public SaveResult<Student> Save()
        {
            var saveResult = base.Save<Student>();
            return saveResult;
        }

        public override ValidationResult Validate()
        {
            var output = base.Validate();

            ValidateName(output);
            ValidateDni(output);
            ValidateEmail(output);
            ValidateChairNumber(output);
            ValidateExists(output);

            return output;
        }

        public DeleteResult<Student> Delete()
        {
            var deleteResult = base.Delete<Student>();
            return deleteResult;
        }
    }
}
