using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestorTFG;

namespace GestorTFG2
{
    public partial class Form_Profesor : Form
    {
        private int indice;
        public Form_Profesor(int indice)
        {
            InitializeComponent();
            this.indice = indice;
            textBox1.Text = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Profesor.Nombre;
            textBox2.Text = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Profesor.PrimerApellido;
            textBox3.Text = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Profesor.SegundoApellido;
            textBox4.Text = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Profesor.Correo;
            textBox5.Text = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Profesor.Despacho;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox5.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (Owner as Form1).ModificarProfesor(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
