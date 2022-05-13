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
    public class Program 
    {

        private static void Main(string[] args) => Callmenu();

        private static void Callmenu()
        {
            var MenuShow = new ShowMenu();
            MenuShow.MenuShow();
        }

       

    }
}