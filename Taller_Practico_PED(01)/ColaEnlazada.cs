using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_Practico_PED_01_
{
    public class ColaEnlazada
    {
        public Nodo Cabeza { get; set; }
        public Nodo cola;

        public ColaEnlazada()
        {
            Cabeza = null;
            cola = null;
        }

        public void Encolar(string nombre)
        {
            Nodo nuevoNodo = new Nodo(nombre);
            if (Cabeza == null)
            {
                Cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                cola.Siguiente = nuevoNodo;
                cola = nuevoNodo;
            }
        }

        // metodo para el primer nodo de la cola
        public string Desencolar()
        {
            if (Cabeza == null)
            {
                return null;
            }
            else
            {
                string nombreAtendido = Cabeza.Nombre;
                Cabeza = Cabeza.Siguiente;

                if (Cabeza == null)
                {
                    cola = null;
                }
                return nombreAtendido;
            }
        }

        public string[] MostrarTodos()
        {
            int contador = 0;
            Nodo nodoActual = Cabeza;

            while (nodoActual != null)
            {
                contador++;
                nodoActual = nodoActual.Siguiente;
            }

            string[] nombres = new string[contador];
            nodoActual = Cabeza;
            int i = 0;

            while (nodoActual != null)
            {
                nombres[i] = nodoActual.Nombre;
                nodoActual = nodoActual.Siguiente;
                i++;
            }

            return nombres;
        }
    }
}
