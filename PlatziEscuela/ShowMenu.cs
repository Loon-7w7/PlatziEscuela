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
    public class ShowMenu
    {
        static EscuelaEngine engine = new EscuelaEngine();
        static Reporteador reporteador;
        public void MostrarMenu()
        {
            engine.InicialicarValoresDelPrograma();
            reporteador = new Reporteador(engine.GetDicionario());
            try
            {

                var ConstanText = new SConstanTextMostrarmenu();
                var TextsList = ConstanText.ShowSelector;

                int TmporalPointCount = 0;
                foreach (var itemTexts in TextsList)
                {
                    if (TmporalPointCount == 0)
                    {
                        Printer.EscirbirTitulo(itemTexts);
                        TmporalPointCount++;
                    }
                    WriteLine(itemTexts);

                }

                int opcionSeleccionada = Int32.Parse(Console.ReadLine());
                switch (opcionSeleccionada)
                {
                    case 1:
                        Console.Clear();
                        Printer.EscirbirTitulo("Mostrando Evaluacion del 1 al 25");
                        var listaEvaluaciones = reporteador.GetListaDeEvaluaciones();
                        int conteoLineas = 1;
                        foreach (var objeto in listaEvaluaciones)
                        {
                            Console.WriteLine($"{conteoLineas}) {objeto.ToString()}");
                            PresioneEscOenterParaContinuar(conteoLineas, objeto);
                            conteoLineas++;
                        }
                        conteoLineas = 1;
                        FinalizarPrograma();
                        break;

                    case 2:
                        Console.Clear();
                        Printer.EscirbirTitulo("Mostrando Evaluacion Por Asignatura del 1 al 25");
                        conteoLineas = 1;
                        var listaEvaluacionesPorAsignatura = reporteador.GetDicEvaluaXAsig();
                        foreach (var asignatura in listaEvaluacionesPorAsignatura)
                        {
                            Printer.EscirbirTitulo($"Evaluaciones de la Asignatura: {asignatura.Key.ToString()}");
                            foreach (var objeto in asignatura.Value)
                            {
                                Console.WriteLine($"{conteoLineas}) {objeto.ToString()}");
                                PresioneEscOenterParaContinuar(conteoLineas, objeto);
                                conteoLineas++;
                            }
                        }
                        conteoLineas = 1;
                        FinalizarPrograma();
                        break;

                    case 3:
                        Console.Clear();
                        Printer.EscirbirTitulo("Mostrando Asignaturas");
                        conteoLineas = 1;
                        var listaAsignaturas = reporteador.GetListaDeAsignaturas();
                        foreach (var objeto in listaAsignaturas)
                        {
                            Console.WriteLine($"{conteoLineas}) {objeto.ToString()}");
                            PresioneEscOenterParaContinuar(conteoLineas, objeto);
                            conteoLineas++;
                        }
                        conteoLineas = 1;
                        FinalizarPrograma();
                        break;

                    case 4:
                        Console.Clear();
                        Printer.EscirbirTitulo("Mostrando Promedio del 1 al 25");
                        conteoLineas = 1;
                        var diccionarioPromedioPorAsignatura = reporteador.GetPromedioAlumnoPorAsignatura();
                        foreach (var asignatura in diccionarioPromedioPorAsignatura)
                        {
                            Printer.EscirbirTitulo($"Promedios de la Asignatura: {asignatura.Key.ToString()}");
                            foreach (var objeto in asignatura.Value)
                            {
                                Console.WriteLine($"{conteoLineas}) {objeto.ToString()}");
                                PresioneEscOenterParaContinuar(conteoLineas, objeto);
                                conteoLineas++;
                            }
                        }
                        conteoLineas = 1;
                        FinalizarPrograma();
                        break;

                    case 5:
                        Console.Clear();
                        conteoLineas = 1;
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
                                    PresioneEscOenterParaContinuar(conteoLineas, objeto);
                                    conteoLineas++;
                                }
                                conteoLineas = 1;
                                Console.WriteLine("\n");
                            }
                            conteoLineas = 1;
                            FinalizarPrograma();
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Printer.EscirbirTitulo("No se ingresó un numero valido");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        finally
                        {
                            FinalizarPrograma();
                        }
                        break;

                    case 6:
                        Console.Clear();
                        conteoLineas = 1;
                        try
                        {
                            int top;
                            int opcionAsignatura;

                            Printer.EscirbirTitulo("Asignaturas");
                            var verAsignaturas = reporteador.GetListaDeAsignaturas();
                            foreach (var objeto in verAsignaturas)
                            {
                                Console.WriteLine($"{conteoLineas}) {objeto.ToString()}");
                                PresioneEscOenterParaContinuar(conteoLineas, objeto);
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
                                    PresioneEscOenterParaContinuar(conteoLineas, objeto);
                                    conteoLineas++;
                                }
                                conteoLineas = 1;
                                Console.WriteLine("\n");
                            }
                            conteoLineas = 1;
                            FinalizarPrograma();
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Printer.EscirbirTitulo("No se ingresó un numero valido");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        finally
                        {
                            FinalizarPrograma();
                        }
                        break;

                    case 7:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Printer.EscirbirTitulo("¿Esta seguro que desea finalizar el programa?");
                        Console.ForegroundColor = ConsoleColor.White;
                        FinalizarPrograma();
                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El número de la opción ingresada no es valida\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        MostrarMenu();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Debe ingresar un numero como opción\n");
                Console.ForegroundColor = ConsoleColor.White;
                MostrarMenu();
            }
        }

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
                    MostrarMenu();
                }
                else
                {
                    Console.Clear();
                    Printer.EscirbirTitulo($"Mostrando {objeto.GetType().Name} del {conteoLineas + 1} al {conteoLineas + 25}");
                }
            }
        }

        public void FinalizarPrograma()
        {
            ConsoleKeyInfo tecla;
            WriteLine("\nPresione ENTER para volver al menú, presione ESC para finalizar el programa...");
            tecla = Console.ReadKey();
            while (tecla.Key != ConsoleKey.Enter && tecla.Key != ConsoleKey.Escape)
            {
                WriteLine("\nPresione ENTER para volver al menú, presione ESC para finalizar el programa...");
                tecla = Console.ReadKey();
            };
            if (tecla.Key == ConsoleKey.Escape)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Printer.EscirbirTitulo("PROGRAMA FINALIZADO");
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(1);
            }
            Console.Clear();
            MostrarMenu();
        }
    }



}