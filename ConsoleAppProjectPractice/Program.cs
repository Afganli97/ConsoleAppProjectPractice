using ConsoleAppProjectPractice.Controllers;
using System;
using Utilities;

namespace ConsoleAppProjectPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GlobalController globalController = new GlobalController();
            ProjectController projectController = new ProjectController();
            DeveloperController developerController = new DeveloperController();

            int selectGlobalMenu = 0;
            int selectProjectMenu = 0;
            int selectDeveloperMenu = 0;
            int selectMenu = 0;

            while (true)
            {
                Console.Clear();
                if (selectGlobalMenu == 0)
                {
                    globalController.SelectGlobalMenu(out selectGlobalMenu);
                    if (selectGlobalMenu == 0)
                        break;
                }
                switch (selectGlobalMenu)
                {
                    case (int)Helper.GlobalMethods.GetProjectMethods:
                        projectController.SelectProjectMenu(out selectProjectMenu);
                        if (selectProjectMenu == 0)
                        {
                            selectGlobalMenu = 0;
                            continue;
                        }
                        switch (selectProjectMenu)
                        {
                            case (int)Helper.ProjectMethods.Create:
                                projectController.Create();
                                break;
                            case (int)Helper.ProjectMethods.Read:
                                projectController.SelectReadMenu(out selectMenu);
                                if (selectMenu == 0)
                                {
                                    selectProjectMenu = 0;
                                    continue;
                                }
                                switch (selectMenu)
                                {
                                    case (int)Helper.ProjectReadMethods.GetById:
                                        projectController.GetById();
                                        break;
                                    case (int)Helper.ProjectReadMethods.GetByName:
                                        projectController.GetByName();
                                        break;
                                    case (int)Helper.ProjectReadMethods.GetAll:
                                        projectController.GetAll();
                                        break;
                                    case (int)Helper.ProjectReadMethods.GetAllInProject:
                                        projectController.GetAllInProject();
                                        break;
                                }
                                break;
                            case (int)Helper.ProjectMethods.Update:
                                projectController.Update();
                                break;
                            case (int)Helper.ProjectMethods.Delete:
                                projectController.Delete();
                                break;
                        }
                        break;
                    case (int)Helper.GlobalMethods.GetDeveloperMethods:
                        developerController.SelectDeveloperMenu(out selectDeveloperMenu);
                        if (selectDeveloperMenu == 0)
                        {
                            selectGlobalMenu = 0;
                            continue;
                        }
                        switch (selectDeveloperMenu)
                        {
                            case (int)Helper.DeveloperMethods.Create:
                                developerController.Create();
                                break;
                            case (int)Helper.DeveloperMethods.Read:
                                developerController.SelectReadMenu(out selectMenu);
                                if (selectMenu == 0)
                                {
                                    selectProjectMenu = 0;
                                    continue;
                                }
                                switch (selectMenu)
                                {
                                    case (int)Helper.DeveloperReadMethods.GetById:
                                        developerController.GetById();
                                        break;
                                    case (int)Helper.DeveloperReadMethods.GetByName:
                                        developerController.GetByName();
                                        break;
                                    case (int)Helper.DeveloperReadMethods.GetAll:
                                        developerController.GetAll();
                                        break;
                                    case (int)Helper.DeveloperReadMethods.GetSkills:
                                        developerController.GetSkills();
                                        break;
                                    case (int)Helper.DeveloperReadMethods.GetAllSkills:
                                        developerController.GetAllSkills();
                                        break;
                                }
                                break;
                            case (int)Helper.DeveloperMethods.Update:
                                developerController.SelectUpdateMenu(out selectMenu);
                                if (selectMenu == 0)
                                {
                                    selectDeveloperMenu = 0;
                                    continue;
                                }
                                switch (selectMenu)
                                {
                                    case (int)Helper.DeveloperUpdateMethods.UpdateProject:
                                        developerController.UpdateSkills();
                                        break;
                                    case (int)Helper.DeveloperUpdateMethods.UpdateSkills:
                                        developerController.UpdateSkills();
                                        break;
                                }
                                break;
                            case (int)Helper.DeveloperMethods.Delete:
                                developerController.Delete();
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
