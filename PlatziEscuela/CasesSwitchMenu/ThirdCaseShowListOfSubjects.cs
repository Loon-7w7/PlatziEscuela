using System;
using System.Collections.Generic;
using System.Text;
using PlatziEscuela.Util;
using PlatziEscuela.App;

namespace PlatziEscuela.CasesSwitchMenu
{

    public class ThirdCaseShowListOfSubjects
    {
        static PressEnterOrEsc PressEscOrEnter = new PressEnterOrEsc();
        static EndProgram ProgramEnd = new EndProgram();

        public void ShowTridCase(Reporteador reporteador) 
        {
            Console.Clear();
            Printer.EscirbirTitulo("Mostrando Asignaturas");
            int conteoLineas = 1;
            var listaAsignaturas = reporteador.GetListaDeAsignaturas();
            foreach (var objeto in listaAsignaturas)
            {
                Console.WriteLine($"{conteoLineas}) {objeto.ToString()}");
                PressEscOrEnter.PresioneEscOenterParaContinuar(conteoLineas, objeto);
                conteoLineas++;
            }
            conteoLineas = 1;
            ProgramEnd.FinalizarPrograma();
        }
    }
}
