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
    public class PressEnterOrEsc
    {

        public void PresioneEscOenterParaContinuar(int conteoLineas, Object objeto)
        {
            if ((conteoLineas % 25) == 0)
            {
                ConsoleKeyInfo tecla;
                Printer.PresioneEscOenter();
                tecla = Console.ReadKey();
                while (tecla.Key != ConsoleKey.Enter && tecla.Key != ConsoleKey.Escape)
                {
                    Printer.PresioneEscOenter();
                    tecla = Console.ReadKey();
                };
                if (tecla.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    var MenuShow = new ShowMenu();
                    MenuShow.MenuShow();
                }
                else
                {
                    Console.Clear();
                    Printer.EscirbirTitulo($"Mostrando {objeto.GetType().Name} del {conteoLineas + 1} al {conteoLineas + 25}");
                }
            }
        }
    }
}