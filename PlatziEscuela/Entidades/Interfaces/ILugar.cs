using System;
using System.Collections.Generic;
using System.Text;

namespace PlatziEscuela.Entidades.Interfaces
{
    interface ILugar
    {
        string Direcion { get; set; }
        void LimpiarLugar();
    }
}
