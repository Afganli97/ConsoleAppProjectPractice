using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {
        public bool Create(Project entity)
        {
            try
            {
                DbContext.projects.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Project entity)
        {
            try
            {
                DbContext.projects.Remove(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Project Get(Predicate<Project> filter = null)
        {
            return filter == null ? DbContext.projects[0] : DbContext.projects.Find(filter);
        }

        public List<Project> GetAll(Predicate<Project> filter = null)
        {
            return filter == null ? DbContext.projects : DbContext.projects.FindAll(filter);
        }

        public bool Update(Project entity)
        {
            try
            {
                Project project = Get(p => p.Name.ToLower() == entity.Name.ToLower());
                project = entity;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
