using System;
using System.Collections.Generic;
using System.Text;
using PlatziEscuela.Util;
using PlatziEscuela.App;

namespace PlatziEscuela.CasesSwitchMenu
{
    public class FourthCaseShowListOfAveragesBySubject
    {
        static PressEnterOrEsc PressEscOrEnter = new PressEnterOrEsc();
        static EndProgram ProgramEnd = new EndProgram();

        public void ShowFourthCase(Reporteador reporteador) 
        {
            Console.Clear();
            Printer.EscirbirTitulo("Mostrando Promedio del 1 al 25");
            int conteoLineas = 1;
            var diccionarioPromedioPorAsignatura = reporteador.GetPromedioAlumnoPorAsignatura();
            foreach (var asignatura in diccionarioPromedioPorAsignatura)
            {
                Printer.EscirbirTitulo($"Promedios de la Asignatura: {asignatura.Key.ToString()}");
                foreach (var objeto in asignatura.Value)
                {
                    Console.WriteLine($"{conteoLineas}) {objeto.ToString()}");
                    PressEscOrEnter.PresioneEscOenterParaContinuar(conteoLineas, objeto);
                    conteoLineas++;
                }
            }
            conteoLineas = 1;
            ProgramEnd.FinalizarPrograma();
        }
    }
}
