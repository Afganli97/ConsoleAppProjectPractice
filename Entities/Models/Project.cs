using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Entities.Models
{
    public class Project : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfDevelopers { get; set; }
        public List<Developer> developers;
        public Project()
        {
            NumberOfDevelopers++;
            developers = new List<Developer>();
        }
    }
}
