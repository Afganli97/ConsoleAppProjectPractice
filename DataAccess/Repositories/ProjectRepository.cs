using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {
        public bool Add(Project entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Project entity)
        {
            throw new NotImplementedException();
        }

        public Project Get(Predicate<Project> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAll(Predicate<Project> filter = null)
        {
            throw new NotImplementedException();
        }

        public bool Update(Project entity)
        {
            throw new NotImplementedException();
        }
    }
}
