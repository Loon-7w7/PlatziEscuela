using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;


namespace PlatziEscuela.Entidades
{
    public class Escuela
    {
        public string IdentidicadorUnico { get; private set; } = Guid.NewGuid().ToString();
        public string Nombre { get; set; }
        public int AñorDeCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TiposDeEscuela TipoEscuerla { get; set; }
        public List<Curso> CursosLista { get; set; }


        public Escuela(string Nombre, int AñorDeCreacion) => (this.Nombre, this.AñorDeCreacion) = (Nombre, AñorDeCreacion);

        public Escuela(string Nombre, int AñorDeCreacion,
            TiposDeEscuela TipoEscuela,
            string Pais = "",
            string Ciudad = "") {

            this.Nombre = Nombre;
            this.AñorDeCreacion = AñorDeCreacion;
            this.Pais = Pais;
            this.Ciudad = Ciudad;
        } 
        public override string ToString()
        {
            return $"Nombre Escuela: {Nombre}, Tipo Escuela: {TipoEscuerla},\nPais: {Pais}, Ciudad: {Ciudad}";
        } 
    }
}