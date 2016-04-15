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
    public partial class Form2 : Form
    {
        private Form1 ventanaPadre;
        private string[] datosAlumno;
        public Form1 VentanaAnterior
        {
            set
            {
                ventanaPadre = value;
            }
        }
        public Form2(string[] datosAlumno)
        {
            InitializeComponent();
            this.datosAlumno = datosAlumno;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                datosAlumno[0] = textBox1.Text.Trim();
                datosAlumno[1] = textBox2.Text.Trim();
                datosAlumno[2] = textBox3.Text.Trim();
                datosAlumno[3] = textBox4.Text.Trim();
                datosAlumno[4] = dateTimePicker1.Text;
                Close();
            } else
            {
                MessageBox.Show("Rellene todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
