using System;
using System.Collections.Generic;
using System.Text;
using PlatziEscuela.Util;
using PlatziEscuela.App;
namespace PlatziEscuela.CasesSwitchMenu
{
    
    public class SecondCaseShowListEvaluationsBySubject
    {
        static PressEnterOrEsc PressEscOrEnter = new PressEnterOrEsc();
        static EndProgram ProgramEnd = new EndProgram();

        public void ShowSecondCase(Reporteador reporteador) 
        {
            Console.Clear();
            Printer.EscirbirTitulo("Mostrando Evaluacion Por Asignatura del 1 al 25");
            int conteoLineas = 1;
            var listaEvaluacionesPorAsignatura = reporteador.GetDicEvaluaXAsig();
            foreach (var asignatura in listaEvaluacionesPorAsignatura)
            {
                Printer.EscirbirTitulo($"Evaluaciones de la Asignatura: {asignatura.Key.ToString()}");
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
