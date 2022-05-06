using System;
using System.Collections.Generic;
using System.Text;
using PlatziEscuela.Entidades;

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

        public void InicialicarValoresDelPrograma() {
            // Inicializando Escuela
            ObjeEscuela = new Escuela(NombreEscuela, 2012, TiposDeEscuela.Primaria,
                    Pais: PaisEscuela, Ciudad: CiudadEscuela
                    );

            //Inicializando cursos de la escuela 
            ObjeEscuela.CursosLista = new List<Curso>() {
            new Curso(){ NombreCurso = "101", TipoDeJornada = TiposJornada.Mañana },
            new Curso(){ NombreCurso = "102", TipoDeJornada = TiposJornada.Mañana },
            new Curso(){ NombreCurso = "103", TipoDeJornada = TiposJornada.Mañana },
            new Curso(){ NombreCurso = "201", TipoDeJornada = TiposJornada.Tarde  },
            new Curso(){ NombreCurso = "202", TipoDeJornada = TiposJornada.Tarde  },
            new Curso(){ NombreCurso = "202", TipoDeJornada = TiposJornada.Mañana }

            };
        }

    }
}
