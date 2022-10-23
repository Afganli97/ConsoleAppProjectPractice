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
            Helper.Display(ConsoleColor.Blue, "1.Create\n2.Read\n3.Update\n4.Delete\n0.Return back");
        WriteMenuAgain: string selectMenuString = Console.ReadLine();
            bool isChangeMenu = Int32.TryParse(selectMenuString, out selectMenu);
            if (!isChangeMenu || selectMenu > 9 || selectMenu < 0)
            {
                Helper.Display(ConsoleColor.Red, "Select menu correct");
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

        public void SelectUpdateMenu(out int selectMenu)
        {
            Console.Clear();
            Helper.Display(ConsoleColor.Blue, "1.Change developer's project\n2.Add developer's skills\n0.Return back");
        WriteMenuAgain: string selectMenuString = Console.ReadLine();
            bool isChangeMenu = Int32.TryParse(selectMenuString, out selectMenu);
            if (!isChangeMenu || selectMenu > 2 || selectMenu < 0)
            {
                Helper.Display(ConsoleColor.DarkRed, "Select menu correct");
                goto WriteMenuAgain;
            }
        }

        public void Create()
        {
            List<Project> projects =  projectService.GetAll();
            if (projects.Count != 0)
            {
                Helper.Display(ConsoleColor.DarkYellow, "Enter project name");
            WriteProjectAgain: string projectName = Console.ReadLine();
                if (projectService.Get(projectName) != null)
                {
                    string developerName = string.Empty;
                    Helper.Display(ConsoleColor.DarkYellow, "Enter developer name");
                WriteDeveloperAgain: developerName = Console.ReadLine();
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
                            Helper.Display(ConsoleColor.DarkRed, "Error!");
                    }
                    else
                    {
                        Helper.Display(ConsoleColor.Red, "Enter developer name correctly");
                        goto WriteDeveloperAgain;
                    }
                }
                else
                {
                    Helper.Display(ConsoleColor.Red, "Enter project name correctly");
                    goto WriteProjectAgain;
                }
            }
            else
                Helper.Display(ConsoleColor.DarkRed, "No projects to create developer!");

        }

        public void GetById()
        {
            List<Developer> developers = developerService.GetAll();
            if (developers.Count != 0)
            {
                Helper.Display(ConsoleColor.DarkYellow, "Enter developer id");
            WriteIdAgain: string idString = Console.ReadLine();
                bool isChangeId = Int32.TryParse(idString, out int id);
                if (isChangeId)
                {
                    if (developerService.Get(id) != null)
                    {
                        Developer developer = developerService.Get(id);
                        Helper.Display(ConsoleColor.DarkGray, "Id: " + developer.Id + " Name: " + developer.Name + " Project name: " + developer.project.Name);
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
                Helper.Display(ConsoleColor.DarkRed, "No developer to get!");
        }

        public void GetByName()
        {
            List<Developer> developers = developerService.GetAll();
            if (developers.Count != 0)
            {
                Helper.Display(ConsoleColor.DarkYellow, "Enter developer name");
            WriteNameAgain: string name = Console.ReadLine();
                developers = developerService.GetAll(name);
                if (developers.Count == 0)
                {
                    Helper.Display(ConsoleColor.Red, "Enter developer name correctly");
                    goto WriteNameAgain;
                }
                foreach (var item in developers)
                {
                    Helper.Display(ConsoleColor.DarkGray, "Id: " + item.Id + " Name: " + item.Name + " Project name: " + item.project.Name);
                }
            }
            else
                Helper.Display(ConsoleColor.DarkRed, "No developer to get!");
        }

        public void GetAll()
        {
            List<Developer> developers = developerService.GetAll();
            if (developers.Count != 0)
            {
                foreach (var item in developers)
                {
                    Helper.Display(ConsoleColor.DarkGray, "Id: " + item.Id + " Name: " + item.Name + " Project name: " + item.project.Name);
                }
            }
            else
                Helper.Display(ConsoleColor.DarkRed, "No developer to get!");
        }

        public void GetSkills()
        {
            List<Developer> developers = developerService.GetAll();
            if (developers.Count != 0)
            {
                Helper.Display(ConsoleColor.DarkYellow, "Enter developer id");
            WriteNameAgain: string idString = Console.ReadLine();
                bool isChangeId = Int32.TryParse(idString, out int id);
                if (isChangeId)
                {
                    if (developerService.Get(id) != null)
                    {
                        Developer developer = developerService.Get(id);
                        List<string> skills = developer.Skills;
                        if (skills.Count != 0)
                        {
                            Helper.Display(ConsoleColor.DarkGray, "Id: " + developer.Id + " Name: " + developer.Name + " Project name: " + developer.project.Name + " Skills:");
                            foreach (var item in skills)
                            {
                                Helper.Display(ConsoleColor.DarkGray, item);
                            }
                        }
                        else
                            Helper.Display(ConsoleColor.Red, "This developer has not skills");
                    }
                    else
                    {
                        Helper.Display(ConsoleColor.Red, "Enter id correctly");
                        goto WriteNameAgain;
                    }
                }
                else
                {
                    Helper.Display(ConsoleColor.Red, "Enter id correctly");
                    goto WriteNameAgain;
                }
            }
            else
                Helper.Display(ConsoleColor.DarkRed, "No developer to get!");
        }

        public void GetAllSkills()
        {
            List<Developer> developers = developerService.GetAll();
            if (developers.Count != 0)
            {
                foreach (var item in developers)
                {
                    List<string> skills = item.Skills;
                    if (skills.Count != 0)
                    {
                        Helper.Display(ConsoleColor.DarkGray, "Id: " + item.Id + " Name: " + item.Name + " Project name: " + item.project.Name + " Skills:");
                        foreach (var item1 in skills)
                        {
                            Helper.Display(ConsoleColor.DarkGray, item1);
                        }
                    }
                    else
                    {
                        Helper.Display(ConsoleColor.DarkGray, "Id: " + item.Id + " Name: " + item.Name + " Project name: " + item.project.Name + " Skills:");
                        Helper.Display(ConsoleColor.Red, "This developer has not skills");
                    }
                }
            }
            else
                Helper.Display(ConsoleColor.DarkRed, "No developer to get!");
        }

        public void Update()
        {
            List<Project> projects = projectService.GetAll();
            if (projects.Count > 1)
            {
                List<Developer> developers = developerService.GetAll();
                if (developers.Count != 0)
                {
                    Helper.Display(ConsoleColor.DarkYellow, "Enter developer id");
                WriteIdAgain: string idString = Console.ReadLine();
                    bool isChangeId = Int32.TryParse(idString, out int id);
                    if (isChangeId)
                    {
                        Developer developer = developerService.Get(id);
                        if (developer != null)
                        {
                            Helper.Display(ConsoleColor.DarkYellow, "Enter project id");
                        WriteProjectIdAgain: string newProject = Console.ReadLine();
                            isChangeId = Int32.TryParse(newProject, out int newProjectId);
                            if (isChangeId)
                            {
                                if (developer.project.Id != newProjectId && (projectService.Get(newProjectId)) != null)
                                {
                                    developer.project = projectService.Get(newProjectId);
                                    Helper.Display(ConsoleColor.DarkGreen, "Developer updated");
                                }
                                else
                                {
                                    Helper.Display(ConsoleColor.Red, "Enter id correctly");
                                    goto WriteProjectIdAgain;
                                }
                            }
                            else
                            {
                                Helper.Display(ConsoleColor.Red, "Enter id correctly");
                                goto WriteProjectIdAgain;
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
                    Helper.Display(ConsoleColor.DarkRed, "No developer to update!");
            }
            else
                Helper.Display(ConsoleColor.DarkRed, "Not enough projects!");
        }

        public void UpdateSkills()
        {
            List<Developer> developers = developerService.GetAll();
            if (developers.Count != 0)
            {
                Helper.Display(ConsoleColor.DarkYellow, "Enter developer id");
            WriteIdAgain: string idString = Console.ReadLine();
                bool isChangeId = Int32.TryParse(idString, out int id);
                if (isChangeId)
                {
                    if (developerService.Get(id) != null)
                    {
                        Developer developer = developerService.Get(id);
                        AddSkills(developer);
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
                Helper.Display(ConsoleColor.DarkRed, "No developer to update!");
        }

        public void Delete()
        {
            List<Developer> developers = developerService.GetAll();
            if (developers.Count != 0)
            {
                Helper.Display(ConsoleColor.DarkYellow, "Enter developer id");
            WriteIdAgain: string idString = Console.ReadLine();
                bool isChangeId = Int32.TryParse(idString, out int id);
                if (isChangeId)
                {
                    if (developerService.Delete(id) != null)
                    {
                        Helper.Display(ConsoleColor.DarkGreen, "Developer deleted");
                    }
                    else
                        Helper.Display(ConsoleColor.DarkRed, "Id not found!");
                }
                else
                {
                    Helper.Display(ConsoleColor.Red, "Enter id correctly");
                    goto WriteIdAgain;
                }
            }
            else
                Helper.Display(ConsoleColor.DarkRed, "No developer to delete!");
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
    }
}
