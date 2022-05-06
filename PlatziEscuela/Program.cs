using System;
using PlatziEscuela.Entidades;

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

            var ArregloCursos = new Curso[3];

            ArregloCursos[0] = new Curso()
            {
                NombreCurso = "101"
            };

            var curso2 = new Curso()
            {
                NombreCurso = "102"
            };

            ArregloCursos[1] = curso2;
            ArregloCursos[2] = new Curso {
            NombreCurso = "103"
            };

            ObjEscuela.Pais = PaisEscuela;
            ObjEscuela.Ciudad = CiudadEscuela;
            Console.WriteLine(ObjEscuela);
            Console.WriteLine("================");
            ImprimirCursos(ArregloCursos);
        }

        private static void ImprimirCursos(Curso[] arregloCursos)
        {
            foreach(var CursosN in arregloCursos)
            {
                Console.WriteLine($"Nombre: {CursosN.NombreCurso}, Id: {CursosN.IdentidicadorUnico}");
            }
        }
    }
}