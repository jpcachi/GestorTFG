using System;
using System.Windows.Forms;

namespace GestorTFG
{
    public partial class Form4 : Form
    {
        private VistaGrafica vista;
        private Copiar copiar;
        private Form1 ventanaPadre;
        private LeerEscribirArchivo fichero;

        private string busqueda;
        private TCampos campo;
        public Form4(Form1 ventanaPadre, string busqueda, TCampos campo, int index1, int index2, int index3, int index4, DateTime date1, DateTime date2, DateTime date3, decimal nota, bool filtro, LeerEscribirArchivo fichero)
        {
            InitializeComponent();
            toolStrip1.Renderer = new ToolStripVisualStyles.ToolStripAeroRenderer(ToolStripVisualStyles.ToolbarTheme.Toolbar);
            this.fichero = fichero;
            vista = new VistaGrafica();
            copiar = new Copiar(copiarPorCampoToolStripMenuItem);
            this.ventanaPadre = ventanaPadre;
            this.busqueda = busqueda;
            this.campo = campo;

            toolStripStatusLabel1.Text += busqueda;
            if(index1 + index2 + index3 + index4 > 0 && filtro)
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
                if(index2 != 0)
                {
                    toolStripStatusLabel2.Text += ";";
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
                    toolStripStatusLabel2.Text += ";";
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
                    toolStripStatusLabel2.Text += ";";
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
            }
            contextMenuStrip1.Renderer = new ToolStripVisualStyles.ToolStripAeroRenderer(ToolStripVisualStyles.ToolbarTheme.HelpBar);
            vista.ActualizarVistaTabla(ref listView1, TipoLista.Busqueda);
            toolStripStatusLabel3.Text = listView1.Items.Count + " proyectos";
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
                copiarToolStripButton1.Enabled = true;
                vista.ActualizarDatosRichTextBox(ref richTextBox1, listView1, TipoLista.Busqueda, TDatos.TFG);
                vista.ActualizarDatosRichTextBox(ref richTextBox2, listView1, TipoLista.Busqueda, TDatos.Profesor);
            } else
            {
                copiarToolStripButton1.Enabled = false;
                richTextBox1.ResetText();
                richTextBox2.ResetText();
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
            /*string proyecto = MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.Titulo + ";" +
                MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.Descripcion + ";" +
                MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.Fecha;
            if (MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Asignado)
            {
                proyecto += ";" + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Alumno.Nombre + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Alumno.PrimerApellido +
                    ";" + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Alumno.SegundoApellido + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Alumno.Matricula +
                    ";" + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Alumno.FechaInicio;
                if (MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.Finalizado)
                    proyecto += ";" + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Defensa + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Convocatoria +
                        ";" + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Nota;
            }
            Clipboard.SetText(proyecto);*/
            copiar.toolStripMenuItem1_Click(listView1, TipoLista.Busqueda, sender, e);
        }

        private void copiarPorCampoToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            /*if (MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Asignado)
            {
                copiarPorCampoToolStripMenuItem.DropDownItems[3].Visible = true;
                copiarPorCampoToolStripMenuItem.DropDownItems[4].Visible = true;
                copiarPorCampoToolStripMenuItem.DropDownItems[5].Visible = true;
                copiarPorCampoToolStripMenuItem.DropDownItems[6].Visible = true;
                copiarPorCampoToolStripMenuItem.DropDownItems[7].Visible = true;
                if (MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.Finalizado)
                {
                    
                    copiarPorCampoToolStripMenuItem.DropDownItems[8].Visible = true;
                    copiarPorCampoToolStripMenuItem.DropDownItems[9].Visible = true;
                    copiarPorCampoToolStripMenuItem.DropDownItems[10].Visible = true;
                } else
                {
                    copiarPorCampoToolStripMenuItem.DropDownItems[8].Visible = false;
                    copiarPorCampoToolStripMenuItem.DropDownItems[9].Visible = false;
                    copiarPorCampoToolStripMenuItem.DropDownItems[10].Visible = false;
                }
            } else
            {
                copiarPorCampoToolStripMenuItem.DropDownItems[3].Visible = false;
                copiarPorCampoToolStripMenuItem.DropDownItems[4].Visible = false;
                copiarPorCampoToolStripMenuItem.DropDownItems[5].Visible = false;
                copiarPorCampoToolStripMenuItem.DropDownItems[6].Visible = false;
                copiarPorCampoToolStripMenuItem.DropDownItems[7].Visible = false;
                copiarPorCampoToolStripMenuItem.DropDownItems[8].Visible = false;
                copiarPorCampoToolStripMenuItem.DropDownItems[9].Visible = false;
                copiarPorCampoToolStripMenuItem.DropDownItems[10].Visible = false;
            }*/
            copiar.copiarPorCampoToolStripMenuItem_DropDownOpening(listView1, TipoLista.Busqueda, sender, e);
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
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.Fecha);
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
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Alumno.FechaInicio);
        }

        private void fechaDeDefensaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Defensa);
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
            /*Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Profesor.Nombre +
                ";" + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Profesor.PrimerApellido + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Profesor.SegundoApellido + ";" +
                MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Profesor.Despacho + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Profesor.Correo);*/
            copiar.copiarDatosDeProfesorToolStripMenuItem_Click(listView1, TipoLista.Busqueda, sender, e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            /*string proyecto = "Título: " + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.Titulo + "\r\nDescripción: " +
                MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.Descripcion + "\r\nRegistrado el: " +
                MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.Fecha + "\r\nNombre del profesor: " + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Profesor.Nombre +
                " " + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Profesor.PrimerApellido + " " + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Profesor.SegundoApellido + "\r\nDespacho: " +
                MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Profesor.Despacho + "\r\nCorreo electrónico: " + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Profesor.Correo;
            if (MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Asignado)
            {
                proyecto += "\r\nNombre del alumno" + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Alumno.Nombre + " " + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Alumno.PrimerApellido +
                    " " + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Alumno.SegundoApellido + "\r\nMatrícula: " + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Alumno.Matricula +
                    "\r\nFecha de inicio" + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].Alumno.FechaInicio;
                if (MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.Finalizado)
                    proyecto += "\r\nFecha de la defensa: " + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Defensa + "\r\nConvocatoria: " + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Convocatoria +
                        "\r\nCalificación: " + MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto[listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Nota;
            }
            Clipboard.SetText(proyecto);*/
            copiar.copiarConFormato_Click(listView1, TipoLista.Busqueda, sender, e);
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
                vista.GuardarLista();
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
            copiar.toolStripMenuItem1_Click(listView1, TipoLista.Busqueda, sender, e);
        }

        private void mostrarInformaciónDetalladaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form8(listView1, TipoLista.Busqueda).ShowDialog(this);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                new Form8(listView1, TipoLista.Busqueda).ShowDialog(this);
            }
        }
    }
}
