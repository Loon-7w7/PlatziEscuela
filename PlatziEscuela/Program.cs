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

            var Reported = new Reporteador(Engine.GetDicionario());
            var evalList = Reported.GetListaDeEvaluaciones();
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