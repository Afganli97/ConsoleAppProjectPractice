using System;

namespace Utilities
{
    public class Helper
    {
        public static void Display(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public enum GlobalMethods
        {
            GetProjectMethods = 1,
            GetDeveloperMethods
        }
        public enum ProjectMethods
        {
            Create= 1,
            GetById,
            GetByName,
            GetAll,
            GetAllInProject,
            Update,
            Delete
        }
        public enum DeveloperMethods
        {
            Create = 1,
            GetById,
            GetByName,
            GetAll,
            GetSkills,
            GetAllSkills,
            Update,
            UpdateSkills,
            Delete,
        }
    }
}
