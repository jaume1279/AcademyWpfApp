using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using System;
using System.Linq;

namespace Academy.Lib.Models
{

    public class Subject : Entity
    {
        public string Name { get; set; }
        public string Teacher { get; set; }

        public Subject()
        {

        }
        #region Static Validations

        public static ValidationResult<string> ValidateTeacher(string teacher)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(teacher))
            {
                output.IsSuccess = false;
                output.Errors.Add("Teacher couldn't be empty");
            }

            if (output.IsSuccess)
                output.ValidatedResult = teacher;


            return output;
        }

        #endregion

        public void ValidateTeacher(ValidationResult validationResult)
        {
            var validateTeacherResult = ValidateTeacher(this.Teacher);
            if (!validateTeacherResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateTeacherResult.Errors);
            }
        }

        public static ValidationResult<string> ValidateName(string name, Guid currentId = default)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(name))
            {
                output.IsSuccess = false;
                output.Errors.Add("Name couldn't be empty");
            }

            #region check duplication
            var repo = Entity.DepCon.Resolve<IRepository<Subject>>();
            var existingSubject = repo.QueryAll().FirstOrDefault(item => item.Id == currentId);
            var entityWithName = repo.QueryAll().FirstOrDefault(item => item.Name == name);
            if (entityWithName == null)
            {
                entityWithName = new Subject();
            }

            if (currentId == default && entityWithName.Name != null)      // Ok new Subject
            {
                // on create
                output.IsSuccess = false;
                output.Errors.Add("Yet exists a subject with this name");
            }
            else if (currentId != default && entityWithName.Id != currentId && entityWithName.Name == name)
            {
                // on update
                output.IsSuccess = false;
                output.Errors.Add("Yet exists a subject with this name");
            }
            #endregion

            if (output.IsSuccess)
            {
                output.ValidatedResult = name;
            }

            return output;
        }


        public void ValidateName(ValidationResult validationResult)
        {
            var vr = ValidateName(this.Name, this.Id);

            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }
        }

        public static ValidationResult<string> ValidateExists(Guid currentId = default)
        {
            //  Check if this Subject exists in StudentsSubject. If exists, return IsSucces=false to Delete request
            //  Check if this Subject exists in Exams. If exists, return IsSucces=false to Delete request

            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            #region check if SubjectId exists in StudentSubject

            if (currentId != default)
            {
                var repoStudSubj = Entity.DepCon.Resolve<IRepository<StudentSubject>>();

                var StudRegisterSubjects = repoStudSubj.QueryAll().Count(x => x.SubjectId == currentId);
                if (StudRegisterSubjects > 0)
                {
                    output.IsSuccess = false;
                    output.Errors.Add($"Couldn't Delete this Subject. This Subject is registered by {StudRegisterSubjects} Students.");

                }

                // Check Exams with current Subject

                var repoExam = Entity.DepCon.Resolve<IRepository<Exam>>();

                var SubjectsWithExams = repoExam.QueryAll().Count(x => x.SubjectId == currentId);
                if (SubjectsWithExams > 0)
                {
                    output.IsSuccess = false;
                    output.Errors.Add($"Couldn't Delete this Subject. This Subject has {SubjectsWithExams} Exams created.");

                }
                return output;

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


        public SaveResult<Subject> Save()
        {
            var saveResult = base.Save<Subject>();
            return saveResult;
        }

        public override ValidationResult Validate()
        {
            var output = base.Validate();

            ValidateName(output);
            ValidateTeacher(output);
            ValidateExists(output);

            return output;
        }

        public DeleteResult<Subject> Delete()
        {
            var deleteResult = base.Delete<Subject>();
            return deleteResult;
        }
    }
}
