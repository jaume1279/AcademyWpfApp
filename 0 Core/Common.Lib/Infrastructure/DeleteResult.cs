using Common.Lib.Core;
using System;

namespace Common.Lib.Infrastructure
{
    public class DeleteResult<T> where T : Entity
    {
        public ValidationResult Validation { get; set; } = new ValidationResult();

        public bool IsSuccess
        {
            get
            {
                return Validation.IsSuccess;
            }
            set
            {
                Validation.IsSuccess = value;
            }
        }

        public string AllErrors
        {
            get
            {
                return Validation.AllErrors;
            }
        }
        
       // public Guid Id { get; set; }

        public T Entity { get; set; }

        public DeleteResult<TOut> Cast<TOut>() where TOut : Entity
        {
            var output = new DeleteResult<TOut>
            {
                //Id = this.Id,
                Entity = this.Entity as TOut,
                Validation = this.Validation
            };

            return output;
        }
        //public SaveResult<TOut> Cast<TOut>() where TOut : Entity
        //{
        //    var output = new SaveResult<TOut>
        //    {
        //        Entity = this.Entity as TOut,
        //        Validation = this.Validation
        //    };

        //    return output;
        //}
    }
}
