using Entities.Models;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public static class DbContext
    {
        public static List<Project> projects;
        public static List<Developer> developers;
        static DbContext()
        {
            projects = new List<Project>();
            developers = new List<Developer>();
        }
    }
}
