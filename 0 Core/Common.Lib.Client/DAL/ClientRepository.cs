using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using System;
using System.Linq;

namespace Common.Lib.DAL.EFCore
{
    public class ClientRepository<T> : IRepository<T> where T : Entity
    {
        public virtual SaveResult<T> Add(T entity)
        {

            // creo una llamada a la web y le paso el entity en formato json
            throw new NotImplementedException();
        }

        public DeleteResult<T> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> QueryAll()
        {
            throw new NotImplementedException();
        }

        public SaveResult<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}