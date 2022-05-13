using System;
using System.Collections.Generic;
using System.Text;

namespace PlatziEscuela.CasesSwitchMenu
{
    public class CatchCaseEvent
    {
        public void ShowCatchCase() 
        {
            var ShowMenusM = new ShowMenu();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Debe ingresar un numero como opción\n");
            Console.ForegroundColor = ConsoleColor.White;
            ShowMenusM.MenuShow();
        }
    }
}
