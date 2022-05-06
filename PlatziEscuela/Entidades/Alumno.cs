using System;
using System.Collections.Generic;
using System.Text;

namespace PlatziEscuela.Entidades
{
    public class Alumno
    {
        public string IdentidicadorUnico { get; private set; }
        public string NombreAlumno { get; set; }
        public Alumno() => IdentidicadorUnico = Guid.NewGuid().ToString();
    }
}
