using System;
using System.Collections.Generic;
using System.Text;

namespace PlatziEscuela.Entidades
{
    public class Evalucaiones
    {
        public string IdentidicadorUnico { get; private set; }
        public string NombreEvaluaciones { get; set; }
        public Alumno ObjAlumno { get; set; }
        public Asignatura ObjAsignatura { get; set; }
        public float Calificacion { get; set; }
        public Evalucaiones() => IdentidicadorUnico = Guid.NewGuid().ToString();
    }
}
