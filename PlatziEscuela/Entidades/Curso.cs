using System;
using System.Collections.Generic;
using System.Text;
using PlatziEscuela.Entidades.Interfaces;
using PlatziEscuela.Util;
namespace PlatziEscuela.Entidades
{
    public class Curso : ObjetoEscuelaBase , ILugar
    {

        public TiposJornada TipoDeJornada { get; set; }

        public List<Asignatura> ListaDeAsiganturas { get; set; }
        public List<Alumno> ListaDeAlumnos { get; set; }
        public string Direcion { get; set; }

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiendo Establecimiento...");
            Console.WriteLine($"curso {NombreObjetoEscuela} esta Limpio");
        }
    }
}
