using ConsoleAppProjectPractice.Controllers;
using System;
using Utilities;

namespace ConsoleAppProjectPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GlobalController controller = new GlobalController();
            ProjectController projectController = new ProjectController();
            DeveloperController developerController = new DeveloperController();

            int selectMenu;

            while (true)
            {
                Console.Clear();
                controller.SelectGlobalMenu(out selectMenu);
                if (selectMenu == 0)
                    break;
                switch (selectMenu)
                {
                    case (int)Helper.GlobalMethods.GetProjectMethods:
                        projectController.SelectProjectMenu(out selectMenu);
                        if (selectMenu == 0)
                            continue;
                        switch (selectMenu)
                        {
                            case (int)Helper.ProjectMethods.Create:
                                projectController.Create();
                                break;
                            case (int)Helper.ProjectMethods.Update:
                                projectController.Update();
                                break;
                            case (int)Helper.ProjectMethods.Delete:
                                projectController.Delete();
                                break;
                            case (int)Helper.ProjectMethods.GetById:
                                projectController.GetById();
                                break;
                            case (int)Helper.ProjectMethods.GetByName:
                                projectController.GetByName();
                                break;
                            case (int)Helper.ProjectMethods.GetAll:
                                projectController.GetAll();
                                break;
                        }
                        break;
                    case (int)Helper.GlobalMethods.GetDeveloperMethods:
                        developerController.SelectDeveloperMenu(out selectMenu);
                        if (selectMenu == 0)
                            continue;
                        switch (selectMenu)
                        {
                            case (int)Helper.DeveloperMethods.Create:
                                developerController.Create();
                                break;
                            case (int)Helper.DeveloperMethods.Update:
                                developerController.Update();
                                break;
                            case (int)Helper.DeveloperMethods.Delete:
                                developerController.Delete();
                                break;
                            case (int)Helper.DeveloperMethods.GetById:
                                developerController.GetById();
                                break;
                            case (int)Helper.DeveloperMethods.GetByName:
                                developerController.GetByName();
                                break;
                            case (int)Helper.DeveloperMethods.GetAll:
                                developerController.GetAll();
                                break;
                            case (int)Helper.DeveloperMethods.GetSkills:
                                developerController.GetSkills();
                                break;
                            case (int)Helper.DeveloperMethods.GetAllSkills:
                                developerController.GetAllSkills();
                                break;
                        }
                        break;
                }

                Helper.Display(ConsoleColor.DarkYellow, "Press Enter");
                Console.ReadLine();
            }
        }
    }
}
