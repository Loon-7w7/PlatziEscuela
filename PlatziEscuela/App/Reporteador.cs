using PlatziEscuela.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlatziEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _Diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> DicionarioObjetosEscuela) 
        {
            if (DicionarioObjetosEscuela == null)
            {
                throw new ArgumentNullException (nameof (DicionarioObjetosEscuela));
            }
            _Diccionario = DicionarioObjetosEscuela;
        }

        public IEnumerable<Evalucaiones> GetListaDeEvaluaciones()
        {
            _Diccionario[LlaveDiccionario.Evaluacione];
        }
    }
}
