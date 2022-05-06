using System;
using System.Collections.Generic;
using PlatziEscuela.Entidades;
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
            var ObjEscuela = new Escuela(NombreEscuela, 2012, TiposDeEscuela.Primaria,
                Pais: PaisEscuela, Ciudad: CiudadEscuela
                );


            ObjEscuela.CursosLista = new List<Curso>() {
            new Curso(){ NombreCurso = "101", TipoDeJornada = TiposJornada.Mañana },
            new Curso(){ NombreCurso = "102", TipoDeJornada = TiposJornada.Mañana },
            new Curso(){ NombreCurso = "103", TipoDeJornada = TiposJornada.Mañana }
            };
            ObjEscuela.CursosLista.Add(new Curso(){NombreCurso ="201", TipoDeJornada = TiposJornada.Tarde });
            ObjEscuela.CursosLista.Add(new Curso(){ NombreCurso = "202", TipoDeJornada = TiposJornada.Tarde });


            ObjEscuela.Pais = PaisEscuela;
            ObjEscuela.Ciudad = CiudadEscuela;
            WriteLine(ObjEscuela);
            WriteLine(Separador);
            ImprimirCursos(ObjEscuela.CursosLista);
            ImprimirCursosEscuela(ObjEscuela);
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
                WriteLine($"Nombre: {CursosN.NombreCurso}, Id: {CursosN.IdentidicadorUnico}");
            }
        }
    }
}