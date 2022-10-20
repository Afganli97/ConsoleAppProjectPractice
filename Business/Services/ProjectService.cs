using Business.Interfaces;
using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Services
{
    public class ProjectService : IProject
    {
        public ProjectRepository projectRepository { get; set; }
        public static int Count { get; set; }
        public ProjectService()
        {
            projectRepository = new ProjectRepository();
        }
        public Project Create(Project project)
        {
            try
            {
                Project existProject = projectRepository.Get(p=>p.Name.ToLower() == project.Name.ToLower());
                if (existProject != null)
                    return null;
                project.Id = ++Count;
                projectRepository.Create(project);
                return project;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Project Delete(int id)
        {
            try
            {
                Project existProject = projectRepository.Get(p => p.Id == id);
                if (existProject == null)
                    return null;
                projectRepository.Delete(existProject);
                return existProject;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Project Get(int id)
        {
            return projectRepository.Get(p=>p.Id == id);
        }

        public Project Get(string name)
        {
            return projectRepository.Get(p => p.Name.ToLower() == name.ToLower());
        }

        public List<Project> GetAll()
        {
            return projectRepository.GetAll();
        }

        public Project Update(int id, Project project)
        {
            try
            {
                Project existProject = projectRepository.Get(p=>p.Id == id);
                if (existProject != null)
                {
                    existProject.Name = project.Name;
                    return existProject;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
