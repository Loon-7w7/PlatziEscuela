using System;
using System.Collections.Generic;
using PlatziEscuela.Entidades;
using PlatziEscuela.App;
using static System.Console;

namespace PlatziEscuela
{
    public class Program
    {
        private const string NombreEscuela = "Platzi Academy";
        private const string CiudadEscuela = "Bigota";
        private const string PaisEscuela = "Colimbia";
        private const string Separador = "================";
        private const string TextoCursosEscuela = "Cursos de la escuela";

        static void Main(string[] args)
        {
            var Engine = new EscuelaEngine();
            Engine.InicialicarValoresDelPrograma();
            ImprimirCursosEscuela(Engine.ObjeEscuela);
        }

        private static bool Predicado(Curso objCurso)
        {
            return objCurso.NombreCurso == "103";
        }

        private static void ImprimirCursosEscuela(Escuela objEscuela)
        {
            WriteLine(Separador);
            WriteLine(TextoCursosEscuela);
            WriteLine(Separador);
            if (objEscuela?.CursosLista != null) {

                ImprimirCursos(objEscuela.CursosLista);
            }

           
        }
        private static void ImprimirCursos(List<Curso> ListaCursos)
        {
            foreach(var CursosN in ListaCursos)
            {
                WriteLine($"Nombre: {CursosN.NombreCurso}, Id: {CursosN.IdentidicadorUnico}, Tipo De Jornada: {CursosN.TipoDeJornada}");
            }
        }
    }
}