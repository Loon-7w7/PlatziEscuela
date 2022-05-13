using System;
using System.Collections.Generic;
using System.Text;

namespace PlatziEscuela.CasesSwitchMenu
{
    class DefaultCaseSwitch
    {
        public void showDefaulrcase() 
        {
            var ShowMenusM = new ShowMenu();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("El número de la opción ingresada no es valida\n");
            Console.ForegroundColor = ConsoleColor.White;
            ShowMenusM.MenuShow();
        }
    }
}
