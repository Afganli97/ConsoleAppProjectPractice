using Business.Interfaces;
using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Utilities;

namespace ConsoleAppProjectPractice.Controllers
{
    public class DeveloperController
    {
        public DeveloperService developerService { get; set; }
        public ProjectService projectService { get; set; }
        public DeveloperController()
        {
            developerService = new DeveloperService();
            projectService = new ProjectService();
        }
        public void SelectDeveloperMenu(out int selectMenu)
        {
            Console.Clear();
            Helper.Display(ConsoleColor.Blue, "1.Add Developer\n2.Add developer skills\n3.Remove developer\n4.Get by id\n5.Get by name" +
                "\n6.Get all developers in definite project\n7.Get all developers\n8.Get developer skills\n9.Get all developers skills\n0.Return back");
        WriteMenuAgain: string selectMenuString = Console.ReadLine();
            bool isChangeMenu = Int32.TryParse(selectMenuString, out selectMenu);
            if (!isChangeMenu || selectMenu > 9 || selectMenu < 0)
            {
                Helper.Display(ConsoleColor.Red, "Select menu correct");
                goto WriteMenuAgain;
            }

        }
        public void Create()
        {
            Helper.Display(ConsoleColor.DarkYellow, "Enter project name");
        WriteProjectAgain: string projectName = Console.ReadLine();
            if (projectService.Get(projectName) != null)
            {
                string developerName = string.Empty;
                Helper.Display(ConsoleColor.DarkYellow, "Enter developer name");
                developerName = Console.ReadLine();
                developerName = developerName.Trim();
                if (developerName != string.Empty)
                {
                    Developer developer = new Developer();
                    developer.Name = developerName;
                    AddSkills(developer);
                    if (developerService.Create(developer, projectName) != null)
                    {
                        Project.developers.Add(developer);
                        Helper.Display(ConsoleColor.DarkGreen, "Developer created");
                    }
                    else
                        Helper.Display(ConsoleColor.DarkRed, "Error");
                }
                else
                {
                    Helper.Display(ConsoleColor.Red, "Enter project name correctly");
                    goto WriteProjectAgain;
                }
            }
            else
            {
                Helper.Display(ConsoleColor.Red, "Enter project name correctly");
                goto WriteProjectAgain;
            }

        }
        public void Delete()
        {
            Helper.Display(ConsoleColor.DarkYellow, "Enter developer id");
            string idString = Console.ReadLine();
            bool isChangeId = Int32.TryParse(idString, out int id);
            if (isChangeId)
            {
                if (developerService.Delete(id) != null)
                {
                    Helper.Display(ConsoleColor.DarkGreen, "Project deleted");
                }
                else
                    Helper.Display(ConsoleColor.DarkRed, "Error");
            }
            else
            {
                Helper.Display(ConsoleColor.Red, "Enter id correctly");
            }

        }
        public void Update()
        {
            Helper.Display(ConsoleColor.DarkYellow, "Enter developer id");
            string idString = Console.ReadLine();
            bool isChangeId = Int32.TryParse(idString, out int id);
            if (isChangeId)
            {
                Helper.Display(ConsoleColor.DarkYellow, "Enter new name");
                string newName = Console.ReadLine();
                Developer developer = developerService.Get(id);
                if (developer != null)
                {
                    developer.Name = newName;
                    Helper.Display(ConsoleColor.DarkGreen, "Project updated");
                }
                else
                    Helper.Display(ConsoleColor.DarkRed, "Error");
            }
            else
            {
                Helper.Display(ConsoleColor.Red, "Enter id correctly");
            }
        }
        public void GetById()
        {
            Helper.Display(ConsoleColor.DarkYellow, "Enter project id");
            string idString = Console.ReadLine();
            bool isChangeId = Int32.TryParse(idString, out int id);
            if (!isChangeId)
            {
                Helper.Display(ConsoleColor.Red, "Enter id correctly");
            }
            Developer developer = developerService.Get(id);
            Helper.Display(ConsoleColor.DarkGray, "id: " + developer.Id + " name: " + developer.Name + " project name: " + developer.project.Name);


        }
        public void GetByName()
        {
            Helper.Display(ConsoleColor.DarkYellow, "Enter project name");
        WriteNameAgain: string name = Console.ReadLine();
            Developer developer = developerService.Get(name);
            if (developer == null)
            {
                Helper.Display(ConsoleColor.Red, "Enter project name correctly");
                goto WriteNameAgain;
            }
            Helper.Display(ConsoleColor.DarkGray, "id: " + developer.Id + " name: " + developer.Name + " project name: " + developer.project.Name);

        }
        public void GetAll()
        {
            List<Developer> developers = developerService.GetAll();
            foreach (var item in developers)
            {
                Helper.Display(ConsoleColor.DarkGray, "id: " + item.Id + " name: " + item.Name + " project name: " + item.project.Name);
            }
        }
        public void GetSkills()
        {
            Helper.Display(ConsoleColor.DarkYellow, "Enter developer id");
        WriteNameAgain: string idString = Console.ReadLine();
            bool isChangeId = Int32.TryParse(idString, out int id);
            if (!isChangeId)
            {
                Helper.Display(ConsoleColor.Red, "Enter id correctly");
                goto WriteNameAgain;
            }
            Developer developer = developerService.Get(id);
            List<string> skills = developer.Skills;
            if (skills != null)
            {
                Helper.Display(ConsoleColor.DarkGray, "id: " + developer.Id + " name: " + developer.Name + " project name: " + developer.project.Name + " Skills:");
                foreach (var item in skills)
                {
                    Helper.Display(ConsoleColor.DarkGray, item);
                }
            }
            else
            {
                Helper.Display(ConsoleColor.Red, "This developer has not skills");
            }
        }
        public void GetAllSkills()
        {
            List<Developer> developers = developerService.GetAll();
            foreach (var item in developers)
            {
                List<string> skills = item.Skills;
                if (skills != null)
                {
                    Helper.Display(ConsoleColor.DarkGray, "id: " + item.Id + " name: " + item.Name + " project name: " + item.project.Name + " Skills:");
                    foreach (var item1 in skills)
                    {
                        Helper.Display(ConsoleColor.DarkGray, item1);
                    }
                }
                else
                {
                    Helper.Display(ConsoleColor.Red, "This developer has not skills");
                }
            }
        }

        public void AddSkills(Developer developer)
        {
            string selectMenu;
            while (true)
            {
                Helper.Display(ConsoleColor.DarkYellow, "1.Add new skill\n0.Exit");
            WriteAgain: selectMenu = Console.ReadLine();
                bool isChangeId = Int32.TryParse(selectMenu, out int select);
                if (!isChangeId || select > 1 || select < 0)
                {
                    Helper.Display(ConsoleColor.Red, "Select menu correctly");
                    goto WriteAgain;
                }
                if (select == 0)
                    break;
                string newSkill = string.Empty;
                Helper.Display(ConsoleColor.DarkYellow, "Enter new skill");
            WriteSkillAgain: newSkill = Console.ReadLine();
                newSkill = newSkill.Trim();
                if (newSkill != string.Empty)
                {
                    developer.Skills.Add(newSkill);
                    Helper.Display(ConsoleColor.DarkGreen, "Skill added");
                }
                else
                {
                    Helper.Display(ConsoleColor.Red, "Enter developer skill");
                    goto WriteSkillAgain;
                }
            }
        }
        public void GetSkills(int id)
        {

        }

    }
}
