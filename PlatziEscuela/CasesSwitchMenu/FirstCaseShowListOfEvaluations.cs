using System;
using System.Collections.Generic;
using System.Text;
using PlatziEscuela.Util;
using PlatziEscuela.App;

namespace PlatziEscuela.CasesSwitchMenu
{
    public class FirstCaseShowListOfEvaluations
    {
        static PressEnterOrEsc PressEscOrEnter = new PressEnterOrEsc();
        static EndProgram ProgramEnd = new EndProgram();
        public void ShowFirstCase(Reporteador reporteador) 
        {
            Console.Clear();
            Printer.EscirbirTitulo("Mostrando Evaluacion del 1 al 25");
            var listaEvaluaciones = reporteador.GetListaDeEvaluaciones();
            int conteoLineas = 1;
            foreach (var objeto in listaEvaluaciones)
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
