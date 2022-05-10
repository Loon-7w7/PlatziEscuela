using System;
using System.Collections.Generic;
using System.Text;

namespace PlatziEscuela.Entidades
{
    public abstract class ObjetoEscuelaBase
    {
        public string IDentificadorunico { get; private set; }
        public String NombreObjetoEscuela { get; set; }

        public ObjetoEscuelaBase()
        {
            IDentificadorunico = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{NombreObjetoEscuela} {IDentificadorunico}"; 
        }
    }
}
