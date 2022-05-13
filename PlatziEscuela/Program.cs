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
    public class Program : ShowMenu
    {
   
        static void Main(string[] args)
        {
            callmenu();
        }
        private static void callmenu()
        {
            var MenuShow = new ShowMenu();
            MenuShow.MostrarMenu();
        }

       

    }
}