using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
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
        public void SelectProjectMenu(out int selectMenu)
        {
            Helper.Dsiplay(ConsoleColor.Blue, "1.Add Developer\n2.Update developer skills\n3.Remove developer\n4.Get by id\n5.Get by name" +
                "\n6.Get all developers in definite project\n7.Get all developers\n0.Exit");
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
            Developer developer = new Developer();
            developer.Name = name;
            if (developerService.Create(developer) != null)
                Helper.Dsiplay(ConsoleColor.DarkGreen, "Project created");
            else
                Helper.Dsiplay(ConsoleColor.DarkRed, "Error");

        }
        public void Delete()
        {
            Helper.Dsiplay(ConsoleColor.DarkYellow, "Enter project id");
            string idString = Console.ReadLine();
            bool isChangeId = Int32.TryParse(idString, out int id);
            if (isChangeId)
            {
                if (developerService.Delete(id) != null)
                    Helper.Dsiplay(ConsoleColor.DarkGreen, "Project deleted");
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
            Helper.Dsiplay(ConsoleColor.DarkGray, developer.Id + " " + developer.Name + " " + developer.Skill);


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
            Helper.Dsiplay(ConsoleColor.DarkGray, developer.Id + " " + developer.Name + " " + developer.Skill);

        }
        public void GetAll()
        {
            List<Developer> developers = developerService.GetAll();
            foreach (var item in developers)
            {
                Helper.Dsiplay(ConsoleColor.DarkGray, item.Id + " " + item.Name + " " + item.Skill);
            }

        }

    }
}
