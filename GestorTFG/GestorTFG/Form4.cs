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
    public partial class Form4 : Form
    {
        private VistaGrafica vista;
        public Form4(string busqueda)
        {
            vista = new VistaGrafica();
            InitializeComponent();
            vista.ActualizarVistaTabla(ref listView1, 3);
            toolStripStatusLabel2.Text = busqueda;
        }
    }
}
