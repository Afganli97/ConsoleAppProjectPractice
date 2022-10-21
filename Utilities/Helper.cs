using ConsoleAppProjectPractice.Controllers;
using System;

namespace Utilities
{
    public class Helper
    {
        public static void Dsiplay(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public enum ProjectMethods
        {
            Create = 1,
            Update,
            Delete,
            GetById,
            GetByName,
            GetAll
        }
        public enum DeveloperMethods
        {
            Create = 1,
            Update,
            Delete,
            GetById,
            GetByName,
            GetAll
        }
    }
}
