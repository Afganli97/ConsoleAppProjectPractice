using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
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
            Helper.Dsiplay(ConsoleColor.Blue, "1.Create project\n2.Update project\n3.Delete project\n4.Get by id\n5.Get by name\n6.Get all\n0.Exit");
        WriteMenuAgain: string selectMenuTemp = Console.ReadLine();
            bool isChangeMenu = Int32.TryParse(selectMenuTemp, out selectMenu);
            if (!isChangeMenu || selectMenu > 6 || selectMenu < 0)
            {
                Helper.Dsiplay(ConsoleColor.DarkRed, "Select menu correct");
                goto WriteMenuAgain;
            }
            
        }
        public void Create()
        {
            Helper.Dsiplay(ConsoleColor.DarkYellow, "Enter project name");
            string name = Console.ReadLine();
            Project project = new Project();
            project.Name = name;
            if (projectService.Create(project) != null)
                Helper.Dsiplay(ConsoleColor.DarkGreen, "Project created");
            else
                Helper.Dsiplay(ConsoleColor.DarkRed, "Error");

        }
        public void Delete()
        {
            Helper.Dsiplay(ConsoleColor.DarkYellow, "Enter project id");
        WriteIdAgain: string idString = Console.ReadLine();
            bool isChangeId = Int32.TryParse(idString, out int id);
            if (isChangeId)
            {
                if (projectService.Delete(id) != null)
                    Helper.Dsiplay(ConsoleColor.DarkGreen, "Project deleted");
                else
                    Helper.Dsiplay(ConsoleColor.DarkRed, "Error");
            }
            else
            {
                Helper.Dsiplay(ConsoleColor.Red, "Enter id correctly");
                goto WriteIdAgain;

            }

        }
        public void Update()
        {
            Helper.Dsiplay(ConsoleColor.DarkYellow, "Enter project id");
            string idString = Console.ReadLine();
            bool isChangeId = Int32.TryParse(idString, out int id);
            if (isChangeId)
            {
                Helper.Dsiplay(ConsoleColor.DarkYellow, "Enter new name");
                string newName = Console.ReadLine();
                Project project = projectService.Get(id);
                if (project != null)
                {
                    project.Name = newName;
                    Helper.Dsiplay(ConsoleColor.DarkGreen, "Project updated");
                }
                else
                    Helper.Dsiplay(ConsoleColor.DarkRed, "Error");
            }
            else
            {
                Helper.Dsiplay(ConsoleColor.Red, "Enter id correctly");
            }
        }
        public void GetById()
        {
            Helper.Dsiplay(ConsoleColor.DarkYellow, "Enter project id");
            string idString = Console.ReadLine();
            bool isChangeId = Int32.TryParse(idString, out int id);
            if (!isChangeId)
            {
                Helper.Dsiplay(ConsoleColor.Red, "Enter id correctly");
            }
            Project project = projectService.Get(id);
            Helper.Dsiplay(ConsoleColor.DarkGray, project.Id + " " + project.Name);


        }
        public void GetByName()
        {
            Helper.Dsiplay(ConsoleColor.DarkYellow, "Enter project name");
            WriteNameAgain: string name = Console.ReadLine();
            Project project = projectService.Get(name);
            if (project == null)
            {
                Helper.Dsiplay(ConsoleColor.Red, "Enter project name correctly");
                goto WriteNameAgain;
            }
            Helper.Dsiplay(ConsoleColor.DarkGray, project.Id + " " + project.Name);

        }
        public void GetAll()
        {
            List<Project> projects = projectService.GetAll();
            foreach (var item in projects)
            {
                Helper.Dsiplay(ConsoleColor.DarkGray, item.Id + " " + item.Name);
            }

        }
    }
}
