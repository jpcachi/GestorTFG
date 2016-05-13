using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorTFG
{
    public partial class Form10 : Form
    {
        private int indice;
        public Form10(string[] datos, int indice)
        {
            InitializeComponent();
            textBox1.Text = datos[0];
            textBox2.Text = datos[1];
            textBox3.Text = datos[2];
            textBox4.Text = datos[3];
            textBox5.Text = datos[4];
            this.indice = indice;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text + textBox5.Text))
            {
                MessageBox.Show("Rellene todos los campos antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult = DialogResult.OK;
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Profesor.Nombre = textBox1.Text;
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Profesor.PrimerApellido = textBox2.Text;
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Profesor.SegundoApellido = textBox3.Text;
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Profesor.Correo = textBox4.Text;
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Profesor.Despacho = textBox5.Text;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
