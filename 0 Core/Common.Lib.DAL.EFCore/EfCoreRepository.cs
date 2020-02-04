using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Common.Lib.DAL.EFCore
{
    public class EfCoreRepository<T> : IRepository<T> where T : Entity
    {
        DbContext DbContext { get; set; }

        DbSet<T> DbSet
        {
            get
            {
                return DbContext.Set<T>();
            }
        }

        public EfCoreRepository()
        {

        }

        public EfCoreRepository(DbContext context)
        {
            DbContext = context;
        }

        public IQueryable<T> QueryAll()
        {
            return DbSet.AsQueryable();
        }
        public T Find(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual SaveResult<T> Add(T entity)
        {
            // creo una conexión contra la DB guardo la entity y le devuelvo 
            // a quien me haya hecho la llamada
            var output = new SaveResult<T>
            {
                IsSuccess = true
            };

            if (entity.Id == default(Guid))
                entity.Id = Guid.NewGuid();

            if (DbSet.Any(x => x.Id == entity.Id))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("Ya existe una entity con ese id");
            }

            if (output.IsSuccess)
            {
                DbSet.Add(entity);
                DbContext.SaveChanges();
            }

            return output;
        }

        public virtual SaveResult<T> Update(T entity)
        {
            var output = new SaveResult<T>
            {
                IsSuccess = true
            };

            if (entity.Id == default(Guid))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No se puede actualizar una entidad sin Id");
            }

            //if (entity.Id != default(Guid) && !DbSet.Any(x => x.Id == entity.Id))
            if (entity.Id != default(Guid) && DbSet.All(x => x.Id != entity.Id)) // esta es mejor porque tiene mejor performance
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No existe una entity con ese id");
            }

            if (output.IsSuccess)
            {
                DbSet.Update(entity);
                DbContext.SaveChanges();  //Added Jaume 16/01/2020
            }

            return output;
        }

        public virtual DeleteResult<T> Delete(T entity)
        {
            var output = new DeleteResult<T>()
            {
                IsSuccess = true
            };

            if (DbSet.All(x => x.Id != entity.Id))
            {
                output.IsSuccess = false;
                output.Validation.Errors.Add("No existe una entity con ese id");
            }

            if (output.IsSuccess)
            {
                DbSet.Remove(entity);
                DbContext.SaveChanges();    // Added Jaume 15/01/2020
            }

            return output;
        }
    }
}