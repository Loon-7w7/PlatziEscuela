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

        public IEnumerable<Evalucaiones> GetListaDeEvaluaciones()
        {
            if (_Diccionario.TryGetValue(LlaveDiccionario.Evaluacione, out IEnumerable<ObjetoEscuelaBase> Lista))
            {
                return Lista.Cast<Evalucaiones>();
            }
            {
                return new List<Evalucaiones>();
            }
            
        }
        public IEnumerable<string> GetListaDeAsignaturas()
        {
            var ListaDeEvaluaciones = GetListaDeEvaluaciones();



            return (from Evalucaiones eval in ListaDeEvaluaciones
                   where eval.Calificacion > 3.0f
                   select eval.ObjAsignatura.NombreObjetoEscuela).Distinct();
            

        }

        public Dictionary<string, IEnumerable<Evalucaiones>> GetDicEvaluaXAsig()
        {
            var dictaRta = new Dictionary<string, IEnumerable<Evalucaiones>>();
            return dictaRta;
        }
    }
}
