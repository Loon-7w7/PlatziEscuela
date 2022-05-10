using System;
using System.Collections.Generic;
using PlatziEscuela.Entidades;
using PlatziEscuela.App;
using PlatziEscuela.Util;
using static System.Console;

namespace PlatziEscuela
{
    public class Program
    {
        
        
        private const string TextoCursosEscuela = "Cursos de la escuela";
        private const string TextoBienvenidaEscuela = "Bienvendido A la escuela";

        static void Main(string[] args)
        {
            var Engine = new EscuelaEngine();
            Engine.InicialicarValoresDelPrograma();
            Printer.EscirbirTitulo(TextoBienvenidaEscuela);
            ImprimirCursosEscuela(Engine.ObjeEscuela);

            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.EscirbirTitulo("Prueba De Polimorfismo");
            var alumteste = new Alumno { NombreObjetoEscuela = "Claire Underwood" };
            ObjetoEscuelaBase ObjetSchool = alumteste;

            Printer.EscirbirTitulo("Alumno");
            WriteLine($"Alumno: {alumteste.NombreObjetoEscuela}");
            Printer.EscirbirTitulo("Objeto");
            WriteLine($"Alumno: {ObjetSchool.NombreObjetoEscuela}");
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