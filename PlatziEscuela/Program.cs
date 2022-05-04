using System;
using PlatziEscuela.Entidades;

namespace PlatziEscuela
{
    public class Program
    {
        private const string NombreEscuela = "Platzi Academy";
        private const string CiudadEscuela = "Bigota";
        private const string PaisEscuela = "Colimbia";

        static void Main(string[] args)
        {
            var ObjEscuela = new Escuela(NombreEscuela, 2012, TiposDeEscuela.Primaria,
                Pais:"Colombia", Ciudad:"Bobota"
                );

            ObjEscuela.Pais = PaisEscuela;
            ObjEscuela.Ciudad = CiudadEscuela;
            Console.WriteLine(ObjEscuela);
        }
    }
}