using System;
using System.Collections.Generic;
using System.Text;

namespace PlatziEscuela.Entidades
{
    public class Curso : ObjetoEscuelaBase
    {

        public TiposJornada TipoDeJornada { get; set; }

        public List<Asignatura> ListaDeAsiganturas { get; set; }
        public List<Alumno> ListaDeAlumnos { get; set; }

       
    }
}
