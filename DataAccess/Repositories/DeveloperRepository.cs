
using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class DeveloperRepository : IRepository<Developer>
    {
        public bool Add(Developer entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Developer entity)
        {
            throw new NotImplementedException();
        }

        public Developer Get(Predicate<Developer> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Developer> GetAll(Predicate<Developer> filter = null)
        {
            throw new NotImplementedException();
        }

        public bool Update(Developer entity)
        {
            throw new NotImplementedException();
        }
    }
}
