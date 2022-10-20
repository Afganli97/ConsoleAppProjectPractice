using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IProject
    {
        Project Create(Project project);
        Project Update(int id, Project project);
        Project Delete(int id);
        List<Project> GetAll();
        Project Get(int id);
        Project Get(string name);
    }
}
