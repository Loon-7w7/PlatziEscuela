using System;
using System.Collections.Generic;
using System.Text;

namespace PlatziEscuela.Entidades
{
    public class Evalucaiones : ObjetoEscuelaBase
    {

        public Alumno ObjAlumno { get; set; }
        public Asignatura ObjAsignatura { get; set; }
        public float Calificacion { get; set; }


        public override string ToString()
        {
            return $"{Calificacion} {ObjAlumno.NombreObjetoEscuela} {ObjAsignatura.NombreObjetoEscuela}";
        }
    }
}
