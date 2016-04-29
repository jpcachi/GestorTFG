using System;
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
                vista.ActualizarDatosRichTextBox(ref richTextBox1, listView1, TDatos.TFG);
                vista.ActualizarDatosRichTextBox(ref richTextBox2, listView1, TDatos.Profesor);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Constantes.SendMessage(listView1.Handle, Constantes.LVM_SETTEXTBKCOLOR, IntPtr.Zero, unchecked((IntPtr)(int)0xFFFFFF));
        }
    }
}
