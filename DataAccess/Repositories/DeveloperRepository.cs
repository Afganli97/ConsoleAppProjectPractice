
using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class DeveloperRepository : IRepository<Developer>
    {
        public bool Create(Developer entity)
        {
            try
            {
                DbContext.developers.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Developer entity)
        {
            try
            {
                DbContext.developers.Remove(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Developer Get(Predicate<Developer> filter = null)
        {
            return filter == null ? DbContext.developers[0] : DbContext.developers.Find(filter);
        }

        public List<Developer> GetAll(Predicate<Developer> filter = null)
        {
            return filter == null ? DbContext.developers : DbContext.developers.FindAll(filter);
        }

        public bool Update(Developer entity)
        {
            try
            {
                Developer developer = Get(p => p.Name.ToLower() == entity.Name.ToLower());
                developer = entity;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
