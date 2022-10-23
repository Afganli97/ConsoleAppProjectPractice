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
        public DeveloperService developerService { get; set; }

        public ProjectController()
        {
            projectService = new ProjectService();
            developerService = new DeveloperService();
        }

        public void SelectProjectMenu(out int selectProjectMenu)
        {
            Console.Clear();
            Helper.Display(ConsoleColor.Blue, "1.Create project\n2.Read project\n3.Update project\n4.Delete project\n0.Return back");
        WriteMenuAgain: string selectMenuString = Console.ReadLine();
            bool isChangeMenu = Int32.TryParse(selectMenuString, out selectProjectMenu);
            if (!isChangeMenu || selectProjectMenu > 4 || selectProjectMenu < 0)
            {
                Helper.Display(ConsoleColor.DarkRed, "Select menu correct");
                goto WriteMenuAgain;
            }
        }

        public void SelectReadMenu(out int selectMenu)
        {
            Console.Clear();
            Helper.Display(ConsoleColor.Blue, "1.Get by id\n2.Get by name\n3.Get all projects\n4.Get all developers in project\n0.Return back");
        WriteMenuAgain: string selectMenuString = Console.ReadLine();
            bool isChangeMenu = Int32.TryParse(selectMenuString, out selectMenu);
            if (!isChangeMenu || selectMenu > 4 || selectMenu < 0)
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
                    Helper.Display(ConsoleColor.DarkRed, "Error!");
            }
            else
            {
                Helper.Display(ConsoleColor.Red, "Enter name again");
                goto WriteNameAgain;
            }

        }

        public void GetById()

        {
            List<Project> projects = projectService.GetAll();
            if (projects.Count != 0)
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
                    Helper.Display(ConsoleColor.DarkGray, "Id: " + project.Id + " Name: " + project.Name);
                }
                else
                    Helper.Display(ConsoleColor.DarkRed, "There is no project under this id!");
            }
            else
                Helper.Display(ConsoleColor.DarkRed, "Has not any projects!");
        }

        public void GetByName()
        {
            List<Project> projects = projectService.GetAll();
            if (projects.Count != 0)
            {
                Helper.Display(ConsoleColor.DarkYellow, "Enter project name");
                string name = Console.ReadLine();
                Project project = projectService.Get(name);
                if (project != null)
                    Helper.Display(ConsoleColor.DarkGray, "Id: " + project.Id + " Name: " + project.Name);
                else
                    Helper.Display(ConsoleColor.DarkRed, "There is no project under this name!");
            }
            else
                Helper.Display(ConsoleColor.DarkRed, "Has not any projects!");
        }

        public void GetAllInProject()
        {
            List<Project> projects = projectService.GetAll();
            if (projects.Count != 0)
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
                    List<Developer> developers = developerService.GetAll(project);
                    if (developers.Count != 0)
                    {
                        Helper.Display(ConsoleColor.DarkGray, project.Name + "'s developers: ");
                        foreach (var item in developers)
                        {
                            Helper.Display(ConsoleColor.DarkGray, "Id: " + item.Id + " Name: " + item.Name);
                        }
                    }
                    else
                        Helper.Display(ConsoleColor.DarkRed, "Has not any developers in this project!");
                }
                else
                {
                    Helper.Display(ConsoleColor.Red, "Enter id correctly");
                    goto WriteIdAgain;
                }
            }
            else
                Helper.Display(ConsoleColor.DarkRed, "Has not any projects!");
        }

        public void GetAll()
        {
            List<Project> projects = projectService.GetAll();
            if (projects.Count != 0)
            {
                foreach (var item in projects)
                {
                    Helper.Display(ConsoleColor.DarkGray, "Id: " + item.Id + " Name: " + item.Name);
                }
            }
            else
                Helper.Display(ConsoleColor.DarkRed, "Has not any projects!");
        }

        public void Update()
        {
            List<Project> projects = projectService.GetAll();
            if (projects.Count != 0)
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
                    WriteNameAgain: string newName = Console.ReadLine();
                        newName = newName.Trim();
                        if (newName != string.Empty)
                        {
                            project.Name = newName;
                            Helper.Display(ConsoleColor.DarkGreen, "Project updated");
                        }
                        else
                        {
                            Helper.Display(ConsoleColor.Red, "Enter name correctly");
                            goto WriteNameAgain;
                        }
                    }
                    else
                    {
                        Helper.Display(ConsoleColor.Red, "Enter id correctly");
                        goto WriteIdAgain;
                    }
                }
                else
                {
                    Helper.Display(ConsoleColor.Red, "Enter id correctly");
                    goto WriteIdAgain;
                }
            }
            else
                Helper.Display(ConsoleColor.DarkRed, "Has not any projects!");
        }

        public void Delete()
        {
            List<Project> projects = projectService.GetAll();
            if (projects.Count != 0)
            {
                Helper.Display(ConsoleColor.DarkYellow, "Enter project id");
            WriteIdAgain: string idString = Console.ReadLine();
                bool isChangeId = Int32.TryParse(idString, out int id);
                if (isChangeId)
                {
                    if (projectService.Delete(id) != null)
                        Helper.Display(ConsoleColor.DarkGreen, "Project deleted");
                    else
                    {
                        Helper.Display(ConsoleColor.Red, "Enter id correctly");
                        goto WriteIdAgain;
                    }
                }
                else
                {
                    Helper.Display(ConsoleColor.Red, "Enter id correctly");
                    goto WriteIdAgain;
                }
            }
            else
                Helper.Display(ConsoleColor.DarkRed, "Has not any projects!");
        }
    }
}
