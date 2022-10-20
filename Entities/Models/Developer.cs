using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Developer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
        public Project project { get; set; }
    }
}
