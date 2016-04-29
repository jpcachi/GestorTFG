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
            vista.ActualizarVistaTabla(ref listView1, TipoLista.Busqueda);
            toolStripStatusLabel2.Text = busqueda;
            contextMenuStrip1.Renderer = new ToolStripVisualStyles.ToolStripAeroRenderer(ToolStripVisualStyles.ToolbarTheme.HelpBar);
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show();
                contextMenuStrip1.Location = MousePosition;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                richTextBox2.Text = "Información sobre el profesor:\r\nNombre: " +
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Profesor.Nombre + "\r\nPrimer apellido: " +
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Profesor.PrimerApellido + "\r\nSegundo apellido: " +
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Profesor.SegundoApellido + "\r\nCorreo electrónico: " +
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Profesor.Correo + "\r\nDespacho: " +
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Profesor.Despacho;

                richTextBox1.Text = "Información sobre el TFG:\r\nTítulo: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].getMTFG.Titulo + "\r\nDescripción: " +
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].getMTFG.Descripcion + "\r\nAsignado: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Asignado +
                        "\r\nFinalizado: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].getMTFG.Finalizado;
            }
        }
    }
}
