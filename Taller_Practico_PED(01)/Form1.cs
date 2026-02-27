using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller_Practico_PED_01_
{
    public partial class Form1 : Form
    {
        ColaEnlazada cola = new ColaEnlazada();

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string atendido = cola.Desencolar();

            if (atendido != null){
                MessageBox.Show("Nombre atendido: " + atendido, "Atención");
            }
            else
            {
                MessageBox.Show("No hay nombres en la cola.", "Atención");
            }
            pnlDibujo.Invalidate(); // Esto fuerza a que se vuelva a llamar al evento Paint
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;

            if (string.IsNullOrEmpty(nombre) ) {
                MessageBox.Show("Por favor, ingrese un nombre.");
                return;
            } else if (nombre.Any(char.IsDigit)){ 
                MessageBox.Show("El nombre no debe contener números.");
                return;
            }else {
                cola.Encolar(nombre);
                txtNombre.Clear();
                txtNombre.Focus();
                
                MessageBox.Show("Nombre encolado: " + nombre, "Registro");
            }
            pnlDibujo.Invalidate(); // Esto fuerza a que se vuelva a llamar al evento Paint
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            lstEspera.Items.Clear();

            string[] nombresEnCola = cola.MostrarTodos();

            if (nombresEnCola.Length == 0)
            {
                lstEspera.Items.Add("No hay nombres en la cola.");
            }
            else
            {
                foreach (string nombre in nombresEnCola)
                {
                    lstEspera.Items.Add("- " + nombre);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cola = new ColaEnlazada();
            lstEspera.Items.Clear();
            MessageBox.Show("Cola limpiada.", "Limpieza");
        }

        private void pnlDibujo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Configuración visual
            Pen plumaFlecha = new Pen(Color.Black, 2);
            plumaFlecha.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(5, 5); // Flecha

            Brush pincelRectangulo = Brushes.LightBlue;
            Pen plumaRectangulo = new Pen(Color.Black, 2);
            Font fuenteTexto = new Font("Arial", 9, FontStyle.Bold);
            Brush pincelTexto = Brushes.Black;

            int x = 10; // Posición inicial
            int y = 20;
            int ancho = 80;
            int alto = 40;

            Nodo actual = cola.Cabeza;

            while (actual != null)
            {
                // 1. Dibujar Rectángulo (Nodo)
                g.FillRectangle(pincelRectangulo, x, y, ancho, alto);
                g.DrawRectangle(plumaRectangulo, x, y, ancho, alto);

                // 2. Dibujar Nombre
                g.DrawString(actual.Nombre, fuenteTexto, pincelTexto, x + 5, y + 10);

                // 3. Dibujar Flecha al siguiente
                if (actual.Siguiente != null)
                {
                    g.DrawLine(plumaFlecha, x + ancho, y + (alto / 2), x + ancho + 20, y + (alto / 2));
                }

                x += ancho + 20; // Espaciado para el siguiente nodo
                actual = actual.Siguiente;
            }
        }
    }
}
