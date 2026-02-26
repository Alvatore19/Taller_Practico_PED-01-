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
    }
}
