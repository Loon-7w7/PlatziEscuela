using System;
using System.Collections.Generic;
using System.Text;

namespace PlatziEscuela.Entidades
{
    public class Asignatura
    {
        public string IdentidicadorUnico { get; private set; }
        public string NombreAsignatura { get; set; }
        public Asignatura() => IdentidicadorUnico = Guid.NewGuid().ToString();
    }
}
