using System;
using System.Collections.Generic;
using System.Text;

namespace PlatziEscuela.Entidades
{
    public class Curso
    {
        public string IdentidicadorUnico { get;private set; }
        public string NombreCurso { get; set; }
        public TiposJornada TipoDeJornada { get; set; }

        public Curso()=>IdentidicadorUnico = Guid.NewGuid().ToString();
    }
}
