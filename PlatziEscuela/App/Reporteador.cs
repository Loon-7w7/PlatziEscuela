using PlatziEscuela.Entidades;
using System;
using System.Linq;
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

        public IEnumerable<Escuela> GetListaDeEvaluaciones()
        {
            IEnumerable<Escuela> Respuesta;
            if (_Diccionario.TryGetValue(LlaveDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase> Lista))
            {
                Respuesta = Lista.Cast<Escuela>();
            }
            {
                Respuesta = null;
            }
            return Respuesta;
        }
    }
}
