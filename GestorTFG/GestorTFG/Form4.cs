using System;
using System.Windows.Forms;

namespace GestorTFG
{
    public partial class Form4 : Form
    {
        private VistaGrafica vista;
        private string busqueda;
        public Form4(string busqueda)
        {
            vista = new VistaGrafica();
            InitializeComponent();
            this.busqueda = busqueda;
            toolStripStatusLabel2.Text = busqueda;
            contextMenuStrip1.Renderer = new ToolStripVisualStyles.ToolStripAeroRenderer(ToolStripVisualStyles.ToolbarTheme.HelpBar);
            vista.ActualizarVistaTabla(ref listView1, TipoLista.Busqueda);
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
            if (listView1.SelectedIndices.Count > 0)
            {   
                vista.ActualizarDatosRichTextBox(ref richTextBox1, listView1, TipoLista.Busqueda, TDatos.TFG);
                vista.ActualizarDatosRichTextBox(ref richTextBox2, listView1, TipoLista.Busqueda, TDatos.Profesor);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Constantes.SendMessage(listView1.Handle, Constantes.LVM_SETTEXTBKCOLOR, IntPtr.Zero, unchecked((IntPtr)(int)0xFFFFFF));
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            ListViewVisualStyles.DibujarCabeceras(sender, e);
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            ListViewVisualStyles.DibujarItemListView(sender, e);
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            ListViewVisualStyles.DibujarSubItemListViewBusqueda(busqueda, sender, e);
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = ListViewItemUtilidades.ConvertirProyectoEnItemLista(MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[e.ItemIndex]);
        }
    }
}
