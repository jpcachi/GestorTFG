using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorTFG2
{
    public partial class Form_Alumno : Form
    {
        private int indice;
        public Form_Alumno(int indice)
        {
            InitializeComponent();
            this.indice = indice;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (Owner as Form1).AsignarAlumno(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Text, indice);
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
