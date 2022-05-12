using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace PlatziEscuela.Util
{
    public static class Printer
    {
        
        public static void DrawLine(int TamañoLinea = 10) 
        {
            WriteLine("".PadLeft(TamañoLinea, '='));
        }

        public static void PrecioneEnter()
        {
            WriteLine("Precione Enter Para continuar");
        }

        public static void EscirbirTitulo(string Titulo)
        {
            var TamañoDeLinea = Titulo.Length + 4;
            DrawLine(TamañoDeLinea);
            WriteLine($"| {Titulo} |");
            DrawLine(TamañoDeLinea);

        }

        public static void GenerarSonidoBeep(int HZ = 2000, int Tiempo = 500, int cantidad = 1) 
        {
            while (cantidad-- > 0) 
            {
                Console.Beep(HZ,Tiempo);
            }
        }
        public static void PresioneEscOenter()
        {
            WriteLine("\nPresione ENTER para continuar, presione ESC para volver al Menú...");
        }

    }
}
