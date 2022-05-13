using System;
using System.Collections.Generic;
using PlatziEscuela.Entidades;
using PlatziEscuela.App;
using PlatziEscuela.Util;
using static System.Console;
using System.Linq;
using PlatziEscuela.Entidades.Interfaces;
using PlatziEscuela.constanttexts;
using PlatziEscuela.CasesSwitchMenu;


namespace PlatziEscuela.CasesSwitchMenu
{
    class SixthCaseShowTopOfAveragesOfASubject
    {
        static PressEnterOrEsc PressEscOrEnter = new PressEnterOrEsc();
        static EndProgram ProgramEnd = new EndProgram();
        public void ShowSexthCase(Reporteador reporteador) 
        {
            Console.Clear();
            int conteoLineas = 1;
            try
            {
                int top;
                int opcionAsignatura;

                Printer.EscirbirTitulo("Asignaturas");
                var verAsignaturas = reporteador.GetListaDeAsignaturas();
                foreach (var objeto in verAsignaturas)
                {
                    Console.WriteLine($"{conteoLineas}) {objeto.ToString()}");
                    PressEscOrEnter.PresioneEscOenterParaContinuar(conteoLineas, objeto);
                    conteoLineas++;
                }
                conteoLineas = conteoLineas - 1;
                do
                {
                    Console.WriteLine("Ingrese el numero del Top de promedios, el rango aceptado es de 3 a 20");
                    top = Int32.Parse(Console.ReadLine());
                } while (top < 3 || top > 20);

                do
                {
                    Console.WriteLine("Ingrese un numero de asigantura valida");
                    opcionAsignatura = Int32.Parse(Console.ReadLine());
                } while (opcionAsignatura < 1 || opcionAsignatura > conteoLineas);

                string opcionAsignaturaString = verAsignaturas.ElementAt(opcionAsignatura - 1);
                Console.Clear();
                var diccionarioTopPromedioDeUnaAsignatura = reporteador.GetTopPromedioDeUnaAsignatura(opcionAsignaturaString, top);
                foreach (var asignatura in diccionarioTopPromedioDeUnaAsignatura)
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
