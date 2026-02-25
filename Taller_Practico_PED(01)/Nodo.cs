using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_Practico_PED_01_
{
    public class Nodo
    {
        public string Nombre { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(string nombre) { 
            Nombre = nombre;
            Siguiente = null;
        }
    }
}
