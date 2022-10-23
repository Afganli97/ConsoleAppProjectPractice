using System;
using System.Collections.Generic;
using System.Text;
using Utilities;

namespace ConsoleAppProjectPractice.Controllers
{
    public class GlobalController
    {
        public void SelectGlobalMenu( out int selectGlobalMenu)
        {
            Helper.Display(ConsoleColor.DarkBlue, "1.Project methods\n2.Developer methods\n0.Exit");
        WriteMenuAgain: string selectMenuTemp = Console.ReadLine();
            bool isChangeMenu = Int32.TryParse(selectMenuTemp,out selectGlobalMenu);
            if (!isChangeMenu || selectGlobalMenu > 2 || selectGlobalMenu < 0)
            {
                Helper.Display(ConsoleColor.Red, "Select menu correct");
                goto WriteMenuAgain;
            }
        }

    }
}
