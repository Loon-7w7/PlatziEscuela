using System;
using System.Collections.Generic;
using System.Text;
using PlatziEscuela.Entidades;
using System.Linq;

namespace PlatziEscuela.App
{
    public sealed class EscuelaEngine
    {
        public Escuela ObjeEscuela { get; set; }
        private const string NombreEscuela = "Platzi Academy";
        private const string CiudadEscuela = "Bigota";
        private const string PaisEscuela = "Colimbia";

        public EscuelaEngine() {


        }

        public void InicialicarValoresDelPrograma()
        {
            // Inicializando Escuela
            ObjeEscuela = new Escuela(NombreEscuela, 2012, TiposDeEscuela.Primaria,
                    Pais: PaisEscuela, Ciudad: CiudadEscuela
                    );

            //Inicializando cursos de la escuela 
            InicializarCursos();
            //Inicializando Asignaturas de la escuela
            InicializarAsignaturas();
            //Inicializando Alumnos de la escuela

            //Inicializando Evaluaciones de la escuela
            InicializarEvaluaciones();
        }


        public Dictionary<string, IEnumerable<ObjetoEscuelaBase>> GetDicionario() 
        {
            var diccionario = new Dictionary<string, IEnumerable<ObjetoEscuelaBase>>();
            diccionario.Add("Escuela",new[] {ObjeEscuela});
            diccionario.Add("Curos", ObjeEscuela.CursosLista.Cast<ObjetoEscuelaBase>());
            return diccionario;
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObejtosEscuela(
            bool TraerEvaluciones = true,
            bool TraerAlumnos = true,
            bool TraerAsignaturas = true,
            bool TraerCuros = true)
        {
            return GetObejtosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObejtosEscuela(
            out int ConteoEvaluaciones,
           bool TraerEvaluciones = true,
           bool TraerAlumnos = true,
           bool TraerAsignaturas = true,
           bool TraerCuros = true)
        {
            return GetObejtosEscuela(out ConteoEvaluaciones, out int dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObejtosEscuela(
            out int ConteoEvaluaciones, out int ConteoCursos,
           bool TraerEvaluciones = true,
           bool TraerAlumnos = true,
           bool TraerAsignaturas = true,
           bool TraerCuros = true)
        {
            return GetObejtosEscuela(out ConteoEvaluaciones, out ConteoCursos, out int dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObejtosEscuela(
            out int ConteoEvaluaciones, out int ConteoCursos, out int ConteoAsignaturas,
           bool TraerEvaluciones = true,
           bool TraerAlumnos = true,
           bool TraerAsignaturas = true,
           bool TraerCuros = true)
        {
            return GetObejtosEscuela(out ConteoEvaluaciones, out ConteoCursos, out ConteoAsignaturas, out int dummy);
        }
        public IReadOnlyList <ObjetoEscuelaBase> GetObejtosEscuela(
            out int ConteoEvaluaciones,
            out int ConteoAlumnos,
            out int ConteoAsignaturas,
            out int ConteoCursos,
            bool TraerEvaluciones = true,
            bool TraerAlumnos = true,
            bool TraerAsignaturas = true,
            bool TraerCuros = true)
        {

            ConteoAlumnos = ConteoAsignaturas = ConteoEvaluaciones = 0;
            var ListaObejto = new List<ObjetoEscuelaBase>();
            ListaObejto.Add(ObjeEscuela);
            if (TraerCuros)
                ListaObejto.AddRange(ObjeEscuela.CursosLista);

            ConteoCursos = ObjeEscuela.CursosLista.Count;
            foreach (var curso in ObjeEscuela.CursosLista)
            {
                ConteoAsignaturas += curso.ListaDeAsiganturas.Count;
                ConteoAlumnos += curso.ListaDeAlumnos.Count;
                if (TraerAsignaturas)
                    ListaObejto.AddRange(curso.ListaDeAsiganturas);
                if (TraerAlumnos)
                    ListaObejto.AddRange(curso.ListaDeAlumnos);

                if (TraerEvaluciones)
                {
                    
                    foreach (var Alum in curso.ListaDeAlumnos)
                    {
                        ListaObejto.AddRange(Alum.ListaEvaluaciones);
                        ConteoEvaluaciones += Alum.ListaEvaluaciones.Count;
                    }
                }
            }
            return ListaObejto.AsReadOnly();
        }
        #region Metodos de carga
        private void InicializarAsignaturas()
        {
            foreach (var Curso in ObjeEscuela.CursosLista) 
            {
                List<Asignatura> ListaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura { NombreObjetoEscuela ="Matematicas" },
                    new Asignatura { NombreObjetoEscuela ="Educacion Fisica" },
                    new Asignatura { NombreObjetoEscuela ="Castellano" },
                    new Asignatura { NombreObjetoEscuela ="Ciencias Naturales" }
                };
                Curso.ListaDeAsiganturas = ListaAsignaturas;
            }
        }
        private List<Alumno> GenerarAlumnosAlAzar(int CantidadDeAlunos)
        {
            string[] PrimerNombre = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] ApeliidoPaterno = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] SegundoNombre = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var ListadeAlunnos = from Nombre1 in PrimerNombre
                                 from Nombre2 in SegundoNombre
                                 from Apellido in ApeliidoPaterno
                                 select new Alumno { NombreObjetoEscuela = $"{Nombre1} {Nombre2} {Apellido}" };
            return ListadeAlunnos.OrderBy( (Alum)=>Alum.IDentificadorunico ).Take(CantidadDeAlunos).ToList();
        }
        private void InicializarCursos()
        {
            ObjeEscuela.CursosLista = new List<Curso>() {
            new Curso(){ NombreObjetoEscuela = "101", TipoDeJornada = TiposJornada.Mañana },
            new Curso(){ NombreObjetoEscuela = "102", TipoDeJornada = TiposJornada.Mañana },
            new Curso(){ NombreObjetoEscuela = "103", TipoDeJornada = TiposJornada.Mañana },
            new Curso(){ NombreObjetoEscuela = "201", TipoDeJornada = TiposJornada.Tarde  },
            new Curso(){ NombreObjetoEscuela = "202", TipoDeJornada = TiposJornada.Tarde  },
            new Curso(){ NombreObjetoEscuela = "202", TipoDeJornada = TiposJornada.Mañana }
            };
            Random NumRandom = new Random();
          
            foreach (var Cur in ObjeEscuela.CursosLista) 
            {
                int cantidadRandom = NumRandom.Next(5, 20);
                Cur.ListaDeAlumnos = GenerarAlumnosAlAzar(cantidadRandom);
            }

        }
        private void InicializarEvaluaciones()
        {
            foreach (var curso in ObjeEscuela.CursosLista)
            {
                foreach (var asigna in curso.ListaDeAsiganturas)
                {
                    foreach (var alum in curso.ListaDeAlumnos)
                    {
                        var NumRandom = new Random(System.Environment.TickCount);
                        for (int i = 0; i < 5; i++)
                        {
                            var evaluacion = new Evalucaiones
                            {
                                NombreObjetoEscuela = $"Evaluación N°{i + 1} de {asigna.NombreObjetoEscuela}",
                                ObjAlumno = alum,
                                ObjAsignatura = asigna,
                                Calificacion = (float)(NumRandom.NextDouble() * 5)
                            };
                            alum.ListaEvaluaciones.Add(evaluacion);
                        }
                    }
                }
            }
        }
        #endregion 
    }
    
}
