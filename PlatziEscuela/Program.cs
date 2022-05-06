using System;
using PlatziEscuela.Entidades;
using static System.Console;

namespace PlatziEscuela
{
    public class Program
    {
        private const string NombreEscuela = "Platzi Academy";
        private const string CiudadEscuela = "Bigota";
        private const string PaisEscuela = "Colimbia";

        static void Main(string[] args)
        {
            var ObjEscuela = new Escuela(NombreEscuela, 2012, TiposDeEscuela.Primaria,
                Pais:"Colombia", Ciudad:"Bobota"
                );

           

            ObjEscuela.CursosArreglo = new Curso[] {
            new Curso(){ NombreCurso = "101"},
            new Curso(){ NombreCurso = "102"},
            new Curso { NombreCurso = "103"}
            };

            ImprimirCursosEscuela(ObjEscuela);

            ObjEscuela.Pais = PaisEscuela;
            ObjEscuela.Ciudad = CiudadEscuela;
            WriteLine(ObjEscuela);
            WriteLine("================");
            ImprimirCursos(ObjEscuela.CursosArreglo);
        }

        private static void ImprimirCursosEscuela(Escuela objEscuela)
        {
            WriteLine("==========");
            WriteLine("Cursos de la escuela");
            WriteLine("==========");
            if (objEscuela?.CursosArreglo != null) {

                ImprimirCursos(objEscuela.CursosArreglo);
            }

           
        }

        private static void ImprimirCursos(Curso[] arregloCursos)
        {
            foreach(var CursosN in arregloCursos)
            {
                WriteLine($"Nombre: {CursosN.NombreCurso}, Id: {CursosN.IdentidicadorUnico}");
            }
        }
    }
}