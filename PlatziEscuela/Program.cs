using System;
using System.Collections.Generic;
using PlatziEscuela.Entidades;
using PlatziEscuela.App;
using PlatziEscuela.Util;
using static System.Console;
using System.Linq;
using PlatziEscuela.Entidades.Interfaces;

namespace PlatziEscuela
{
    public class Program
    {
        
        
        private const string TextoCursosEscuela = "Cursos de la escuela";
        private const string TextoBienvenidaEscuela = "Bienvendido A la escuela";

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += acciOnDelEvento;
            AppDomain.CurrentDomain.ProcessExit += (o, s ) => Printer.GenerarSonidoBeep(2000,1000,1);

            var Engine = new EscuelaEngine();
            Engine.InicialicarValoresDelPrograma();


            Printer.EscirbirTitulo("Captura De Una Evaluacion Por Consola");
            var neweval = new Evalucaiones();
            string Nombre, NotaString;
            float Calificacion;
            WriteLine("Ingrese el nombre de la evaluacion");
            Printer.PrecioneEnter();
            Nombre = ReadLine();

            if (String.IsNullOrWhiteSpace(Nombre))
            {
                Printer.EscirbirTitulo("El Varlor Del Nombre No Puede Ser Vacio");
                WriteLine("Salieo del programa...");
            }
            else 
            {
                neweval.NombreObjetoEscuela = Nombre.ToLower();
                WriteLine("El Nombre De La Evaluacion Ha Sido Ingresado Correctamente");
            }

            WriteLine("Ingrese La calificacion de la evaluacion");
            Printer.PrecioneEnter();
            NotaString = ReadLine();

            if (String.IsNullOrWhiteSpace(NotaString))
            {
                Printer.EscirbirTitulo("El Varlor Del Nombre No Puede Ser Vacio");
                WriteLine("Salieo del programa...");
            }
            else
            {
                try
                {
                    neweval.Calificacion = float.Parse(NotaString);
                    if (neweval.Calificacion < 0 || neweval.Calificacion > 5)
                    {
                        throw new ArgumentOutOfRangeException("la nota de la evaluacion debe esatr entre 0 y 5");

                    }

                    WriteLine("El Nombre De La Evaluacion Ha Sido Ingresado Correctamente");
                }
                catch (ArgumentOutOfRangeException arge)
                {

                    WriteLine(arge.Message);
                    WriteLine("Salieo del programa...");
                }

                catch (Exception)
                {
                    Printer.EscirbirTitulo("El Valor de la nota no es un valor valido");
                    WriteLine("Salieo del programa...");
                }
                finally 
                {
                    Printer.EscirbirTitulo("Finally");
                    Printer.GenerarSonidoBeep(2500, 500, 3);
                }
                
            }

        }
        private static void acciOnDelEvento(object sender, EventArgs e)
        {
            Printer.EscirbirTitulo("Saliendo...");
            Printer.GenerarSonidoBeep(3000,1000);
            Printer.EscirbirTitulo("Salio");
        }

        private static bool Predicado(Curso objCurso)
        {
            return objCurso.NombreObjetoEscuela == "103";
        }

        private static void ImprimirCursosEscuela(Escuela objEscuela)
        {
            
            Printer.EscirbirTitulo(TextoCursosEscuela);
            
            if (objEscuela?.CursosLista != null) {

                ImprimirCursos(objEscuela.CursosLista);
            }

           
        }
        private static void ImprimirCursos(List<Curso> ListaCursos)
        {
            foreach(var CursosN in ListaCursos)
            {
                WriteLine($"Nombre: {CursosN.NombreObjetoEscuela}, Id: {CursosN.IDentificadorunico}, Tipo De Jornada: {CursosN.TipoDeJornada}");
            }
        }
    }
}