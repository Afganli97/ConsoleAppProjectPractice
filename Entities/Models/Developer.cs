using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Entities.Models
{
    public class Developer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Project project { get; set; }
        public List<string> Skills { get; set; }
    }
}
