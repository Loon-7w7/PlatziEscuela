using System;
using System.Collections.Generic;
using System.Text;

namespace PlatziEscuela.constanttexts
{
    public class SConstanTextMostrarmenu
    {
        public List<string> ShowSelector { get; private set; }
        public List<string> ShowPressEnterOrEsc { get; private set; }

        public SConstanTextMostrarmenu() 
        {
            InitializeShowSelector();
            InitializeShowPressEnterOrEsc();
        }


        private void InitializeShowSelector() 
        {
            ShowSelector = new List<string> 
            {
                "Reporteador de Escuela",
                "1. Mostrar lista de evaluaciones",
                "2. Mostrar lista de evaluaciónes por asignatura",
                "3. Mostrar lista de asignaturas",
                "4. Mostrar lista de promedios por asignatura",
                "5. Mostrar top de promedios por asignatura",
                "6. Mostrar top de promedios de una asignatura",
                "7. Finalizar Programa",
                "\nIngrese el número de la opción del reporteador",
            };
        }
        private void InitializeShowPressEnterOrEsc() 
        {
            ShowPressEnterOrEsc = new List<string>
            {
                "\nPresione ENTER para volver al menú, presione ESC para finalizar el programa...",
                "PROGRAMA FINALIZADO"
            };
        }
    }
}
