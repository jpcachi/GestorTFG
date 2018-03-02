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
    public partial class Form1 : Form
    {
        private Form2 barraHerramientasFlotante;
        private CAlumno cAlumno;
        private CProyectos cProyectos;
        private LeerEscribirArchivo fichero;
        private Buscador buscador;
        private Copiar copiar;
        
        public Form1()
        {
            InitializeComponent();
            cAlumno = new CAlumno();
            cProyectos = new CProyectos();
            fichero = new LeerEscribirArchivo();
            buscador = new Buscador(this);
            menuStrip1.Renderer = new ToolStripAeroRenderer(ToolbarTheme.HelpBar);
            toolStrip1.Renderer = new ToolStripAeroRenderer(ToolbarTheme.HelpBar);
            contextMenuStrip1.Renderer = new ToolStripAeroRenderer(ToolbarTheme.HelpBar);
            tabControlView1.ListaTodosProyectos.RetrieveVirtualItem += ListaTodosProyectos_RetrieveVirtualItem;
            tabControlView1.ListaProyectosSinAsignar.RetrieveVirtualItem += ListaProyectosSinAsignar_RetrieveVirtualItem;
            tabControlView1.ListaProyectosFinalizados.RetrieveVirtualItem += ListaProyectosFinalizados_RetrieveVirtualItem;

            tabControlView1.ListaTodosProyectos.SelectedIndexChanged += ListaTodosProyectos_SelectedIndexChanged;
            tabControlView1.ListaProyectosSinAsignar.SelectedIndexChanged += ListaProyectosSinAsignar_SelectedIndexChanged;
            tabControlView1.ListaProyectosFinalizados.SelectedIndexChanged += ListaProyectosFinalizados_SelectedIndexChanged;
            tabControlView1.ListaTodosProyectos.MouseClick += ListaProyectos_MouseClick;
            tabControlView1.ListaProyectosSinAsignar.MouseClick += ListaProyectos_MouseClick;
            tabControlView1.ListaProyectosFinalizados.MouseClick += ListaProyectos_MouseClick;
            tabControlView1.SelectedTabChanged += TabControlView1_SelectedTabChanged;

            comboBox10.SelectedIndex = 0;
            OcultarInformacion();
        }

        private void ListaProyectos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (sender.GetType() == typeof(CustomListView))
                {
                    copiar = new Copiar(toolStripMenuItem7);
                    if ((sender as CustomListView).SelectedIndices.Count > 1)
                    {
                        toolStripMenuItem1.Enabled = false;
                        toolStripMenuItem2.Enabled = false;
                        toolStripMenuItem4.Enabled = false;
                        toolStripMenuItem19.Enabled = false;
                    }
                    else if ((sender as CustomListView).SelectedIndices.Count == 1)
                    {
                        toolStripMenuItem1.Enabled = true;
                        toolStripMenuItem2.Enabled = true;
                        toolStripMenuItem4.Enabled = true;
                        toolStripMenuItem19.Enabled = true;
                    }
                    contextMenuStrip1.Show();
                    contextMenuStrip1.Location = MousePosition;
                }
            }
        }

        private void TabControlView1_SelectedTabChanged(object sender, EventArgs e)
        {
            ActualizarOpcionesEditar();
            ActualizarNumProyectos();
        }

        private void ActualizarOpcionesEditar()
        {
            if (tabControlView1.SelectedTab == 0)
            {
                ActualizarOpcionesEditarTodosProyectos();
            }
            else if (tabControlView1.SelectedTab == 1)
            {
                ActualizarOpcionesEditarProyectoSinAsignar();
            }
            else
            {
                ActualizarOpcionesEditarProyectoFinalizado();
            }
        }

        private void ActualizarNumProyectos()
        {
            toolStripStatusLabel2.Text = string.Format("{0} Proyectos", tabControlView1.ListaProyectos[tabControlView1.SelectedTab].VirtualListSize);
        }
        private void ActualizarOpcionesEditarProyectoFinalizado()
        {
            if (tabControlView1.ListaProyectosFinalizados.SelectedIndices.Count == 0)
            {
                DesactivarTodosBotonesEditarProyecto();
                OcultarInformacion();
            }
            else
            {
                if (tabControlView1.ListaProyectosFinalizados.SelectedIndices.Count > 1)
                {
                    DesactivarBotonesSeleccionMultiple();
                }
                else
                {
                    DesactivarBotonesEditarProyectoFinalizado();
                    AñadirOpcionesComboBoxCampoModificar(TipoLista.Finalizados, tabControlView1.ListaProyectosFinalizados.SelectedIndices[0]);
                    MostrarInformacion(TipoLista.Finalizados, tabControlView1.ListaProyectosFinalizados.SelectedIndices[0]);
                }
            }
        }
        private void ListaProyectosFinalizados_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarOpcionesEditarProyectoFinalizado();
        }

        private void ActualizarOpcionesEditarProyectoSinAsignar()
        {
            if (tabControlView1.ListaProyectosSinAsignar.SelectedIndices.Count == 0)
            {
                DesactivarTodosBotonesEditarProyecto();
                OcultarInformacion();
            }
            else
            {
                if (tabControlView1.ListaProyectosSinAsignar.SelectedIndices.Count > 1)
                {
                    DesactivarBotonesSeleccionMultiple();
                }
                else
                {
                    DesactivarBotonesEditarProyectoNoAsignado();
                    AñadirOpcionesComboBoxCampoModificar(TipoLista.Sin_Asignar, tabControlView1.ListaProyectosSinAsignar.SelectedIndices[0]);
                    MostrarInformacion(TipoLista.Sin_Asignar, tabControlView1.ListaProyectosSinAsignar.SelectedIndices[0]);
                }
            }
        }

        private void ListaProyectosSinAsignar_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarOpcionesEditarProyectoSinAsignar();
        }

        private void ActualizarOpcionesEditarTodosProyectos()
        {
            if (tabControlView1.ListaTodosProyectos.SelectedIndices.Count == 0)
            {
                DesactivarTodosBotonesEditarProyecto();
                OcultarInformacion();
            }
            else
            {
                if (tabControlView1.ListaTodosProyectos.SelectedIndices.Count > 1)
                {
                    DesactivarBotonesSeleccionMultiple(true);
                }
                else
                {
                    if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[tabControlView1.ListaTodosProyectos.SelectedIndices[0]].Asignado)
                    {
                        if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[tabControlView1.ListaTodosProyectos.SelectedIndices[0]].getMTFG.Finalizado)
                        {
                            DesactivarBotonesEditarProyectoFinalizado();
                        }
                        else DesactivarBotonesEditarProyectoNoFinalizado();
                    }
                    else DesactivarBotonesEditarProyectoNoAsignado();
                    AñadirOpcionesComboBoxCampoModificar(TipoLista.Todos, tabControlView1.ListaTodosProyectos.SelectedIndices[0]);
                    MostrarInformacion(TipoLista.Todos, tabControlView1.ListaTodosProyectos.SelectedIndices[0]);
                }
            }
        }
        private void ListaTodosProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarOpcionesEditarTodosProyectos();
        }

        private void ListaProyectosFinalizados_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = ListViewItemUtilidades.ConvertirProyectoEnItemLista(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados[e.ItemIndex]);
        }

        private void ListaProyectosSinAsignar_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = ListViewItemUtilidades.ConvertirProyectoEnItemLista(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[e.ItemIndex]);
        }

        private void ListaTodosProyectos_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            try
            {
                e.Item = ListViewItemUtilidades.ConvertirProyectoEnItemLista(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[e.ItemIndex]);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (barraHerramientasFlotante == null || barraHerramientasFlotante.IsDisposed)
            {
                barraHerramientasFlotante = new Form2();
            }
            if (barraHerramientasFlotante.Controls.Count == 0)
            {
                button12.Image = Properties.Resources.import_icon_16;
                barraHerramientasFlotante.Controls.Add(panel9);
                barraHerramientasFlotante.Show(this);
            } else
            {
                AñadirBarraHerramientas();
                barraHerramientasFlotante.Close();
            }
        }

        public void AñadirBarraHerramientas()
        {
            button12.Image = Properties.Resources.export_icon_16;
            Controls.Add(panel9);
            menuStrip1.SendToBack();
        }

        private void panel2_VisibleChanged(object sender, EventArgs e)
        {
            panelGestionarToolStripMenuItem.Checked = panel2.Visible;
            panelView2.Visible = panel2.Visible;
        }

        private void barraDeHerramientasToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if(barraHerramientasFlotante == null || barraHerramientasFlotante.IsDisposed)
                toolStrip1.Visible = barraDeHerramientasToolStripMenuItem.Checked;
            else
            {
                barraHerramientasFlotante.Visible = barraDeHerramientasToolStripMenuItem.Checked;
            }
        }

        private void panelGestionarToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (panel2.Visible)
            {
                if (!panelGestionarToolStripMenuItem.Checked)
                    panel2.Visible = false;
            } else
            {
                if (panelGestionarToolStripMenuItem.Checked)
                    panel2.Visible = true;
            }
        }

        private void panelGestionarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_VisibleChanged(object sender, EventArgs e)
        {
            búsquedaToolStripMenuItem.Checked = panel1.Visible;
            panelView1.Visible = panel1.Visible;
        }

        private void búsquedaToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                if (!búsquedaToolStripMenuItem.Checked)
                    panel1.Visible = false;
            }
            else
            {
                if (búsquedaToolStripMenuItem.Checked)
                    panel1.Visible = true;
            }
        }

        private void datosToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (panel6.Visible)
            {
                if (!datosToolStripMenuItem.Checked)
                    panel6.Visible = false;
            }
            else
            {
                if (datosToolStripMenuItem.Checked)
                    panel6.Visible = true;
            }
        }

        private void panel6_VisibleChanged(object sender, EventArgs e)
        {
            datosToolStripMenuItem.Checked = panel6.Visible;
            panelView3.Visible = panel6.Visible;
        }

        //boton añadir
        private void button2_Click(object sender, EventArgs e)
        {
            tabControlView1.SelectedTab = 0;
            cProyectos.AñadirProyecto(textBox6.Text.Trim(), textBox7.Text.Trim(), 
                dateTimePicker1.Value.Date, textBox1.Text.Trim(), 
                textBox2.Text.Trim(), textBox3.Text.Trim(), 
                textBox4.Text.Trim(), textBox5.Text.Trim());
            ActualizarVistaTablas();
            SeleccionarIndicesListView(TipoLista.Todos, MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Count - 1);
            LimpiarCampos(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, dateTimePicker1);
            if (MessageBox.Show("El Proyecto se ha añadido correctamente. ¿Desea asignarle un nuevo Alumno?", "Añadir Proyecto", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                new Form_Alumno(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Count - 1).Show(this);
            ActualizarNumProyectos();
        }

        //boton limpiar
        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarCampos(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, dateTimePicker1);
        }

        private void LimpiarCampos(params Control[] campos)
        {
            foreach(Control c in campos)
            {
                if(c is TextBox || c is ComboBox) c.Text = string.Empty;
                else if (c is DateTimePicker) (c as DateTimePicker).Value = DateTime.Today;
                else if (c is NumericUpDown) (c as NumericUpDown).Value = 0;
            }
        }

        public void AsignarAlumno(string nombre, string primerApellido, string segundoApellido, string matricula, string fechaInicio, int indice)
        {
            cAlumno.AsignarAlumno(nombre, primerApellido, segundoApellido, matricula, fechaInicio, indice);
            ActualizarVistaTablas();
            tabControlView1.SelectedTab = 0;
            SeleccionarIndicesListView(TipoLista.Todos, indice);
        }

        //Actualizar listView
        public void AñadirProyectoVistaTabla(CustomListView listView)
        {
            MProyecto mProyecto = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Count - 1];
            ListViewItem listViewItem = new ListViewItem(mProyecto.getMTFG.Titulo);
            listViewItem.SubItems.Add(mProyecto.getMTFG.Descripcion);
            listViewItem.SubItems.Add(mProyecto.getMTFG.Fecha.Date.ToShortDateString());
            listView.VirtualListSize = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Count;
        }

        public void ActualizarVistaTablas()
        {
            tabControlView1.ListaTodosProyectos.VirtualListSize = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[0].Count;
            tabControlView1.ListaProyectosSinAsignar.VirtualListSize = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[1].Count;
            tabControlView1.ListaProyectosFinalizados.VirtualListSize = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[2].Count;

            
            if (tabControlView1.ListaTodosProyectos.SelectedIndices.Count > 0)
                tabControlView1.ListaTodosProyectos.RedrawItems(tabControlView1.ListaTodosProyectos.SelectedIndices[0], tabControlView1.ListaTodosProyectos.SelectedIndices[tabControlView1.ListaTodosProyectos.SelectedIndices.Count - 1], false);
            if (tabControlView1.ListaProyectosSinAsignar.SelectedIndices.Count > 0)
                tabControlView1.ListaProyectosSinAsignar.RedrawItems(tabControlView1.ListaProyectosSinAsignar.SelectedIndices[0], tabControlView1.ListaProyectosSinAsignar.SelectedIndices[tabControlView1.ListaProyectosSinAsignar.SelectedIndices.Count - 1], false);
            if (tabControlView1.ListaProyectosFinalizados.SelectedIndices.Count > 0)
                tabControlView1.ListaProyectosFinalizados.RedrawItems(tabControlView1.ListaProyectosFinalizados.SelectedIndices[0], tabControlView1.ListaProyectosFinalizados.SelectedIndices[tabControlView1.ListaProyectosFinalizados.SelectedIndices.Count - 1], false);
        }

        private void DesactivarBotonesEditarProyectoNoAsignado()
        {
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = true;
            toolStripButton4.Enabled = false;
            toolStripButton5.Enabled = true;

            groupBox5.Enabled = true;
            button11.Enabled = true; button8.Enabled = true; button9.Enabled = true;
            button7.Enabled = false;
            groupBox4.Enabled = false;
            groupBox3.Enabled = true;
        }

        private void DesactivarBotonesEditarProyectoNoFinalizado()
        {
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = true;
            toolStripButton5.Enabled = true;

            groupBox5.Enabled = true;
            button11.Enabled = true; button8.Enabled = false; button9.Enabled = true;
            button7.Enabled = true;
            groupBox4.Enabled = true;
            groupBox3.Enabled = true;
        }

        private void DesactivarBotonesEditarProyectoFinalizado()
        {
            toolStripButton2.Enabled = true;
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = false;
            toolStripButton5.Enabled = true;

            groupBox5.Enabled = true;
            button11.Enabled = true; button8.Enabled = false; button9.Enabled = true;
            button7.Enabled = false;
            groupBox4.Enabled = false;
            groupBox3.Enabled = true;
        }

        private void DesactivarTodosBotonesEditarProyecto()
        {
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = false;
            toolStripButton5.Enabled = false;

            groupBox5.Enabled = false;
            groupBox4.Enabled = false;
            groupBox3.Enabled = false;
        }

        private void DesactivarBotonesSeleccionMultiple(bool eliminarAlumno = false)
        {
            toolStripButton2.Enabled = false;
            toolStripButton3.Enabled = false;
            toolStripButton4.Enabled = eliminarAlumno;
            toolStripButton5.Enabled = true;

            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = true;
            button11.Enabled = false;
            button8.Enabled = false;
            button7.Enabled = eliminarAlumno;
            button9.Enabled = true;
        }

        private void AñadirOpcionesComboBoxCampoModificar(TipoLista tipo, int indice)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Título");
            comboBox1.Items.Add("Descripción");
            comboBox1.Items.Add("Fecha de Registro");
            if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)tipo][indice].Asignado)
            {
                comboBox1.Items.Add("Nombre del Alumno");
                comboBox1.Items.Add("Primer Apellido");
                comboBox1.Items.Add("Segundo Apellido");
                comboBox1.Items.Add("Matrícula");
                comboBox1.Items.Add("Fecha de Inicio");
                if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)tipo][indice].getMTFG.Finalizado)
                {
                    comboBox1.Items.Add("Fecha de la Defensa");
                    comboBox1.Items.Add("Convocatoria");
                    comboBox1.Items.Add("Calificación");
                }
            }
        }

        private void groupBox3_EnabledChanged(object sender, EventArgs e)
        {
            if (!groupBox3.Enabled)
            {
                comboBox1.SelectedIndex = -1;
                comboBox1.Items.Clear();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                //titulo
                case 0:
                    dateTimePicker3.Visible = false;
                    numericUpDown1.Visible = false;
                    comboBox3.Visible = false;
                    textBox8.Visible = true;
                    textBox8.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[tabControlView1.SelectedTab][tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[0]].getMTFG.Titulo;
                    break;
                //Descripcion
                case 1:
                    dateTimePicker3.Visible = false;
                    numericUpDown1.Visible = false;
                    comboBox3.Visible = false;
                    textBox8.Visible = true;
                    textBox8.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[tabControlView1.SelectedTab][tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[0]].getMTFG.Descripcion;
                    break;
                //Fecha Registro
                case 2:
                    dateTimePicker3.Visible = true;
                    numericUpDown1.Visible = false;
                    comboBox3.Visible = false;
                    textBox8.Visible = false;
                    dateTimePicker3.Value = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[tabControlView1.SelectedTab][tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[0]].getMTFG.Fecha;
                    break;
                //Nombre Alumno
                case 3:
                    dateTimePicker3.Visible = false;
                    numericUpDown1.Visible = false;
                    comboBox3.Visible = false;
                    textBox8.Visible = true;
                    textBox8.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[tabControlView1.SelectedTab][tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[0]].Alumno.Nombre;
                    break;
                //1er Apellido
                case 4:
                    dateTimePicker3.Visible = false;
                    numericUpDown1.Visible = false;
                    comboBox3.Visible = false;
                    textBox8.Visible = true;
                    textBox8.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[tabControlView1.SelectedTab][tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[0]].Alumno.PrimerApellido;
                    break;
                //2o Apellido
                case 5:
                    dateTimePicker3.Visible = false;
                    numericUpDown1.Visible = false;
                    comboBox3.Visible = false;
                    textBox8.Visible = true;
                    textBox8.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[tabControlView1.SelectedTab][tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[0]].Alumno.SegundoApellido;
                    break;
                //Matricula
                case 6:
                    dateTimePicker3.Visible = false;
                    numericUpDown1.Visible = false;
                    comboBox3.Visible = false;
                    textBox8.Visible = true;
                    textBox8.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[tabControlView1.SelectedTab][tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[0]].Alumno.Matricula;
                    break;
                //Fecha Inicio
                case 7:
                    dateTimePicker3.Visible = true;
                    numericUpDown1.Visible = false;
                    comboBox3.Visible = false;
                    textBox8.Visible = false;
                    dateTimePicker3.Value = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[tabControlView1.SelectedTab][tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[0]].Alumno.FechaInicio;
                    break;
                //Fecha Defensa
                case 8:
                    dateTimePicker3.Visible = true;
                    numericUpDown1.Visible = false;
                    comboBox3.Visible = false;
                    textBox8.Visible = false;
                    dateTimePicker3.Value = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[tabControlView1.SelectedTab][tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[0]].getMTFG.getMFinalizado.Defensa;
                    break;
                //Convocatoria
                case 9:
                    dateTimePicker3.Visible = false;
                    numericUpDown1.Visible = false;
                    comboBox3.Visible = true;
                    textBox8.Visible = false;
                    comboBox3.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[tabControlView1.SelectedTab][tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[0]].getMTFG.getMFinalizado.Convocatoria;
                    break;
                //Calificacion
                case 10:
                    dateTimePicker3.Visible = false;
                    numericUpDown1.Visible = true;
                    comboBox3.Visible = false;
                    textBox8.Visible = false;
                    numericUpDown1.Value = (decimal) MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[tabControlView1.SelectedTab][tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[0]].getMTFG.getMFinalizado.Nota;
                    break;
                default:
                    dateTimePicker3.Visible = false;
                    numericUpDown1.Visible = false;
                    comboBox3.Visible = false;
                    textBox8.Visible = true;
                    textBox8.Text = string.Empty;
                    break;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button4.Enabled = comboBox2.SelectedIndex != -1;
        }

        //boton finalizar
        private void button4_Click(object sender, EventArgs e)
        {
            cProyectos.FinalizarProyecto(dateTimePicker2.Value, comboBox2.Text.Trim(), (float)numericUpDown2.Value, tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[0]);
            DesactivarBotonesFinalizar();
            groupBox4.Enabled = false;
            SeleccionarIndicesListView(TipoLista.Todos, tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[0]);
            ActualizarVistaTablas();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DesactivarBotonesFinalizar();
        }

        private void DesactivarBotonesFinalizar()
        {
            dateTimePicker2.Value = DateTime.Today;
            comboBox2.SelectedIndex = -1;
            numericUpDown2.Value = 0;
        }

        private string ObtenerValorModificar()
        {
            string resul = string.Empty;

            if (dateTimePicker3.Visible) resul = dateTimePicker3.Text;
            else if (numericUpDown1.Visible) resul = numericUpDown1.Value.ToString();
            else if (comboBox3.Visible) resul = comboBox3.Text;
            else if (textBox8.Visible) resul = textBox8.Text;

            return resul.Trim();
        }

        private int ObtenerIndiceEnListaPrincipal(TipoLista lista, int indice)
        {
            int _indice = (lista == TipoLista.Todos) ? indice : MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[tabControlView1.SelectedTab][indice]);
            return _indice;
        }

        //boton modificar
        private void button5_Click(object sender, EventArgs e)
        {
            cProyectos.ModificarProyecto(comboBox1.SelectedIndex, ObtenerValorModificar(), ObtenerIndiceEnListaPrincipal((TipoLista)tabControlView1.SelectedTab, tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[0]));
            ActualizarVistaTablas();
        }

        //Asignar Alumno
        private void button8_Click(object sender, EventArgs e)
        {
            new Form_Alumno(ObtenerIndiceEnListaPrincipal((TipoLista)tabControlView1.SelectedTab, tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[0])).Show(this);
        }

        private void SeleccionarIndicesListView(TipoLista lista, int indice, bool multiple = false)
        {
            if(!multiple)
                tabControlView1.ListaProyectos[(int)lista].SelectedIndices.Clear();
            tabControlView1.ListaProyectos[(int)lista].SelectedIndices.Add(indice);
            tabControlView1.ListaProyectos[(int)lista].EnsureVisible(indice);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text + textBox5.Text + textBox6.Text + textBox7.Text);
            button2.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrWhiteSpace(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox7.Text);
        }

        //boton eliminar Alumno
        private void button7_Click(object sender, EventArgs e)
        {
            string alumno = tabControlView1.ListaTodosProyectos.SelectedIndices.Count > 1 ? "los alumnos de los Proyectos seleccionados?" : "el alumno del Proyecto seleccionado?";
            if (MessageBox.Show("¿Está seguro de que desea eliminar " + alumno, "Eliminar Alumno", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (int indice in tabControlView1.ListaTodosProyectos.SelectedIndices)
                {
                    cAlumno.EliminarAlumno(indice);
                    SeleccionarIndicesListView(TipoLista.Todos, indice, true);
                }
                ActualizarVistaTablas();
            }
        }

        //boton eliminar TFG
        private void button9_Click(object sender, EventArgs e)
        {
            string proyecto = tabControlView1.ListaTodosProyectos.SelectedIndices.Count > 1 ? "los Proyectos seleccionados?" : "el Proyecto seleccionado?";
            if (MessageBox.Show("¿Está seguro de que desea eliminar " + proyecto, "Eliminar Proyecto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                for (int i = tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices.Count - 1; i >= 0 ; i--)
			    {
                    cProyectos.EliminarProyecto(ObtenerIndiceEnListaPrincipal((TipoLista)tabControlView1.SelectedTab, tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[i]));
                }
                ActualizarVistaTablas();
                tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices.Clear();
                ActualizarOpcionesEditar();
                ActualizarNumProyectos();
            }
        }

        private void OcultarInformacion()
        {
            //16, 32, 26, 27, 28, 17, 33, 29, 30, 31, 24, 22, 42, 44, 25, 23, 43, 45
            label16.Visible = false;
            label32.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            label28.Visible = false;
            label17.Visible = false;
            label33.Visible = false;
            label29.Visible = false;
            label30.Visible = false;
            label31.Visible = false;
            label24.Visible = false;
            label22.Visible = false;
            label42.Visible = false;
            label44.Visible = false;
            label25.Visible = false;
            label23.Visible = false;
            label43.Visible = false;
            label45.Visible = false;
        }

        private void MostrarInformacion(TipoLista lista, int indice)
        {
            //16, 32, 26, 27, 28, 17, 33, 29, 30, 31, 24, 22, 42, 44, 25, 23, 43, 45
            label16.Visible = true;
            label32.Visible = true;
            label26.Visible = true;
            label27.Visible = true;
            label28.Visible = true;

            label17.Visible = true;
            label17.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][indice].getMTFG.Titulo;
            label33.Visible = true;
            label33.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][indice].getMTFG.Descripcion;
            label29.Visible = true;
            label29.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][indice].Profesor.Nombre +
                " " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][indice].Profesor.PrimerApellido +
                " " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][indice].Profesor.SegundoApellido;
            label30.Visible = true;
            label30.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][indice].Profesor.Correo;
            label31.Visible = true;
            label31.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][indice].Profesor.Despacho;

            label24.Visible = true;
            label22.Visible = true;

            label25.Visible = true;
            label25.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][indice].Asignado ? (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][indice].getMTFG.Finalizado ? "Finalizado" : "Asignado") : "Sin Asignar";
            label23.Visible = true;
            label23.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][indice].getMTFG.Fecha.Date.ToShortDateString();

            if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][indice].getMTFG.Finalizado)
            {
                label42.Visible = true;
                label44.Visible = true;
                label43.Visible = true;
                label43.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][indice].getMTFG.getMFinalizado.Convocatoria;
                label45.Visible = true;
                label45.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][indice].getMTFG.getMFinalizado.Nota.ToString("0.###");
                label45.ForeColor = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][indice].getMTFG.getMFinalizado.Nota >= 5 ? Color.SeaGreen : Color.Firebrick;
            } else
            {
                label42.Visible = false;
                label44.Visible = false;
                label43.Visible = false;
                label45.Visible = false;
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog cargar = new OpenFileDialog();
            cargar.Filter = "Lista de Proyectos (*.txt)|*.txt";
            cargar.FilterIndex = 1;
            if (cargar.ShowDialog() == DialogResult.OK)
            {
                fichero.CerrarEscritura();
                fichero.AbrirLectura(cargar.FileName);
                fichero.ImportarArchivo();

                ActualizarVistaTablas();
                ActualizarNumProyectos();
            }
        }

        //Editar Profesor
        private void button11_Click(object sender, EventArgs e)
        {
            new Form_Profesor(ObtenerIndiceEnListaPrincipal((TipoLista)tabControlView1.SelectedTab, tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[0])).Show(this);
        }

        public void ModificarProfesor(string nombre, string primerApellido, string segundoApellido, string correo, string despacho)
        {
            int indice = ObtenerIndiceEnListaPrincipal((TipoLista)tabControlView1.SelectedTab, tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[0]);
            cProyectos.ModificarProfesor(nombre, primerApellido, segundoApellido, correo, despacho, indice);
            ActualizarVistaTablas();
            tabControlView1.SelectedTab = 0;
            SeleccionarIndicesListView(TipoLista.Todos, indice);
        }

        //boton buscar
        private void button10_Click(object sender, EventArgs e)
        {
            buscador.BuscarProyecto(comboBox7.Text.Trim(), (TCampos)comboBox10.SelectedIndex, comboBox9.SelectedIndex, comboBox4.SelectedIndex, comboBox5.SelectedIndex, comboBox8.SelectedIndex, dateTimePicker4.Value, dateTimePicker5.Value, dateTimePicker6.Value, numericUpDown4.Value, fichero);
            if (!string.IsNullOrWhiteSpace(comboBox7.Text) && !comboBox7.Items.Contains(comboBox7.Text.Trim()))
                comboBox7.Items.Add(comboBox7.Text.Trim());
        }

        public void SeleccionarItemLista(int indice)
        {
            tabControlView1.SelectedTab = 0;
            SeleccionarIndicesListView(TipoLista.Todos, indice);
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.SelectedIndex == 0)
            {
                comboBox7.Items.Clear();
                comboBox7.Items.Add("- Borrar búsquedas recientes -");
            }
        }


        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            button10.Enabled = comboBox10.SelectedIndex != -1;
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker4.Enabled = comboBox9.SelectedIndex > 0;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker5.Enabled = comboBox4.SelectedIndex > 0;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker6.Enabled = comboBox5.SelectedIndex > 0;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown4.Enabled = comboBox8.SelectedIndex > 0;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            new Form12(tabControlView1.ListaProyectos[tabControlView1.SelectedTab].SelectedIndices[0], (TipoLista) tabControlView1.SelectedTab).Show();
        }
    }
}
