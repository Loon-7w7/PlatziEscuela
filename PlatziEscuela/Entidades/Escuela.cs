using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using PlatziEscuela.Entidades.Interfaces;
using PlatziEscuela.Util;

namespace PlatziEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase , ILugar
    {

        public int AñorDeCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string DirecionEscuela { get; set; }
        public TiposDeEscuela TipoEscuerla { get; set; }
        public List<Curso> CursosLista { get; set; }
        public string Direcion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Escuela(string Nombre, int AñorDeCreacion) => (this.NombreObjetoEscuela, this.AñorDeCreacion) = (Nombre, AñorDeCreacion);

        public Escuela(string Nombre, int AñorDeCreacion,
            TiposDeEscuela TipoEscuela,
            string Pais = "",
            string Ciudad = "") {

            this.NombreObjetoEscuela = Nombre;
            this.AñorDeCreacion = AñorDeCreacion;
            this.Pais = Pais;
            this.Ciudad = Ciudad;
        } 
        public override string ToString()
        {
            return $"Nombre Escuela: {NombreObjetoEscuela}, Tipo Escuela: {TipoEscuerla},\nPais: {Pais}, Ciudad: {Ciudad}";
        }

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            WriteLine("Limpiendo Escuela...");
            foreach (var Curso in CursosLista) 
            {
                Curso.LimpiarLugar();
            }
            Printer.EscirbirTitulo($"Escuela {NombreObjetoEscuela} esta Limpia");
        }
    }
}