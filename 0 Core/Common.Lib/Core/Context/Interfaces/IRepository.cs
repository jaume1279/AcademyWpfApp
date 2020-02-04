using Common.Lib.Infrastructure;
using System;
using System.Linq;

namespace Common.Lib.Core.Context
{
    /// <summary>
    /// Basic CRUD methods 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> QueryAll();

        T Find(Guid id);

        SaveResult<T> Add(T entity);

        SaveResult<T> Update(T entity);

        DeleteResult<T> Delete(T entity);
    }
}
