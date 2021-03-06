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



            return GetListaDeAsignaturas(out var dummy);


        }
        public IEnumerable<string> GetListaDeAsignaturas( out IEnumerable<Evalucaiones> ListaDeEvaluaciones)
        {
             ListaDeEvaluaciones = GetListaDeEvaluaciones();



            return (from Evalucaiones eval in ListaDeEvaluaciones
                   where eval.Calificacion > 3.0f
                   select eval.ObjAsignatura.NombreObjetoEscuela).Distinct();
            

        }

        public Dictionary<string, IEnumerable<Evalucaiones>> GetDicEvaluaXAsig()
        {
            var dictaRta = new Dictionary<string, IEnumerable<Evalucaiones>>();
            var ListaAsiganaturas = GetListaDeAsignaturas(out var LisaEvaluacion);
            foreach (var asing in ListaAsiganaturas)
            {
                var evalasig = from eval in LisaEvaluacion
                               where eval.ObjAsignatura.NombreObjetoEscuela == asing
                              select eval;
                dictaRta.Add(asing, evalasig);
            }
            return dictaRta;
        }

        public Dictionary<string, IEnumerable<object>> GetPromedioAlumnoPorAsignatura() 
        {
            var Respuesta = new Dictionary<string, IEnumerable<object>>();
            var dicEvalxAsig = GetDicEvaluaXAsig();
            foreach (var AsigConEval in dicEvalxAsig)
            {
                var promedioDeAlumnos = from Evalu in AsigConEval.Value
                             group Evalu by new { Evalu.ObjAlumno.IDentificadorunico,Evalu.ObjAlumno.NombreObjetoEscuela }
                             into GrupoEvaluacionAlumno
                             select new AlumnoPromedio
                             {
                                 AlumnoID = GrupoEvaluacionAlumno.Key.IDentificadorunico,
                                 NombreAlumno = GrupoEvaluacionAlumno.Key.NombreObjetoEscuela,
                                 promeido = GrupoEvaluacionAlumno.Average(evalua => evalua.Calificacion)
                             };
                Respuesta.Add(AsigConEval.Key,promedioDeAlumnos);
            }
            return Respuesta;
        }

        public Dictionary<string, IEnumerable<object>> GetTopPromedioAlumnos(int NumTop) 
        {
            var Respuesta = new Dictionary<string, IEnumerable<object>>();
            var ListaPromedioa = GetPromedioAlumnoPorAsignatura();
            foreach (var asig in ListaPromedioa)
            {
                var FiltroDeproemdios = (from AlumnoPromedio prom in asig.Value
                                         orderby prom.promeido descending
                                         select prom).Take(NumTop).ToList();
                Respuesta.Add(asig.Key, FiltroDeproemdios);
            }
            return Respuesta;
        }
        public Dictionary<string, IEnumerable<Object>> GetTopPromedioPorCadaAsignatura(int top)
        {
            var respuesta = new Dictionary<string, IEnumerable<Object>>();
            var diccionarioEvaluacionesPorAsignatura = GetDicEvaluaXAsig();
            foreach (var asignaturaConEvaluaciones in diccionarioEvaluacionesPorAsignatura)
            {
                var promediosAlumnos = (from evaluacion in asignaturaConEvaluaciones.Value
                                        group evaluacion by new
                                        {
                                            evaluacion.ObjAlumno.IDentificadorunico,
                                            evaluacion.ObjAlumno.NombreObjetoEscuela
                                        }
                            into grupoEvaluacionesAlumno
                                        select new AlumnoPromedio
                                        {
                                            AlumnoID= grupoEvaluacionesAlumno.Key.IDentificadorunico,
                                            NombreAlumno = grupoEvaluacionesAlumno.Key.NombreObjetoEscuela,
                                            promeido = grupoEvaluacionesAlumno.Average(evaluacion => evaluacion.Calificacion)
                                        }).OrderByDescending(alumno => alumno.promeido).Take(top);
                respuesta.Add(asignaturaConEvaluaciones.Key, promediosAlumnos);
            }
            return respuesta;
        }

        public Dictionary<String, IEnumerable<Object>> GetTopPromedioDeUnaAsignatura(string asignatura, int top)
        {
            var respuesta = new Dictionary<string, IEnumerable<Object>>();
            var topPromedios = GetTopPromedioPorCadaAsignatura(top);
            foreach (var asig in topPromedios)
            {
                if (asig.Key.Equals(asignatura))
                {
                    respuesta.Add(asignatura, asig.Value);
                }
            }
            return respuesta;
        }
    }
}
