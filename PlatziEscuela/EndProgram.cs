using System;
using System.Collections.Generic;
using PlatziEscuela.Entidades;
using PlatziEscuela.App;
using PlatziEscuela.Util;
using static System.Console;
using System.Linq;
using PlatziEscuela.Entidades.Interfaces;
using PlatziEscuela.constanttexts;
namespace PlatziEscuela
{
    public class EndProgram
    {

        public void FinalizarPrograma()
        {
            var ConstanText = new SConstanTextMostrarmenu();
            var TextsList = ConstanText.ShowPressEnterOrEsc;

            ConsoleKeyInfo tecla;
            WriteLine(TextsList[0]);
            tecla = Console.ReadKey();
            while (tecla.Key != ConsoleKey.Enter && tecla.Key != ConsoleKey.Escape)
            {
                WriteLine(TextsList[0]);
                tecla = Console.ReadKey();
            };
            if (tecla.Key == ConsoleKey.Escape)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Printer.EscirbirTitulo(TextsList[1]);
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(1);
            }
            Console.Clear();
            var MenuShow = new ShowMenu();
            MenuShow.MenuShow();
        }
    }
}