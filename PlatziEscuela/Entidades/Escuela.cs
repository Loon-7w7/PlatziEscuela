using System;
using System.Collections.Generic;
using System.Text;

namespace PlatziEscuela.Entidades
{
    class Escuela
    {
        public string Nombre { get; set; }
        public int AñorDeCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        private int myvar;

        public Escuela(string Nombre, int AñorDeCreacion) => (this.Nombre, this.AñorDeCreacion) = (Nombre, AñorDeCreacion);
    }
}