using GestorTFG;
using GestorTFG2.ControlesUsuario;
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
    public partial class Form4 : Form
    {
        private Copiar copiar;
        private Form1 ventanaPadre;
        private LeerEscribirArchivo fichero;
        private CProyectos cProyectos;

        private string busqueda;
        private TCampos campo;
        public Form4(Form1 ventanaPadre, string busqueda, TCampos campo, int index1, int index2, int index3, int index4, DateTime date1, DateTime date2, DateTime date3, decimal nota, bool filtro, LeerEscribirArchivo fichero)
        {
            InitializeComponent();
            toolStrip1.Renderer = new ToolStripAeroRenderer(ToolbarTheme.Toolbar);
            cProyectos = new CProyectos();
            this.fichero = fichero;
            copiar = new Copiar(copiarPorCampoToolStripMenuItem);
            this.ventanaPadre = ventanaPadre;
            this.busqueda = busqueda;
            this.campo = campo;

            if (string.IsNullOrWhiteSpace(busqueda))
                toolStripStatusLabel1.Text = "Mostrando todos los resultados";
            else
                toolStripStatusLabel1.Text += "'" + busqueda + "'";
            if (index1 + index2 + index3 + index4 > 0 && filtro)
            {
                toolStripStatusLabel2.Text = " Filtro:";
                if (index1 * index2 * index3 * index4 != 0)
                {
                    toolStripStatusLabel2.Text = " Filtros:";
                }
                switch (index1)
                {
                    case 1:
                        toolStripStatusLabel2.Text += " fecha de registro posterior a " + date1.Day + "/" + date1.Month + "/" + date1.Year;
                        break;
                    case 2:
                        toolStripStatusLabel2.Text += " fecha de registro anterior a " + date1.Day + "/" + date1.Month + "/" + date1.Year;
                        break;
                    case 3:
                        toolStripStatusLabel2.Text += " fecha de registro igual a " + date1.Day + "/" + date1.Month + "/" + date1.Year;
                        break;
                }
                if (index2 != 0)
                {
                    toolStripStatusLabel2.Text += ",";
                }
                switch (index2)
                {
                    case 1:
                        toolStripStatusLabel2.Text += " fecha de inicio posterior a " + date2.Day + "/" + date2.Month + "/" + date2.Year;
                        break;
                    case 2:
                        toolStripStatusLabel2.Text += " fecha de inicio anterior a " + date2.Day + "/" + date2.Month + "/" + date2.Year;
                        break;
                    case 3:
                        toolStripStatusLabel2.Text += " fecha de inicio igual a " + date2.Day + "/" + date2.Month + "/" + date2.Year;
                        break;
                }
                if (index3 != 0)
                {
                    toolStripStatusLabel2.Text += ",";
                }
                switch (index3)
                {
                    case 1:
                        toolStripStatusLabel2.Text += " fecha de defensa posterior a " + date3.Day + "/" + date3.Month + "/" + date3.Year;
                        break;
                    case 2:
                        toolStripStatusLabel2.Text += " fecha de defensa anterior a " + date3.Day + "/" + date3.Month + "/" + date3.Year;
                        break;
                    case 3:
                        toolStripStatusLabel2.Text += " fecha de defensa igual a " + date3.Day + "/" + date3.Month + "/" + date3.Year;
                        break;
                }
                if (index4 != 0)
                {
                    toolStripStatusLabel2.Text += ",";
                }
                switch (index4)
                {
                    case 1:
                        toolStripStatusLabel2.Text += " nota superior a " + nota;
                        break;
                    case 2:
                        toolStripStatusLabel2.Text += " nota superior o igual a " + nota;
                        break;
                    case 3:
                        toolStripStatusLabel2.Text += " nota inferior a " + nota;
                        break;
                    case 4:
                        toolStripStatusLabel2.Text += " nota inferior o igual a " + nota;
                        break;
                    case 5:
                        toolStripStatusLabel2.Text += " nota igual a " + nota;
                        break;
                }
            } else toolStripStatusLabel2.Text = string.Empty;
            contextMenuStrip1.Renderer = new ToolStripAeroRenderer(ToolbarTheme.HelpBar);
            ActualizarVistaTabla(listView1, TipoLista.Busqueda);
            toolStripStatusLabel3.Text = listView1.Items.Count + " proyectos";
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show();
                contextMenuStrip1.Location = MousePosition;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                copiarToolStripButton1.Enabled = true;
                //vista.ActualizarDatosRichTextBox(ref richTextBox1, listView1, TipoLista.Busqueda, TDatos.TFG);
                //vista.ActualizarDatosRichTextBox(ref richTextBox2, listView1, TipoLista.Busqueda, TDatos.Profesor);
                panel8.Visible = true;
                label29.Text = MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Profesor.Nombre;
                label2.Text = MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Profesor.PrimerApellido + ", " +
                    MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Profesor.SegundoApellido;
                label30.Text = MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Profesor.Correo;
                label31.Text = MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Profesor.Despacho;
            }
            else
            {
                copiarToolStripButton1.Enabled = false;
                panel8.Visible = false;
                //richTextBox1.ResetText();
                //richTextBox2.ResetText();
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
            ListViewVisualStyles.DibujarSubItemListViewBusqueda(campo, busqueda, sender, e);
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = ListViewItemUtilidades.ConvertirProyectoEnItemLista(MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[e.ItemIndex]);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            copiar.toolStripMenuItem1_Click(listView1.SelectedIndices[0], TipoLista.Busqueda, sender, e);
        }

        private void copiarPorCampoToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            copiar.copiarPorCampoToolStripMenuItem_DropDownOpening(listView1.SelectedIndices[0], TipoLista.Busqueda, sender, e);
        }

        private void títuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.Titulo);
        }

        private void descripciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.Descripcion);
        }

        private void fechaDeRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.Fecha.Date.ToShortDateString());
        }

        private void nombreDelAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Alumno.Nombre);
        }

        private void primerApellidoDelAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Alumno.PrimerApellido);
        }

        private void segundoApellidoDelAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Alumno.SegundoApellido);
        }

        private void matrículaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Alumno.Matricula);
        }

        private void fechaDeInicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Alumno.FechaInicio.Date.ToShortDateString());
        }

        private void fechaDeDefensaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Defensa.Date.ToShortDateString());
        }

        private void convocatoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Convocatoria);
        }

        private void notaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Nota.ToString());
        }

        private void copiarDatosDeProfesorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copiar.copiarDatosDeProfesorToolStripMenuItem_Click(listView1.SelectedIndices[0], TipoLista.Busqueda, sender, e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            copiar.copiarConFormato_Click(listView1.SelectedIndices[0], TipoLista.Busqueda, sender, e);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ventanaPadre.SeleccionarItemLista(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]]));
            Close();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardarComo = new SaveFileDialog();
            guardarComo.Filter = "Documentos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            guardarComo.FilterIndex = 1;
            DialogResult result = guardarComo.ShowDialog();
            if (result == DialogResult.OK)
            {
                fichero.CerrarLectura();
                fichero.AbrirEscritura(guardarComo.FileName);
                cProyectos.GuardarProyectos();
                fichero.ExportarArchivo(TipoLista.Busqueda);
                fichero.CerrarEscritura();
            }
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            fichero.CerrarFichero();
        }

        private void guardarToolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem4_Click(sender, e);
        }

        private void copiarToolStripButton1_Click(object sender, EventArgs e)
        {
            copiar.toolStripMenuItem1_Click(listView1.SelectedIndices[0], TipoLista.Busqueda, sender, e);
        }

        private void mostrarInformaciónDetalladaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new Form12(listView1.SelectedIndices[0], TipoLista.Busqueda).Show();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //new Form12(listView1.SelectedIndices[0], TipoLista.Busqueda).Show();
            }
        }

        private void ActualizarVistaTabla(CustomListView listView, TipoLista indice)
        {
            listView.VirtualListSize = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice].Count;
        }

        private void Form4_Resize(object sender, EventArgs e)
        {
            listView1.Columns[listView1.Columns.Count - 1].Width = -2;
        }
    }
}
