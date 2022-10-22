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
        public DeveloperController()
        {
            developerService = new DeveloperService();
        }
        public void SelectDeveloperMenu(out int selectMenu)
        {
            Helper.Dsiplay(ConsoleColor.Blue, "1.Add Developer\n2.Add developer skills\n3.Remove developer\n4.Get by id\n5.Get by name" +
                "\n6.Get all developers in definite project\n7.Get all developers\n8.Get developer skills\n9.Get all developers skills\n0.Exit");
        WriteMenuAgain: string selectMenuTemp = Console.ReadLine();
            bool isChangeMenu = Int32.TryParse(selectMenuTemp, out selectMenu);
            if (!isChangeMenu || selectMenu > 9 || selectMenu < 0)
            {
                Helper.Dsiplay(ConsoleColor.DarkRed, "Select menu correct");
                goto WriteMenuAgain;
            }

        }
        public void Create()
        {
            Helper.Dsiplay(ConsoleColor.DarkYellow, "Enter project name");
            string project = Console.ReadLine();
            Helper.Dsiplay(ConsoleColor.DarkYellow, "Enter developer name");
            string name = Console.ReadLine();
            Developer developer = new Developer();
            developer.Name = name;
            AddSkills(developer);
            if (developerService.Create(developer, project) != null)
            {
                Project.developers.Add(developer);
                Helper.Dsiplay(ConsoleColor.DarkGreen, "Developer created");
            }
            else
                Helper.Dsiplay(ConsoleColor.DarkRed, "Error");

        }
        public void Delete()
        {
            Helper.Dsiplay(ConsoleColor.DarkYellow, "Enter developer id");
            string idString = Console.ReadLine();
            bool isChangeId = Int32.TryParse(idString, out int id);
            if (isChangeId)
            {
                if (developerService.Delete(id) != null)
                {
                    Helper.Dsiplay(ConsoleColor.DarkGreen, "Project deleted");
                }
                else
                    Helper.Dsiplay(ConsoleColor.DarkRed, "Error");
            }
            else
            {
                Helper.Dsiplay(ConsoleColor.Red, "Enter id correctly");
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
                Developer developer = developerService.Get(id);
                if (developer != null)
                {
                    developer.Name = newName;
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
            Developer developer = developerService.Get(id);
            Helper.Dsiplay(ConsoleColor.DarkGray, "id: " + developer.Id + " name: " + developer.Name + " project name: " + developer.project.Name);


        }
        public void GetByName()
        {
            Helper.Dsiplay(ConsoleColor.DarkYellow, "Enter project name");
        WriteNameAgain: string name = Console.ReadLine();
            Developer developer = developerService.Get(name);
            if (developer == null)
            {
                Helper.Dsiplay(ConsoleColor.Red, "Enter project name correctly");
                goto WriteNameAgain;
            }
            Helper.Dsiplay(ConsoleColor.DarkGray, "id: " + developer.Id + " name: " + developer.Name + " project name: " + developer.project.Name);

        }
        public void GetAll()
        {
            List<Developer> developers = developerService.GetAll();
            foreach (var item in developers)
            {
                Helper.Dsiplay(ConsoleColor.DarkGray, "id: " + item.Id + " name: " + item.Name + " project name: " + item.project.Name);
            }
        }
        public void AddSkills(Developer developer)
        {
            string selectMenu;
            while (true)
            {
                Helper.Dsiplay(ConsoleColor.DarkYellow, "1.Add new skill\n0.Exit");
            WriteAgain: selectMenu = Console.ReadLine();
                bool isChangeId = Int32.TryParse(selectMenu, out int select);
                if (!isChangeId || select > 1 || select < 0)
                {
                    Helper.Dsiplay(ConsoleColor.Red, "Enter id correctly");
                    goto WriteAgain;
                }
                if (select == 0)
                    break;
                Helper.Dsiplay(ConsoleColor.DarkYellow, "Enter new skill");
                string newSkill = Console.ReadLine();
                developer.Skills.Add(newSkill);
                Helper.Dsiplay(ConsoleColor.DarkGreen, "Skill added");
            }
        }
        public void GetSkills(int id)
        {

        }

    }
}
