using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    internal class Project : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static int NumberOfDevelopers { get; set; }
    }
}
