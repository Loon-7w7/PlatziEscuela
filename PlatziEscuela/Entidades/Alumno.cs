using System;
using System.Collections.Generic;
using System.Text;

namespace PlatziEscuela.Entidades
{
    public class Alumno : ObjetoEscuelaBase
    {

        public List<Evalucaiones> ListaEvaluaciones { get; set; } = new List<Evalucaiones>();

    }
}
