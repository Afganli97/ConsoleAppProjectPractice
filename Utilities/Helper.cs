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

        #region ProjectMethods
        public enum ProjectMethods
        {
            Create = 1,
            Read,
            Update,
            Delete
        }
        public enum ProjectReadMethods
        {
            GetById = 1,
            GetByName,
            GetAll,
            GetAllInProject,
        }
        #endregion

        #region DeveloperMethods
        public enum DeveloperMethods
        {
            Create = 1,
            Read,
            Update,
            Delete,
        }
        public enum DeveloperReadMethods
        {
            GetById = 1,
            GetByName,
            GetAll,
            GetSkills,
            GetAllSkills
        }
        public enum DeveloperUpdateMethods
        {
            UpdateProject = 1,
            UpdateSkills
        }
        #endregion
    }
}
