using System;
using System.Collections.Generic;
using System.Text;
using PlatziEscuela.Entidades;
using System.Linq;

namespace PlatziEscuela.App
{
    public class EscuelaEngine
    {
        public Escuela ObjeEscuela { get; set; }
        private const string NombreEscuela = "Platzi Academy";
        private const string CiudadEscuela = "Bigota";
        private const string PaisEscuela = "Colimbia";

        public EscuelaEngine() {


        }

        public void InicialicarValoresDelPrograma()
        {
            // Inicializando Escuela
            ObjeEscuela = new Escuela(NombreEscuela, 2012, TiposDeEscuela.Primaria,
                    Pais: PaisEscuela, Ciudad: CiudadEscuela
                    );

            //Inicializando cursos de la escuela 
            InicializarCursos();
            //Inicializando Asignaturas de la escuela
            InicializarAsignaturas();
            //Inicializando Alumnos de la escuela
            foreach (var VCurso in ObjeEscuela.CursosLista) 
            {
                VCurso.ListaDeAlumnos.AddRange(GenerarAlumnosAlAzar());
            }
            //Inicializando Evaluaciones de la escuela
            InicializarEvaluaciones();
        }

        private void InicializarEvaluaciones()
        {
            
        }

        private void InicializarAsignaturas()
        {
            foreach (var Curso in ObjeEscuela.CursosLista) 
            {
                List<Asignatura> ListaAsignaturas = new List<Asignatura>() 
                {
                    new Asignatura { NombreAsignatura ="Matematicas" },
                    new Asignatura { NombreAsignatura ="Educacion Fisica" },
                    new Asignatura { NombreAsignatura ="Castellano" },
                    new Asignatura { NombreAsignatura ="Ciencias Naturales" }
                };
                Curso.ListaDeAsiganturas = ListaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int CantidadDeAlunos)
        {
            string[] PrimerNombre = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] ApeliidoPaterno = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] SegundoNombre = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var ListadeAlunnos = from Nombre1 in PrimerNombre
                                 from Nombre2 in SegundoNombre
                                 from Apellido in ApeliidoPaterno
                                 select new Alumno { NombreAlumno = $"{Nombre1} {Nombre2} {Apellido}" };
            return ListadeAlunnos.OrderBy( (Alum)=>Alum.IdentidicadorUnico ).Take(CantidadDeAlunos).ToList();
        }

        private void InicializarCursos()
        {
            ObjeEscuela.CursosLista = new List<Curso>() {
            new Curso(){ NombreCurso = "101", TipoDeJornada = TiposJornada.Mañana },
            new Curso(){ NombreCurso = "102", TipoDeJornada = TiposJornada.Mañana },
            new Curso(){ NombreCurso = "103", TipoDeJornada = TiposJornada.Mañana },
            new Curso(){ NombreCurso = "201", TipoDeJornada = TiposJornada.Tarde  },
            new Curso(){ NombreCurso = "202", TipoDeJornada = TiposJornada.Tarde  },
            new Curso(){ NombreCurso = "202", TipoDeJornada = TiposJornada.Mañana }
            };
            Random NumRandom = new Random();
          
            foreach (var Cur in ObjeEscuela.CursosLista) 
            {
                int cantidadRandom = NumRandom.Next(5, 20);
                Cur.ListaDeAlumnos = GenerarAlumnosAlAzar(cantidadRandom);
            }

        }
    }
}
