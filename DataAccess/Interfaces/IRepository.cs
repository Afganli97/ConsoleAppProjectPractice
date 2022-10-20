using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        bool Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        T Get(Predicate<T> filter = null);
        List<T> GetAll(Predicate<T> filter = null);
    }
}
