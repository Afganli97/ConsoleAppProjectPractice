using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace ConsoleAppProjectPractice.Controllers
{
    public class ProjectController
    {
        public ProjectService projectService { get; set; }
        public ProjectController()
        {
            projectService = new ProjectService();
        }
        public void SelectProjectMenu(out int selectMenu)
        {
            Console.Clear();
            Helper.Display(ConsoleColor.Blue, "1.Create project\n2.Update project\n3.Delete project\n4.Get by id\n5.Get by name\n6.Get all\n0.Return back");
        WriteMenuAgain: string selectMenuString = Console.ReadLine();
            bool isChangeMenu = Int32.TryParse(selectMenuString, out selectMenu);
            if (!isChangeMenu || selectMenu > 6 || selectMenu < 0)
            {
                Helper.Display(ConsoleColor.DarkRed, "Select menu correct");
                goto WriteMenuAgain;
            }
            
        }
        public void Create()
        {
            Helper.Display(ConsoleColor.DarkYellow, "Enter project name");
            string name = string.Empty;
        WriteNameAgain: name = Console.ReadLine();
            name = name.Trim();
            if (name != string.Empty)
            {
                Project project = new Project();
                project.Name = name;
                if (projectService.Create(project) != null)
                    Helper.Display(ConsoleColor.DarkGreen, "Project created");
                else
                    Helper.Display(ConsoleColor.DarkRed, "Error");
            }
            else
            {
                Helper.Display(ConsoleColor.Red, "Enter name again");
                goto WriteNameAgain;
            }

        }
        public void Delete()
        {
            Helper.Display(ConsoleColor.DarkYellow, "Enter project id");
        WriteIdAgain: string idString = Console.ReadLine();
            bool isChangeId = Int32.TryParse(idString, out int id);
            if (isChangeId)
            {
                if (projectService.Delete(id) != null)
                    Helper.Display(ConsoleColor.DarkGreen, "Project deleted");
                else
                    Helper.Display(ConsoleColor.DarkRed, "There is no project under this id");
            }
            else
            {
                Helper.Display(ConsoleColor.Red, "Enter id correctly");
                goto WriteIdAgain;
            }

        }
        public void Update()
        {
            Helper.Display(ConsoleColor.DarkYellow, "Enter project id");
        WriteIdAgain: string idString = Console.ReadLine();
            bool isChangeId = Int32.TryParse(idString, out int id);
            if (isChangeId)
            {
                Project project = projectService.Get(id);
                if (project != null)
                {
                    Helper.Display(ConsoleColor.DarkYellow, "Enter new name");
                    string newName = Console.ReadLine();
                    project.Name = newName;
                    Helper.Display(ConsoleColor.DarkGreen, "Project updated");
                }
                else
                    Helper.Display(ConsoleColor.DarkRed, "There is no project under this id");
            }
            else
            {
                Helper.Display(ConsoleColor.Red, "Enter id correctly");
                goto WriteIdAgain;
            }
        }
        public void GetById()
        {
            Helper.Display(ConsoleColor.DarkYellow, "Enter project id");
        WriteIdAgain: string idString = Console.ReadLine();
            bool isChangeId = Int32.TryParse(idString, out int id);
            if (!isChangeId)
            {
                Helper.Display(ConsoleColor.Red, "Enter id correctly");
                goto WriteIdAgain;
            }
            Project project = projectService.Get(id);
            if (project != null)
            {
                Helper.Display(ConsoleColor.DarkGray, project.Id + " " + project.Name);
            }
            else
                Helper.Display(ConsoleColor.DarkRed, "There is no project under this id");
        }
        public void GetByName()
        {
            Helper.Display(ConsoleColor.DarkYellow, "Enter project name");
            string name = Console.ReadLine();
            Project project = projectService.Get(name);
            if (project != null)
                Helper.Display(ConsoleColor.DarkGray, project.Id + " " + project.Name);
            else
                Helper.Display(ConsoleColor.DarkRed, "There is no project under this name");

        }
        public void GetAll()
        {
            List<Project> projects = projectService.GetAll();
            if (projects.Count != 0)
            {
                foreach (var item in projects)
                {
                    Helper.Display(ConsoleColor.DarkGray, item.Id + " " + item.Name);
                }
            }
            else
                Helper.Display(ConsoleColor.Red, "Has not any projects");

        }
    }
}
