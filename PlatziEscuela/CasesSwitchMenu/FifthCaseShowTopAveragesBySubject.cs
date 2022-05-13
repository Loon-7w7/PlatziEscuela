using System;
using System.Collections.Generic;
using System.Text;
using PlatziEscuela.Util;
using PlatziEscuela.App;

namespace PlatziEscuela.CasesSwitchMenu
{
    public class FifthCaseShowTopAveragesBySubject
    {
        static PressEnterOrEsc PressEscOrEnter = new PressEnterOrEsc();
        static EndProgram ProgramEnd = new EndProgram();
        public void ShowFifthCase(Reporteador reporteador)
        {
            Console.Clear();
            int conteoLineas = 1;
            try
            {
                int top;
                do
                {
                    Console.WriteLine("Ingrese el numero del Top de promedios, el rango aceptado es de 3 a 20");
                    top = Int32.Parse(Console.ReadLine());
                } while (top < 3 || top > 20);
                Console.Clear();
                var diccionarioTopPromedioPorCadaAsignatura = reporteador.GetTopPromedioPorCadaAsignatura(top);
                foreach (var asignatura in diccionarioTopPromedioPorCadaAsignatura)
                {
                    Printer.EscirbirTitulo($"Promedios de la Asignatura: {asignatura.Key.ToString()}");
                    foreach (var objeto in asignatura.Value)
                    {
                        Console.WriteLine($"{conteoLineas}) {objeto.ToString()}");
                        PressEscOrEnter.PresioneEscOenterParaContinuar(conteoLineas, objeto);
                        conteoLineas++;
                    }
                    conteoLineas = 1;
                    Console.WriteLine("\n");
                }
                conteoLineas = 1;
                ProgramEnd.FinalizarPrograma();
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Printer.EscirbirTitulo("No se ingresó un numero valido");
                Console.ForegroundColor = ConsoleColor.White;
            }
            finally
            {
                ProgramEnd.FinalizarPrograma();
            }
        }
    }
}
