using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IDeveloper
    {
        Developer Create(Developer developer, string projectName);
        Developer Update(int id, Developer developer);
        Developer Delete(int id);
        List<Developer> GetAll();
        Developer Get(int id);
        Developer Get(string name);
    }
}
