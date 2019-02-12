using System;
using System.Collections.Generic;

namespace DAL.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> filter = null);
        TEntity GetByID(object id);
        void Add(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
        void Update(TEntity entityToUpdate);
        void SaveChanges();

    }
}