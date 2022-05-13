using System;
using System.Collections.Generic;
using System.Text;
using PlatziEscuela.Util;
using PlatziEscuela.App;


namespace PlatziEscuela.CasesSwitchMenu
{
    class SeventhCaseFinishProgram
    {
        static PressEnterOrEsc PressEscOrEnter = new PressEnterOrEsc();
        static EndProgram ProgramEnd = new EndProgram();
        public void ShowSeventhCase() 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Printer.EscirbirTitulo("¿Esta seguro que desea finalizar el programa?");
            Console.ForegroundColor = ConsoleColor.White;
            ProgramEnd.FinalizarPrograma();
        }
    }
}
