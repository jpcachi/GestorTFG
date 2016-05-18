using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using ToolStripVisualStyles;
using System.Windows.Forms.VisualStyles;

namespace GestorTFG
{
    public partial class Form1 : Form
    {
        private VistaGrafica vista;
        private LeerEscribirArchivo fichero;
        private Buscador buscador;
        private Copiar copiar;
        private DeshacerRehacer deshacer;
        //private Splitter splitterLeft;
        //Splitter splitterRight;
        private Splitter splitterDown;
        private Timer SelectedIndexChangedTimer;

        private Form5 form5; //barra de herramientas flotante


        public Form1()
        {
            InitializeComponent();
            vista = new VistaGrafica();
            buscador = new Buscador(this);
            fichero = new LeerEscribirArchivo();
            deshacer = new DeshacerRehacer();
            SelectedIndexChangedTimer = new Timer();

            Size = new Size((int)(Screen.PrimaryScreen.Bounds.Size.Width * Constantes.TAMAÑO_RELATIVO_RESOLUCION), (int)(Screen.PrimaryScreen.Bounds.Size.Height * Constantes.TAMAÑO_RELATIVO_RESOLUCION));

            toolStripStatusLabel1.Text = fichero.ArchivoActual;
            toolStripContainer1.TopToolStripPanel.MaximumSize = new Size(toolStripContainer1.TopToolStripPanel.MaximumSize.Width, toolStripContainer1.TopToolStripPanel.Height);
            toolStripComboBox1.Items.Add("Todos");
            toolStripComboBox1.Items.Add("Título");
            toolStripComboBox1.Items.Add("Descripción");
            toolStripComboBox1.Items.Add("Alumno");
            toolStripComboBox1.Items.Add("Profesor");
            toolStripComboBox2.Items.Add("- Borrar búsquedas recientes -");
            toolStripComboBox1.SelectedIndex = 0;  
            toolStrip2.Renderer = new ToolStripAeroRenderer(ToolbarTheme.Toolbar);
            menuStrip1.Renderer = new ToolStripAeroRenderer(ToolbarTheme.HelpBar);
            contextMenuStrip1.Renderer = new ToolStripAeroRenderer(ToolbarTheme.HelpBar);
            statusStrip1.Renderer = new ToolStripAeroRenderer(ToolbarTheme.HelpBar);

            ListViewVisualStyles.Listas.Add(listView1);
            ListViewVisualStyles.Listas.Add(listView2);
            ListViewVisualStyles.Listas.Add(listView3);


            Shown += Form1_Shown;
            listView1.HideSelection = false;
            listView2.HideSelection = false;
            listView3.HideSelection = false;
            comboBox1.Enabled = false;
            textBox8.Enabled = false;
            dateTimePicker3.Enabled = false;
            numericUpDown1.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = false;
            groupBox3.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            comboBox9.SelectedIndex = 0;
            comboBox10.SelectedIndex = 0;

            //splitterLeft = new Splitter();
            //splitterRight = new Splitter();
            splitterDown = new Splitter();
            //splitterLeft.Dock = DockStyle.Left;
            //splitterRight.Dock = DockStyle.Right;
            splitterDown.Dock = DockStyle.Bottom;

            panel2.Parent = toolStripContainer1.ContentPanel;
            tabControl1.Parent = toolStripContainer1.ContentPanel;
            tabControl2.Parent = toolStripContainer1.ContentPanel;
            //splitterLeft.Parent = toolStripContainer1.ContentPanel;
            //splitterRight.Parent = toolStripContainer1.ContentPanel;
            splitterDown.Parent = toolStripContainer1.ContentPanel;

            //splitterLeft.BringToFront();
            //splitterRight.BringToFront();
            tabControl2.BringToFront();
            tabControl3.BringToFront();
            splitterDown.BringToFront();

            //splitterLeft.Cursor = Cursors.SizeWE;
            //splitterRight.Cursor = Cursors.SizeWE;
            splitterDown.Cursor = Cursors.SizeNS;

            //splitterLeft.MouseDown += SplitterLeft_MouseDown;
            //splitterLeft.SplitterMoving += SplitterLeft_SplitterMoving;
            //splitterLeft.SplitterMoved += SplitterLeft_SplitterMoved;
            //splitterLeft.MinSize = 240;
            //splitterLeft.MinExtra = 548;
            //splitterRight.SplitterMoving += SplitterRight_SplitterMoving;
            splitterDown.MouseDown += SplitterDown_MouseDown;
            splitterDown.SplitterMoving += SplitterDown_SplitterMoving;
            splitterDown.SplitterMoved += SplitterDown_SplitterMoved;
            splitterDown.MinSize = 100;
            splitterDown.MinExtra = 150;

            SelectedIndexChangedTimer.Interval = Constantes.TEMPORIZADOR_SELECCION_PROYECTO;
            SelectedIndexChangedTimer.Tick += SelectedIndexChangedTimer_Tick;
            ToolStripManager.Merge(toolStrip1, toolStrip2);
            toolStrip1.Dispose();
        }

        private void SelectedIndexChangedTimer_Tick(object sender, EventArgs e)
        {
            vista.ItemSeleccionadoLista(listView1, ref comboBox1, textBox8, dateTimePicker3, numericUpDown1, groupBox3, richTextBox1, richTextBox2, button5, button6, button7, button8, button9);
            SelectedIndexChangedTimer.Stop();
        }

        private void SplitterDown_MouseDown(object sender, MouseEventArgs e)
        {
            splitterDown.Invalidate();
        }

        private void SplitterDown_SplitterMoved(object sender, SplitterEventArgs e)
        {
            splitterDown.Invalidate();
        }

        private void SplitterDown_SplitterMoving(object sender, SplitterEventArgs e)
        {
            tabControl2.Height = Height - e.SplitY - Constantes.ANCHURA_MAXIMA_SPLITTER_TABCONTROL2;
            tabControl2.Refresh();
            tabControl3.Refresh();
            toolStripContainer1.ContentPanel.Refresh();
        }

        private void SplitterLeft_MouseDown(object sender, MouseEventArgs e)
        {
            //splitterLeft.Invalidate();
        }

        private void SplitterLeft_SplitterMoved(object sender, SplitterEventArgs e)
        {
            //splitterLeft.Invalidate();
        }

        private void SplitterLeft_SplitterMoving(object sender, SplitterEventArgs e)
        {
            panel2.Width = e.SplitX;
            panel2.Refresh();
            tabControl2.Refresh();
            tabControl3.Refresh();
            toolStripContainer1.ContentPanel.Refresh();

        }

        private void SplitterRight_SplitterMoving(object sender, SplitterEventArgs e)
        {
            tabControl1.Width = Width - e.SplitX - Constantes.ANCHURA_MAXIMA_SPLITTER_TABCONTROL1;
            tabControl1.Refresh();
            tabControl2.Refresh();
            tabControl3.Refresh();
            toolStripContainer1.ContentPanel.Refresh();

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            tabControl3.SelectedIndex = 2;
            listView3.Items.Clear();
            tabControl3.SelectedIndex = 0;

            //Thread proceso = new Thread(new ThreadStart(fichero.LeerArchivo));
            fichero.LeerArchivo();
            vista.ActualizarVistaTabla(ref listView1, TipoLista.Todos);
            vista.ActualizarVistaTabla(ref listView3, TipoLista.Finalizados);
            actualizarStatusLabelNumeroProyectos();
        }

        private void comboBox7_TextUpdate(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(comboBox7.Text))
            {
                groupBox6.Enabled = true;
                button10.Enabled = true;
            }
            else
            {
                groupBox6.Enabled = false;
                button10.Enabled = false;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                vista.ItemSeleccionadoLista(listView1, ref comboBox1, textBox8, dateTimePicker3, numericUpDown1, groupBox3, richTextBox1, richTextBox2, button5, button6, button7, button8, button9);
                if (listView1.SelectedIndices.Count == 1)
                {
                    copyToolStripButton1.Enabled = true;
                    button11.Enabled = true;
                }
                else
                {
                    copyToolStripButton1.Enabled = false;
                    button11.Enabled = false;
                }
            }
            else
            {
                copyToolStripButton1.Enabled = false;
                button11.Enabled = false;
            }
                SelectedIndexChangedTimer.Enabled = true;
                SelectedIndexChangedTimer.Interval = Constantes.TEMPORIZADOR_SELECCION_PROYECTO;
                SelectedIndexChangedTimer.Start();
                SelectedIndexChangedTimer.Tick += SelectedIndexChangedTimer_Tick;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedIndex = 0;
            vista.BotonAñadirProyecto(textBox6, textBox7, dateTimePicker1, textBox1, textBox2, textBox3, textBox4, textBox5, ref listView1, ref listView2);
            vista.ActualizarComboBoxModificar(ref comboBox1, listView1);
            ProyectoIndice proyectoAñadido = new ProyectoIndice(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Copiar(), listView1.SelectedIndices[0]);
            Operacion operacionAñadir = new Operacion(TOperacion.Crear);
            operacionAñadir.ListaProyectosDespues.Add(proyectoAñadido);
            deshacer.Pila.Push(operacionAñadir);
            deshacer.VaciarRehacer();
            rehacerToolStripMenuItem.Enabled = false;
            ForwardStripButton1.Enabled = false;
            deshacerToolStripMenuItem.Enabled = true;
            BackToolStripButton1.Enabled = true;
            toolStripStatusLabel1.Text = fichero.ArchivoActual + '*';
            if (MessageBox.Show("El Proyecto se ha añadido correctamente. ¿Desea asignar un nuevo alumno?", "Añadir Proyecto", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (vista.BotonAñadirAlumno(this, ref tabControl3, ref listView1, listView2, ref button7, ref button8, ref groupBox3))
                {
                    ProyectoIndice despuesAñadirAlumno = new ProyectoIndice(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Copiar(), listView1.SelectedIndices[0]);
                    Operacion operacionAñadirAlumno = new Operacion(TOperacion.AsignarAlumno, proyectoAñadido);
                    operacionAñadirAlumno.ListaProyectosDespues.Add(despuesAñadirAlumno);     
                    deshacer.Pila.Push(operacionAñadirAlumno);
                    deshacer.VaciarRehacer();
                    rehacerToolStripMenuItem.Enabled = false;
                    ForwardStripButton1.Enabled = false;
                    vista.ActualizarComboBoxModificar(ref comboBox1, listView1);
                    vista.ActualizarDatosRichTextBox(ref richTextBox1, listView1, TipoLista.Todos, TDatos.TFG);
                }
            }
            limpiarCamposAñadir();
        }

        private void tabControl3_Deselected(object sender, TabControlEventArgs e)
        {
            listView1.SelectedIndices.Clear();
            listView2.SelectedIndices.Clear();
            listView2.SelectedIndices.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Enabled)
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        textBox8.Visible = true;
                        textBox8.Text = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].getMTFG.Titulo;
                        numericUpDown1.Visible = false;
                        dateTimePicker3.Visible = false;
                        comboBox3.Visible = false;
                        break;

                    case 1:
                        textBox8.Visible = true;
                        textBox8.Text = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].getMTFG.Descripcion;
                        numericUpDown1.Visible = false;
                        dateTimePicker3.Visible = false;
                        comboBox3.Visible = false;
                        break;
                    case 2:
                        textBox8.Visible = false;
                        numericUpDown1.Visible = false;
                        dateTimePicker3.Visible = true;
                        dateTimePicker3.Value = DateTime.Parse(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].getMTFG.Fecha);
                        comboBox3.Visible = false;
                        break;
                    case 3:
                        textBox8.Visible = true;
                        textBox8.Text = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Alumno.Nombre;
                        numericUpDown1.Visible = false;
                        dateTimePicker3.Visible = false;
                        comboBox3.Visible = false;
                        break;
                    case 4:
                        textBox8.Visible = true;
                        textBox8.Text = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Alumno.PrimerApellido;
                        numericUpDown1.Visible = false;
                        dateTimePicker3.Visible = false;
                        comboBox3.Visible = false;
                        break;
                    case 5:
                        textBox8.Visible = true;
                        textBox8.Text = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Alumno.SegundoApellido;
                        numericUpDown1.Visible = false;
                        dateTimePicker3.Visible = false;
                        comboBox3.Visible = false;
                        break;
                    case 6:
                        textBox8.Visible = true;
                        textBox8.Text = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Alumno.Matricula;
                        numericUpDown1.Visible = false;
                        dateTimePicker3.Visible = false;
                        comboBox3.Visible = false;
                        break;
                    case 7:
                        textBox8.Visible = false;
                        numericUpDown1.Visible = false;
                        dateTimePicker3.Visible = true;
                        dateTimePicker3.Value = DateTime.Parse(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Alumno.FechaInicio);
                        comboBox3.Visible = false;
                        break;
                    case 8:
                        textBox8.Visible = false;
                        numericUpDown1.Visible = false;
                        dateTimePicker3.Visible = true;
                        dateTimePicker3.Value = DateTime.Parse(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Defensa);
                        comboBox3.Visible = false;
                        break;
                    case 9:
                        textBox8.Visible = false;
                        numericUpDown1.Visible = false;
                        dateTimePicker3.Visible = false;
                        comboBox3.Visible = true;
                        comboBox3.Text = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Convocatoria;
                        break;
                    case 10:
                        textBox8.Visible = false;
                        numericUpDown1.Visible = true;
                        numericUpDown1.Value = (decimal)MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Nota;
                        dateTimePicker3.Visible = false;
                        comboBox3.Visible = false;
                        break;
                    default:
                        textBox8.Visible = true;
                        numericUpDown1.Visible = false;
                        dateTimePicker3.Visible = false;
                        comboBox3.Visible = false;
                        break;
                }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int indice = 0;
            if(tabControl3.SelectedIndex == 0)
            {
                indice = listView1.SelectedIndices[0];
            } else if (tabControl3.SelectedIndex == 0)
            {
                indice = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[listView2.SelectedIndices[0]]);
            }
            ProyectoIndice proyectoAntesAñadir = new ProyectoIndice(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Copiar(), indice);
            if (vista.BotonAñadirAlumno(this, ref tabControl3, ref listView1, listView2, ref button7, ref button8, ref groupBox3))
            {
                Operacion op = new Operacion(TOperacion.AsignarAlumno, proyectoAntesAñadir);
                ProyectoIndice proyectoAñadidoAlumno = new ProyectoIndice(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Copiar(), listView1.SelectedIndices[0]);
                op.ListaProyectosDespues.Add(proyectoAñadidoAlumno);
                deshacer.Pila.Push(op);
                deshacer.VaciarRehacer();
                rehacerToolStripMenuItem.Enabled = false;
                ForwardStripButton1.Enabled = false;
                deshacerToolStripMenuItem.Enabled = true;
                BackToolStripButton1.Enabled = true;
                vista.ActualizarComboBoxModificar(ref comboBox1, listView1);
                vista.ActualizarDatosRichTextBox(ref richTextBox1, listView1, TipoLista.Todos, TDatos.TFG);
                toolStripStatusLabel1.Text = fichero.ArchivoActual + '*';
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            ProyectoIndice[] antesdeEliminar;
            if (tabControl3.SelectedIndex == 0)
            {
                antesdeEliminar = new ProyectoIndice[listView1.SelectedIndices.Count];
                for (int i = 0; i < listView1.SelectedIndices.Count; i++)
                {
                    antesdeEliminar[i] = new ProyectoIndice(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[i]].Copiar(), listView1.SelectedIndices[i]);
                }
            }
            else if (tabControl3.SelectedIndex == 1)
            {
                antesdeEliminar = new ProyectoIndice[listView2.SelectedIndices.Count];
                for (int i = 0; i < listView2.SelectedIndices.Count; i++)
                {
                    antesdeEliminar[i] = new ProyectoIndice(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[listView2.SelectedIndices[i]].Copiar(),
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[listView2.SelectedIndices[i]]));
                }
            }
            else
            {
                antesdeEliminar = new ProyectoIndice[0];
            }

            if (vista.BotonEliminarProyecto(ref listView1, ref listView2, ref listView3, tabControl3))
            {
                deshacer.Pila.Push(new Operacion(TOperacion.EliminarTFG, antesdeEliminar));
                deshacer.VaciarRehacer();
                rehacerToolStripMenuItem.Enabled = false;
                ForwardStripButton1.Enabled = false;
                deshacerToolStripMenuItem.Enabled = true;
                BackToolStripButton1.Enabled = true;
                toolStripStatusLabel1.Text = fichero.ArchivoActual + '*';
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            vista.ItemSeleccionadoLista2(listView2, ref richTextBox1, ref richTextBox2, button8, button9);
            if (listView2.SelectedIndices.Count > 0)
            {
                if (listView2.SelectedIndices.Count == 1)
                {
                    copyToolStripButton1.Enabled = true;
                    button11.Enabled = true;
                }
                else
                {
                    copyToolStripButton1.Enabled = false;
                    button11.Enabled = false;
                }
            }
            else
            {
                copyToolStripButton1.Enabled = false;
                button11.Enabled = false;
            }
        }

        private void tabControl3_Selected(object sender, TabControlEventArgs e)
        {
            /*
            button9.Enabled = false;
            button8.Enabled = false;
            if (e.TabPageIndex == 1)
            {
                vista.ActualizarVistaTabla(ref listView2, TipoLista.Sin_Asignar);
                comboBox1.Enabled = false;
                textBox8.Enabled = false;
                dateTimePicker3.Enabled = false;
                numericUpDown1.Enabled = false;
            }
            else if (e.TabPageIndex == 2)
            {
                vista.ActualizarVistaTabla(ref listView3, TipoLista.Finalizados);
                comboBox1.Enabled = false;
                textBox8.Enabled = false;
                dateTimePicker3.Enabled = false;
                numericUpDown1.Enabled = false;
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiarCamposAñadir();
        }

        private void limpiarCamposAñadir()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void datosToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (datosToolStripMenuItem.Checked == true)
                tabControl2.Visible = true;
            else tabControl2.Visible = false;
        }

        private void barraDeHerramientasToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (barraDeHerramientasToolStripMenuItem.Checked == true)
            {
                if (form5 != null && !form5.IsDisposed)
                    form5.Show();
                toolStrip2.Visible = true;
            }
            else
            {
                toolStrip2.Visible = false;
                if (form5 != null && !form5.IsDisposed)
                    form5.Hide();
            }
        }

        private void búsquedaToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (búsquedaToolStripMenuItem.Checked == true)
                panel2.Visible = true;
            else panel2.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el alumno del proyecto seleccionado?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                ProyectoIndice[] antesdeEliminarAlumno = new ProyectoIndice[listView1.SelectedIndices.Count];
                for (int i = 0; i < listView1.SelectedIndices.Count; i++)
                    antesdeEliminarAlumno[i] = new ProyectoIndice(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[i]].Copiar(), listView1.SelectedIndices[i]);
                Operacion op = new Operacion(TOperacion.EliminarAlumno, antesdeEliminarAlumno);
                vista.BotonEliminarAlumno(ref listView1, ref button7, ref button8, ref groupBox3);
                for (int i = 0; i < listView1.SelectedIndices.Count; i++)
                    op.ListaProyectosDespues.Add(new ProyectoIndice(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[i]].Copiar(), listView1.SelectedIndices[i]));
                deshacer.Pila.Push(op);
                deshacer.VaciarRehacer();
                rehacerToolStripMenuItem.Enabled = false;
                ForwardStripButton1.Enabled = false;
                deshacerToolStripMenuItem.Enabled = true;
                BackToolStripButton1.Enabled = true;
                vista.ActualizarComboBoxModificar(ref comboBox1, listView1);
                vista.ActualizarDatosRichTextBox(ref richTextBox1, listView1, TipoLista.Todos,TDatos.TFG);
                toolStripStatusLabel1.Text = fichero.ArchivoActual + '*';
            }
        }

        private void Añadir_TextBoxChanged(object sender, EventArgs e)
        {
            if (!vista.EstanVacios(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7))
                button2.Enabled = true;
            else button2.Enabled = false;

            if (!string.IsNullOrEmpty(textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text + textBox5.Text + textBox6.Text + textBox7.Text))
                button1.Enabled = true;
            else button1.Enabled = false;
        }

        private void saveToolStripButton1_Click(object sender, EventArgs e)
        {
            if (vista.NuevaLista)
            {
                guardarcomoToolStripMenuItem_Click(sender, e);
            }
            else
            {
                Guardar();
                timer1.Enabled = true;
                timer1.Interval = Constantes.TEMPORIZADOR_MENSAJE_GUARDADO;
                timer1.Start();
                timer1.Tick += Timer_Tick;

            }
        }

        private void Guardar()
        {
            fichero.CerrarLectura();
            fichero.AbrirEscritura(fichero.ArchivoActual);
            //fichero.EscribirArchivo();

            fichero.ExportarArchivo();

            toolStripStatusLabel1.Text = fichero.ArchivoActual;
            toolStripStatusLabel1.Text += " guardado correctamente.";
            fichero.CerrarEscritura();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = fichero.ArchivoActual;
            timer1.Stop();
        }

        private void newToolStripButton1_Click(object sender, EventArgs e)
        {
            if (vista.Cambios)
            {
                DialogResult result = MessageBox.Show("¿Desea guardar los datos en " + '"' + Path.GetFileName(fichero.ArchivoActual) + '"' + " antes de continuar?", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Cancel) return;
                else if (result == DialogResult.Yes)
                {
                    saveToolStripButton1_Click(sender, e);
                    //return;
                }
            }
            tabControl3.SelectedIndex = 0;
            vista.CrearNuevaLista();
            vista.ActualizarVistaTabla(ref listView1, TipoLista.Todos);
            richTextBox1.Clear();
            richTextBox2.Clear();
            toolStripStatusLabel1.Text = "Nueva lista de proyectos";
            actualizarStatusLabelNumeroProyectos();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vista.Cambios)
            {
                DialogResult result = MessageBox.Show("¿Desea guardar los datos en " + '"' + fichero.ArchivoActual + '"' + " antes de salir?", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Cancel) e.Cancel = true;
                else if (result == DialogResult.Yes)
                {
                    if (vista.NuevaLista)
                    {
                        if (GuardarComo() == DialogResult.Cancel) e.Cancel = true;
                    }
                    else Guardar();
                    fichero.CerrarFichero();
                }
                else fichero.CerrarFichero();
            }
            else fichero.CerrarFichero();
        }

        private void openToolStripButton1_Click(object sender, EventArgs e)
        {
            string nombreFichero = fichero.ArchivoActual;
            if (vista.Cambios)
            {
                DialogResult result = MessageBox.Show("¿Desea guardar los datos en " + '"' + Path.GetFileName(nombreFichero) + '"' + " antes de continuar?", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Cancel) return;
                else if (result == DialogResult.Yes)
                {
                    saveToolStripButton1_Click(sender, e);
                    //return;
                }
            }

            OpenFileDialog cargar = new OpenFileDialog();
            cargar.Filter = "Lista de Proyectos (*.txt)|*.txt";
            cargar.FilterIndex = 1;
            if (cargar.ShowDialog() == DialogResult.OK)
            {
                
                try
                {
                    listView1.SelectedIndices.Clear();
                    listView2.SelectedIndices.Clear();
                    listView3.SelectedIndices.Clear();
                    fichero.CerrarEscritura();
                    fichero.AbrirLectura(cargar.FileName);

                    //this.fichero.LeerArchivo();
                    fichero.ImportarArchivo();
                    vista.ActualizarVistaTabla(ref listView1, TipoLista.Todos);
                    vista.ActualizarVistaTabla(ref listView2, TipoLista.Sin_Asignar);
                    vista.ActualizarVistaTabla(ref listView3, TipoLista.Finalizados);
                    tabControl3.SelectedIndex = 0;
                    if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Count > 0)
                    {
                        listView1.EnsureVisible(0);
                        vista.RefrescarItemsVistaTabla(ref listView1, TipoLista.Todos);
                    }
                    if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados.Count > 0)
                        vista.RefrescarItemsVistaTabla(ref listView2, TipoLista.Sin_Asignar);
                    if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados.Count > 0)
                        vista.RefrescarItemsVistaTabla(ref listView3, TipoLista.Finalizados);
                    toolStripStatusLabel1.Text = fichero.ArchivoActual;
                    toolStripStatusLabel2.Text = listView1.Items.Count + " proyectos";
                    toolStripStatusLabel1.Text = fichero.ArchivoActual;
                    vista.GuardarLista();
                    deshacer.VaciarPilas();
                    BackToolStripButton1.Enabled = false;
                    ForwardStripButton1.Enabled = false;
                    deshacerToolStripMenuItem.Enabled = false;
                    rehacerToolStripMenuItem.Enabled = false;
                }
                catch (Exception ex)
                {
                    fichero.ArchivoActual = nombreFichero;
                    fichero.DeshacerLectura();
                    vista.ActualizarVistaTabla(ref listView1, TipoLista.Todos);
                    vista.ActualizarVistaTabla(ref listView2, TipoLista.Sin_Asignar);
                    vista.ActualizarVistaTabla(ref listView3, TipoLista.Finalizados);
                    actualizarStatusLabelNumeroProyectos();
                    MessageBox.Show("El archivo no tiene el formato especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    this.fichero.CerrarLectura();
                }
            }
        }

        private void guardarcomoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarComo();
        }

        private DialogResult GuardarComo()
        {
            SaveFileDialog guardarComo = new SaveFileDialog();
            guardarComo.Filter = "Lista de Proyectos (*.txt)|*.txt";
            guardarComo.FilterIndex = 1;
            DialogResult result = guardarComo.ShowDialog();
            if (result == DialogResult.OK)
            {
                //fichero.CerrarLectura();
                fichero.AbrirEscritura(guardarComo.FileName);
                toolStripStatusLabel1.Text = guardarComo.FileName;
                vista.GuardarLista();
                //fichero.EscribirArchivo();

                fichero.ExportarArchivo();

                fichero.CerrarEscritura();
            }
            return result;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            toolStrip2.Size = new Size(Width, Constantes.ALTURA_TOOLSTRIP);
        }

        private void button7_EnabledChanged(object sender, EventArgs e)
        {
            if (button7.Enabled)
            {
                removeStripButton1.Enabled = true;
                eliminarAlumnoToolStripMenuItem1.Enabled = true;
            }
            else
            {
                removeStripButton1.Enabled = false;
                eliminarAlumnoToolStripMenuItem1.Enabled = false;
            }
        }

        private void button8_EnabledChanged(object sender, EventArgs e)
        {
            if (button8.Enabled)
            {
                addStripButton1.Enabled = true;
                asignarAlumnoToolStripMenuItem.Enabled = true;
            }
            else
            {
                addStripButton1.Enabled = false;
                asignarAlumnoToolStripMenuItem.Enabled = false;
            }
        }

        private void button9_EnabledChanged(object sender, EventArgs e)
        {
            if (button9.Enabled)
            {
                deleteStripButton1.Enabled = true;
                eliminarTFGToolStripMenuItem.Enabled = true;
            }
            else
            {
                deleteStripButton1.Enabled = false;
                eliminarTFGToolStripMenuItem.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProyectoIndice antesdeModificar = new ProyectoIndice(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Copiar(), listView1.SelectedIndices[0]);
            int indiceModificar = comboBox1.SelectedIndex;
            vista.BotonModificar(comboBox1, textBox8, comboBox3, dateTimePicker3, numericUpDown1, ref listView1);

            if (textBox8.Visible)
                textBox8.Clear();
            else if (comboBox3.Visible)
                comboBox3.ResetText();
            else if (numericUpDown1.Visible)
                numericUpDown1.Value = 0;
            else dateTimePicker3.Value = DateTime.Today;
            comboBox1.SelectedItem = null;
            Operacion op = new Operacion(TOperacion.Modificar, antesdeModificar);
            ProyectoIndice despuesdeModificar = new ProyectoIndice(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Copiar(), listView1.SelectedIndices[0]);
            op.ListaProyectosDespues.Add(despuesdeModificar);
            deshacer.Pila.Push(op);
            deshacer.VaciarRehacer();
            rehacerToolStripMenuItem.Enabled = false;
            ForwardStripButton1.Enabled = false;
            deshacerToolStripMenuItem.Enabled = true;
            BackToolStripButton1.Enabled = true;
            vista.ActualizarDatosRichTextBox(ref richTextBox1, listView1, TipoLista.Todos, TDatos.TFG);
            toolStripStatusLabel1.Text = fichero.ArchivoActual + '*';
        }

        private void textBox8_comboBox3_TextChanged(object sender, EventArgs e)
        {
            string texto = "";
            if (textBox8.Visible) texto = textBox8.Text;
            else if (comboBox3.Visible) texto = comboBox3.Text;

            if (string.IsNullOrWhiteSpace(texto + comboBox1.Text))
            {
                button5.Enabled = false;
            }
            else button5.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            textBox8.Clear();
            comboBox1.SelectedItem = null;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter) textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) textBox1.Focus();
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter) textBox3.Focus();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) textBox2.Focus();
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter) textBox4.Focus();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) textBox3.Focus();
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter) textBox5.Focus();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) textBox4.Focus();
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter) textBox6.Focus();
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) textBox5.Focus();
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter) dateTimePicker1.Focus();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back) textBox6.Focus();
            else if (e.KeyCode == Keys.Enter) textBox7.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            buscador.BuscarProyecto(comboBox7.Text.Trim(), (TCampos)comboBox10.SelectedIndex, comboBox9.SelectedIndex, comboBox4.SelectedIndex, comboBox5.SelectedIndex, comboBox8.SelectedIndex, dateTimePicker4, dateTimePicker5, dateTimePicker6, numericUpDown4, fichero);
            if (!comboBox7.Items.Contains(comboBox7.Text.Trim()))
                comboBox7.Items.Add(comboBox7.Text.Trim());
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.SelectedIndex > 0) dateTimePicker4.Enabled = true;
            else
            {
                dateTimePicker4.Value = DateTime.Today;
                dateTimePicker4.Enabled = false;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex > 0) dateTimePicker5.Enabled = true;
            else
            {
                dateTimePicker5.Value = DateTime.Today;
                dateTimePicker5.Enabled = false;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex > 0) dateTimePicker6.Enabled = true;
            else
            {
                dateTimePicker6.Value = DateTime.Today;
                dateTimePicker6.Enabled = false;
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex > 0) numericUpDown4.Enabled = true;
            else
            {
                numericUpDown4.Value = 0.00m;
                numericUpDown4.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Operacion op = new Operacion(TOperacion.FinalizarTFG, new ProyectoIndice(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Copiar(), listView1.SelectedIndices[0]));
            vista.BotonFinalizar(dateTimePicker2, comboBox2, numericUpDown2, ref listView1);
            ProyectoIndice proyectoFinalizado = new ProyectoIndice(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Copiar(), listView1.SelectedIndices[0]);
            op.ListaProyectosDespues.Add(proyectoFinalizado);
            deshacer.Pila.Push(op);
            deshacer.VaciarRehacer();
            rehacerToolStripMenuItem.Enabled = false;
            ForwardStripButton1.Enabled = false;
            deshacerToolStripMenuItem.Enabled = true;
            BackToolStripButton1.Enabled = true;
            vista.ActualizarComboBoxModificar(ref comboBox1, listView1);
            groupBox3.Enabled = false;
            button7.Enabled = false;
            
            vista.ActualizarDatosRichTextBox(ref richTextBox1, listView1, TipoLista.Todos, TDatos.TFG);
            toolStripStatusLabel1.Text = fichero.ArchivoActual + '*';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetearDatosFinalizar(ref comboBox2, ref numericUpDown2, ref dateTimePicker2);
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                button4.Enabled = false;
            }
            else button4.Enabled = true;
        }

        private void groupBox3_EnabledChanged(object sender, EventArgs e)
        {
            if (!groupBox3.Enabled)
            {
                ResetearDatosFinalizar(ref comboBox2, ref numericUpDown2, ref dateTimePicker2);
            }
        }

        private void ResetearDatosFinalizar(ref ComboBox comboBox2, ref NumericUpDown numericUpDown2, ref DateTimePicker dateTimePicker2)
        {
            comboBox2.ResetText();
            numericUpDown2.Value = 0;
            dateTimePicker2.Value = DateTime.Today;
        }

        private void comboBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button10.PerformClick();
            }
        }

        private void toolStrip2_EndDrag_1(object sender, EventArgs e)
        {
            Point puntero = toolStripContainer1.TopToolStripPanel.PointToClient(MousePosition);
            if (form5 == null || !form5.Visible)
            {
                if (!(puntero.X >= Constantes.MARGEN_EXTERIOR_IZQUIERDO_ARRASTRAR && puntero.X <= toolStripContainer1.TopToolStripPanel.Width && puntero.Y >= Constantes.MARGEN_EXTERIOR_BAJO_ARRASTRAR && puntero.Y <= toolStripContainer1.TopToolStripPanel.Height))
                {
                    form5 = new Form5(this);
                    form5.Size = toolStrip2.Size;
                    form5.Width = form5.Width + Constantes.MARGEN_ANCHURA_TOOLSTRIP_FLOTANTE;
                    ToolStripContainer aux = (ToolStripContainer)form5.Controls[0].Controls[0];
                    aux.TopToolStripPanel.Controls.Add(toolStrip2);
                    form5.Location = MousePosition;
                    form5.Show(this);
                    toolStripContainer1.TopToolStripPanel.Controls.Clear();
                }
            }
            else
            {

                if (puntero.X >= Constantes.MARGEN_EXTERIOR_IZQUIERDO_ARRASTRAR && puntero.X <= toolStripContainer1.TopToolStripPanel.Width && puntero.Y >= Constantes.MARGEN_EXTERIOR_BAJO_ARRASTRAR && puntero.Y <= toolStripContainer1.TopToolStripPanel.Height)
                {
                    List<ToolStrip> listaToolStrip = new List<ToolStrip>();
                    ToolStripContainer aux = (ToolStripContainer)form5.Controls[0].Controls[0];
                    ToolStrip toolStripAñadido = aux.TopToolStripPanel.Controls[0] as ToolStrip;
                    toolStripContainer1.TopToolStripPanel.Controls.Add(toolStripAñadido);
                    foreach (ToolStrip toolStrip in toolStripContainer1.TopToolStripPanel.Controls)
                    {
                        if (toolStrip != toolStripAñadido)
                            toolStripContainer1.TopToolStripPanel.Controls.Remove(toolStrip);
                    }
                    toolStripAñadido.Location = new Point(puntero.X, toolStripAñadido.Location.Y);
                    form5.Close();
                }
                else
                {
                    toolStripContainer1.TopToolStripPanel.Controls.Clear();
                    form5.Location = MousePosition;
                    form5.Refresh();
                }
            }
        }

        public void AñadirElementoToolStripContainer(ToolStrip toolStrip)
        {
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip);
        }

        private void toolStrip2_BeginDrag(object sender, EventArgs e)
        {
            Point puntero = toolStripContainer1.TopToolStripPanel.PointToClient(MousePosition);
            if (!(puntero.X >= Constantes.MARGEN_EXTERIOR_IZQUIERDO_ARRASTRAR && puntero.X <= toolStripContainer1.TopToolStripPanel.Width && puntero.Y >= Constantes.MARGEN_EXTERIOR_BAJO_COMENZAR_ARRASTRAR && puntero.Y <= toolStripContainer1.TopToolStripPanel.Height))
            {
                ToolStrip aux = new ToolStrip();
                aux.RenderMode = ToolStripRenderMode.System;
                aux.BackColor = SystemColors.Window;
                aux.GripStyle = ToolStripGripStyle.Hidden;
                aux.Renderer = new ToolStripSystemRendererFix();
                toolStripContainer1.TopToolStripPanel.Controls.Add(aux);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int opcion = 0;
            NumericUpDown aux = new NumericUpDown();
            aux.DecimalPlaces = Constantes.DECIMALES_DESPUES_DE_COMA;
            aux.Value = 0;
            if (aprobadosToolStripMenuItem.Checked)
            {
                opcion = 2;
                aux.Value = Constantes.LIMITE_NOTA_APROBADA;
            }
            else if (suspensosToolStripMenuItem.Checked)
            {
                opcion = 3;
                aux.Value = Constantes.LIMITE_NOTA_APROBADA;
            }

            buscador.BuscarProyecto(toolStripComboBox2.Text.Trim(), (TCampos)toolStripComboBox1.SelectedIndex, 0, 0, 0, opcion, new DateTimePicker(), new DateTimePicker(), new DateTimePicker(), aux, fichero);
            if (!toolStripComboBox2.Items.Contains(toolStripComboBox2.Text.Trim()))
                toolStripComboBox2.Items.Add(toolStripComboBox2.Text.Trim());
        }

        private void aprobadosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (aprobadosToolStripMenuItem.Checked)
                aprobadosToolStripMenuItem.Checked = false;
            else
            {
                aprobadosToolStripMenuItem.Checked = true;
                suspensosToolStripMenuItem.Checked = false;
            }
        }

        private void suspensosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (suspensosToolStripMenuItem.Checked)
                suspensosToolStripMenuItem.Checked = false;
            else
            {
                suspensosToolStripMenuItem.Checked = true;
                aprobadosToolStripMenuItem.Checked = false;
            }
        }

        private void deshacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedIndex = 0;
            rehacerToolStripMenuItem.Enabled = true;
            ForwardStripButton1.Enabled = true;
            TOperacion operacion;
            int[] indices = deshacer.Atras(out operacion);
            if (operacion == TOperacion.Crear || operacion == TOperacion.EliminarTFG)
            {
                vista.ActualizarVistaTabla(ref listView1, TipoLista.Todos);
                vista.ActualizarVistaTabla(ref listView2, TipoLista.Sin_Asignar);
                vista.ActualizarVistaTabla(ref listView3, TipoLista.Finalizados);
                actualizarStatusLabelNumeroProyectos();
                if (tabControl3.SelectedIndex == 0)
                    toolStripStatusLabel2.Text = listView1.Items.Count + " proyectos";
                else if (tabControl3.SelectedIndex == 1)
                    toolStripStatusLabel2.Text = listView2.Items.Count + " proyectos";
                else if (tabControl3.SelectedIndex == 2)
                    toolStripStatusLabel2.Text = listView3.Items.Count + " proyectos";

            } else if(operacion == TOperacion.EliminarAlumno || operacion == TOperacion.AsignarAlumno)
            {
                foreach (int indice in indices)
                {
                    listView1.RedrawItems(indice, indice, false);
                }
                vista.ActualizarVistaTabla(ref listView2, TipoLista.Sin_Asignar);
            }
            else
            {
                listView1.RedrawItems(indices[0], indices[indices.Length - 1], false);
            }
            listView1.SelectedIndices.Clear();
            for (int i = 0; i < indices.Length; i++)
                listView1.Items[indices[i]].Selected = true;
            if (deshacer.PilaDeshacerVacia())
            {
                deshacerToolStripMenuItem.Enabled = false;
                BackToolStripButton1.Enabled = false;
            }
            if (listView1.SelectedIndices.Count != 1)
            {
                if (listView1.SelectedIndices.Count == 0)
                {
                    comboBox1.Enabled = false;
                    textBox8.Enabled = false;
                    dateTimePicker3.Enabled = false;
                    numericUpDown1.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button8.Enabled = false;
                    button9.Enabled = false;
                    groupBox3.Enabled = false;
                }
                richTextBox2.Clear();
                richTextBox1.Clear();
            }

            else if (listView1.SelectedIndices.Count == 1)
            {
                if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Asignado)
                {
                    button7.Enabled = true;
                    button8.Enabled = false;
                    button9.Enabled = true;
                    if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].getMTFG.Finalizado)
                    {
                        groupBox3.Enabled = false;
                    }
                    else groupBox3.Enabled = true;
                } else groupBox3.Enabled = false;
            }
            vista.ActualizarDatosRichTextBox(ref richTextBox1, listView1, TipoLista.Todos, TDatos.TFG);
            vista.ActualizarDatosRichTextBox(ref richTextBox2, listView1, TipoLista.Todos, TDatos.Profesor);
            toolStripStatusLabel1.Text = fichero.ArchivoActual + '*';
        }

        private void rehacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedIndex = 0;
            deshacerToolStripMenuItem.Enabled = true;
            BackToolStripButton1.Enabled = true;
            TOperacion operacion;
            int[] indices = deshacer.Adelante(out operacion);
            if (operacion == TOperacion.Crear || operacion == TOperacion.EliminarTFG)
            {
                vista.ActualizarVistaTabla(ref listView1, TipoLista.Todos);
                vista.ActualizarVistaTabla(ref listView2, TipoLista.Sin_Asignar);
                vista.ActualizarVistaTabla(ref listView3, TipoLista.Finalizados);
                actualizarStatusLabelNumeroProyectos();
            }
            else if (operacion == TOperacion.EliminarAlumno || operacion == TOperacion.AsignarAlumno)
            {
                foreach (int indice in indices)
                {
                    listView1.RedrawItems(indice, indice, false);
                }
                vista.ActualizarVistaTabla(ref listView2, TipoLista.Sin_Asignar);
                actualizarStatusLabelNumeroProyectos();
            }
            else
            {
                listView1.RedrawItems(indices[0], indices[indices.Length - 1], false);
            }
            listView1.SelectedIndices.Clear();
            for (int i = 0; i < indices.Length; i++)
                listView1.Items[indices[i]].Selected = true;
            if (deshacer.PilaRehacerVacia())
            {
                rehacerToolStripMenuItem.Enabled = false;
                ForwardStripButton1.Enabled = false;
            }
            if (listView1.SelectedIndices.Count != 1)
            {
                if (listView1.SelectedIndices.Count == 0)
                {
                    comboBox1.Enabled = false;
                    textBox8.Enabled = false;
                    dateTimePicker3.Enabled = false;
                    numericUpDown1.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button8.Enabled = false;
                    button9.Enabled = false;
                    groupBox3.Enabled = false;
                }
                richTextBox2.Clear();
                richTextBox1.Clear();
            }

            else if (listView1.SelectedIndices.Count == 1)
            {
                if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Asignado)
                {
                    button7.Enabled = true;
                    button8.Enabled = false;
                    button9.Enabled = true;
                    if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].getMTFG.Finalizado)
                    {
                        groupBox3.Enabled = false;
                    }
                    else groupBox3.Enabled = true;
                } else groupBox3.Enabled = true;
            }
            vista.ActualizarDatosRichTextBox(ref richTextBox1, listView1, TipoLista.Todos, TDatos.TFG);
            vista.ActualizarDatosRichTextBox(ref richTextBox2, listView1, TipoLista.Todos, TDatos.Profesor);
            toolStripStatusLabel1.Text = fichero.ArchivoActual + '*';
        }

        private void temaClásicoToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (temaClásicoToolStripMenuItem.Checked)
            {
                Application.VisualStyleState = VisualStyleState.NonClientAreaEnabled;
            }
            else
            {
                Application.VisualStyleState = VisualStyleState.ClientAndNonClientAreasEnabled;
            }
        }

        private void seleccionartodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedIndex == 0)
            {
                listView1.SelectAllItems();
            } else if (tabControl3.SelectedIndex == 1)
            {
                listView2.SelectAllItems();
            } else if (tabControl3.SelectedIndex == 2)
            {
                listView3.SelectAllItems();
            }
        }

        private void acercadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.ShowDialog(this);
        }

        private void pantallaCompletaToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (pantallaCompletaToolStripMenuItem.Checked)
            {
                if (WindowState == FormWindowState.Maximized)
                    WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
            }
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            ListViewVisualStyles.DibujarItemListView(sender, e);
        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            ListViewVisualStyles.DibujarCabeceras(sender, e);
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            ListViewVisualStyles.DibujarSubItemListView(sender, e);
        }

        private void listView2_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            ListViewVisualStyles.DibujarCabeceras(sender, e);
        }

        private void listView2_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            ListViewVisualStyles.DibujarItemListView(sender, e);
        }

        private void listView2_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            ListViewVisualStyles.DibujarSubItemListView(sender, e);
        }

        private void listView3_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            ListViewVisualStyles.DibujarCabeceras(sender, e);
        }

        private void listView3_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            ListViewVisualStyles.DibujarItemListView(sender, e);
        }

        private void listView3_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            ListViewVisualStyles.DibujarSubItemListView(sender, e);
        }

        private void importarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vista.Cambios)
            {
                DialogResult result = MessageBox.Show("¿Desea guardar los datos en " + '"' + fichero.ArchivoActual + '"' + " antes de continuar?", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Cancel) return;
                else if (result == DialogResult.Yes)
                {
                    saveToolStripButton1_Click(sender, e);
                }
            }
            
            OpenFileDialog cargar = new OpenFileDialog();
            cargar.Filter = "Documentos de texto (*.txt)|*.txt";//|Todos los archivos (*.*)|*.*";
            cargar.FilterIndex = 1;
            if (cargar.ShowDialog() == DialogResult.OK)
            {
                string fichero = this.fichero.ArchivoActual;
                try
                {
                    //this.fichero.CerrarEscritura();
                    this.fichero.AbrirLectura(cargar.FileName);
                    this.fichero.ImportarArchivo();
                    listView1.SelectedIndices.Clear();
                    listView2.SelectedIndices.Clear();
                    listView3.SelectedIndices.Clear();
                    vista.ActualizarVistaTabla(ref listView1, TipoLista.Todos);
                    vista.ActualizarVistaTabla(ref listView2, TipoLista.Sin_Asignar);
                    vista.ActualizarVistaTabla(ref listView3, TipoLista.Finalizados);
                    actualizarStatusLabelNumeroProyectos();

                    if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Count > 0)
                        vista.RefrescarItemsVistaTabla(ref listView1, TipoLista.Todos);
                    if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados.Count > 0)
                        vista.RefrescarItemsVistaTabla(ref listView2, TipoLista.Sin_Asignar);
                    if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados.Count > 0)
                        vista.RefrescarItemsVistaTabla(ref listView3, TipoLista.Finalizados);
                    toolStripStatusLabel1.Text = this.fichero.ArchivoActual;
                    //this.fichero.CerrarLectura();
                    toolStripStatusLabel1.Text = this.fichero.ArchivoActual;
                    vista.GuardarLista();
                    deshacer.VaciarPilas();
                    BackToolStripButton1.Enabled = false;
                    ForwardStripButton1.Enabled = false;
                    deshacerToolStripMenuItem.Enabled = false;
                    rehacerToolStripMenuItem.Enabled = false;
                }
                catch (Exception ex)
                {
                    vista.ActualizarVistaTabla(ref listView1, TipoLista.Todos);
                    vista.ActualizarVistaTabla(ref listView2, TipoLista.Sin_Asignar);
                    vista.ActualizarVistaTabla(ref listView3, TipoLista.Finalizados);
                    actualizarStatusLabelNumeroProyectos();
                    MessageBox.Show("El archivo no tiene el formato especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    Console.WriteLine(ex.Message);
                    this.fichero.ArchivoActual = fichero;
                } finally
                {
                    this.fichero.CerrarLectura();
                }
            }
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exportar();
        }

        private DialogResult Exportar()
        {
            SaveFileDialog guardarComo = new SaveFileDialog();
            guardarComo.Filter = "Documentos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            guardarComo.FilterIndex = 1;
            DialogResult result = guardarComo.ShowDialog();
            if (result == DialogResult.OK)
            {
                //fichero.CerrarLectura();
                fichero.AbrirEscritura(guardarComo.FileName);
                vista.GuardarLista();
                fichero.ExportarArchivo();
                fichero.CerrarEscritura();
            }
            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Constantes.SendMessage(listView1.Handle, Constantes.LVM_SETTEXTBKCOLOR, IntPtr.Zero, unchecked((IntPtr)0xFFFFFF));
            Constantes.SendMessage(listView2.Handle, Constantes.LVM_SETTEXTBKCOLOR, IntPtr.Zero, unchecked((IntPtr)0xFFFFFF));
            Constantes.SendMessage(listView3.Handle, Constantes.LVM_SETTEXTBKCOLOR, IntPtr.Zero, unchecked((IntPtr)0xFFFFFF));
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            try
            {
                e.Item = ListViewItemUtilidades.ConvertirProyectoEnItemLista(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[e.ItemIndex]);
            } catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void listView2_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = ListViewItemUtilidades.ConvertirProyectoEnItemLista(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[e.ItemIndex]);
        }

        private void listView3_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = ListViewItemUtilidades.ConvertirProyectoEnItemLista(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados[e.ItemIndex]);
        }

        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            button9.Enabled = false;
            button8.Enabled = false;
            actualizarStatusLabelNumeroProyectos();
            if (tabControl3.SelectedIndex == 1)
            {
                vista.ActualizarVistaTabla(ref listView2, TipoLista.Sin_Asignar);
                comboBox1.Enabled = false;
                textBox8.Enabled = false;
                dateTimePicker3.Enabled = false;
                numericUpDown1.Enabled = false;
            }
            else if (tabControl3.SelectedIndex == 2)
            {
                vista.ActualizarVistaTabla(ref listView3, TipoLista.Finalizados);
                comboBox1.Enabled = false;
                textBox8.Enabled = false;
                dateTimePicker3.Enabled = false;
                numericUpDown1.Enabled = false;
            }
        }

        private void tabControl3_Selecting(object sender, TabControlCancelEventArgs e)
        {
            button9.Enabled = false;
            button8.Enabled = false;
            toolStripMenuItem19.Visible = false;
            actualizarStatusLabelNumeroProyectos();
            if (e.TabPageIndex == 1)
            {
                vista.ActualizarVistaTabla(ref listView2, TipoLista.Sin_Asignar);
                comboBox1.Enabled = false;
                textBox8.Enabled = false;
                dateTimePicker3.Enabled = false;
                numericUpDown1.Enabled = false;
                toolStripMenuItem19.Visible = true;
            }
            else if (e.TabPageIndex == 2)
            {
                vista.ActualizarVistaTabla(ref listView3, TipoLista.Finalizados);
                comboBox1.Enabled = false;
                textBox8.Enabled = false;
                dateTimePicker3.Enabled = false;
                numericUpDown1.Enabled = false;
                toolStripMenuItem19.Visible = true;
            }
        }

        private void aparienciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Preferencias().ShowDialog(this);
            Refresh();
        }

        private void helpToolStripButton1_Click(object sender, EventArgs e)
        {
            new Form9(0).ShowDialog(this);
        }

        private void comboBox7_TextChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text.ToUpperInvariant() == "WWSSADADBA")
                new Form7().ShowDialog(this); 
        }

        public void SeleccionarItemLista(int indice)
        {
            tabControl3.SelectedIndex = 0;
            listView1.SelectedIndices.Clear();
            listView1.SelectedIndices.Add(indice);
            listView1.EnsureVisible(indice);
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedIndices.Count > 0)
            {
                if (listView3.SelectedIndices.Count == 1)
                {
                    copyToolStripButton1.Enabled = true;
                    vista.ActualizarDatosRichTextBox(ref richTextBox1, listView3, TipoLista.Finalizados, TDatos.TFG);
                    vista.ActualizarDatosRichTextBox(ref richTextBox2, listView3, TipoLista.Finalizados, TDatos.Profesor);
                }
                else copyToolStripButton1.Enabled = false;
            }
            else
            {
                copyToolStripButton1.Enabled = false; 
            }
        }

        private void copyToolStripButton1_Click(object sender, EventArgs e)
        {
            string textoCopiar = "";
            if (tabControl3.SelectedIndex == 0)
            {
                textoCopiar += MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].getMTFG.Titulo + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].getMTFG.Descripcion
                    + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].getMTFG.Fecha;
                if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Asignado)
                {
                    textoCopiar += ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Alumno.Nombre
                    + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Alumno.PrimerApellido + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Alumno.SegundoApellido
                    + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Alumno.Matricula + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Alumno.FechaInicio;
                    if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].getMTFG.Finalizado)
                    {
                        textoCopiar += ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Defensa + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Convocatoria
                            + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Nota;
                    }
                }
            }
            else if (tabControl3.SelectedIndex == 1)
            {
                textoCopiar += MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[listView2.SelectedIndices[0]].getMTFG.Titulo + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[listView2.SelectedIndices[0]].getMTFG.Descripcion;
            }
            else if (tabControl3.SelectedIndex == 2)
            {
                textoCopiar += MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados[listView3.SelectedIndices[0]].getMTFG.Titulo + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados[listView3.SelectedIndices[0]].getMTFG.Descripcion
                    + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados[listView3.SelectedIndices[0]].getMTFG.Fecha + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados[listView3.SelectedIndices[0]].Alumno.Nombre
                    + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados[listView3.SelectedIndices[0]].Alumno.PrimerApellido + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados[listView3.SelectedIndices[0]].Alumno.SegundoApellido
                    + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados[listView3.SelectedIndices[0]].Alumno.Matricula + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados[listView3.SelectedIndices[0]].Alumno.FechaInicio
                    + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados[listView3.SelectedIndices[0]].getMTFG.getMFinalizado.Defensa + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados[listView3.SelectedIndices[0]].getMTFG.getMFinalizado.Convocatoria
                    + ";" + MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados[listView3.SelectedIndices[0]].getMTFG.getMFinalizado.Nota;
            }

            Clipboard.SetText(textoCopiar);
        }

        private void pasteToolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (comboBox7.Focused)
                comboBox7.SelectedText = Clipboard.GetText();
            else if (textBox1.Focused)
                textBox1.SelectedText = Clipboard.GetText();
            else if (textBox2.Focused)
                textBox2.SelectedText = Clipboard.GetText();
            else if (textBox3.Focused)
                textBox3.SelectedText = Clipboard.GetText();
            else if (textBox4.Focused)
                textBox4.SelectedText = Clipboard.GetText();
            else if (textBox5.Focused)
                textBox5.SelectedText = Clipboard.GetText();
            else if (textBox6.Focused)
                textBox6.SelectedText = Clipboard.GetText();
            else if (textBox7.Focused)
                textBox7.SelectedText = Clipboard.GetText();
            else if (textBox8.Focused)
                textBox8.SelectedText = Clipboard.GetText();
            else if (comboBox2.Focused)
                comboBox2.SelectedText = Clipboard.GetText();
            else if (comboBox3.Focused)
                comboBox3.SelectedText = Clipboard.GetText();
        }

        private void CampoEditable_Enter(object sender, EventArgs e)
        {
            pegarToolStripMenuItem.Enabled = true;
            pasteToolStripButton1.Enabled = true;
        }

        private void CampoEditable_Leave(object sender, EventArgs e)
        {
            pegarToolStripMenuItem.Enabled = false;
            pasteToolStripButton1.Enabled = false;
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (sender.GetType() == typeof(VistaLista))
                {
                    copiar = new Copiar(toolStripMenuItem7);
                    if ((sender as VistaLista).SelectedIndices.Count > 1)
                    {
                        toolStripMenuItem1.Enabled = false;
                        toolStripMenuItem2.Enabled = false;
                        toolStripMenuItem4.Enabled = false;
                        toolStripMenuItem19.Enabled = false;
                    }
                    else if ((sender as VistaLista).SelectedIndices.Count == 1)
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
        #region COPIAR
        private void toolStripMenuItem7_DropDownOpening(object sender, EventArgs e)
        {
            if(tabControl3.SelectedIndex == 0)
                copiar.copiarPorCampoToolStripMenuItem_DropDownOpening(listView1, TipoLista.Todos, sender, e);
            else if(tabControl3.SelectedIndex == 1)
                copiar.copiarPorCampoToolStripMenuItem_DropDownOpening(listView2, TipoLista.Sin_Asignar, sender, e);
            else if (tabControl3.SelectedIndex == 2)
                copiar.copiarPorCampoToolStripMenuItem_DropDownOpening(listView3, TipoLista.Finalizados, sender, e);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedIndex == 0)
                copiar.toolStripMenuItem1_Click(listView1, TipoLista.Todos, sender, e);
            else if (tabControl3.SelectedIndex == 1)
                copiar.toolStripMenuItem1_Click(listView2, TipoLista.Sin_Asignar, sender, e);
            else if (tabControl3.SelectedIndex == 2)
                copiar.toolStripMenuItem1_Click(listView3, TipoLista.Finalizados, sender, e);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedIndex == 0)
                copiar.copiarDatosDeProfesorToolStripMenuItem_Click(listView1, TipoLista.Todos, sender, e);
            else if (tabControl3.SelectedIndex == 1)
                copiar.copiarDatosDeProfesorToolStripMenuItem_Click(listView2, TipoLista.Sin_Asignar, sender, e);
            else if (tabControl3.SelectedIndex == 2)
                copiar.copiarDatosDeProfesorToolStripMenuItem_Click(listView3, TipoLista.Finalizados, sender, e);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedIndex == 0)
                copiar.títuloToolStripMenuItem_Click(listView1, TipoLista.Todos, sender, e);
            else if (tabControl3.SelectedIndex == 1)
                copiar.copiarDatosDeProfesorToolStripMenuItem_Click(listView2, TipoLista.Sin_Asignar, sender, e);
            else if (tabControl3.SelectedIndex == 2)
                copiar.copiarDatosDeProfesorToolStripMenuItem_Click(listView3, TipoLista.Finalizados, sender, e);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedIndex == 0)
                copiar.descripciónToolStripMenuItem_Click(listView1, TipoLista.Todos, sender, e);
            else if (tabControl3.SelectedIndex == 1)
                copiar.descripciónToolStripMenuItem_Click(listView2, TipoLista.Sin_Asignar, sender, e);
            else if (tabControl3.SelectedIndex == 2)
                copiar.descripciónToolStripMenuItem_Click(listView3, TipoLista.Finalizados, sender, e);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedIndex == 0)
                copiar.fechaDeRegistroToolStripMenuItem_Click(listView1, TipoLista.Todos, sender, e);
            else if (tabControl3.SelectedIndex == 1)
                copiar.fechaDeRegistroToolStripMenuItem_Click(listView2, TipoLista.Sin_Asignar, sender, e);
            else if (tabControl3.SelectedIndex == 2)
                copiar.fechaDeRegistroToolStripMenuItem_Click(listView3, TipoLista.Finalizados, sender, e);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedIndex == 0)
                copiar.nombreDelAlumnoToolStripMenuItem_Click(listView1, TipoLista.Todos, sender, e);
            else if (tabControl3.SelectedIndex == 1)
                copiar.nombreDelAlumnoToolStripMenuItem_Click(listView2, TipoLista.Sin_Asignar, sender, e);
            else if (tabControl3.SelectedIndex == 2)
                copiar.nombreDelAlumnoToolStripMenuItem_Click(listView3, TipoLista.Finalizados, sender, e);
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedIndex == 0)
                copiar.primerApellidoDelAlumnoToolStripMenuItem_Click(listView1, TipoLista.Todos, sender, e);
            else if (tabControl3.SelectedIndex == 1)
                copiar.primerApellidoDelAlumnoToolStripMenuItem_Click(listView2, TipoLista.Sin_Asignar, sender, e);
            else if (tabControl3.SelectedIndex == 2)
                copiar.primerApellidoDelAlumnoToolStripMenuItem_Click(listView3, TipoLista.Finalizados, sender, e);
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedIndex == 0)
                copiar.segundoApellidoDelAlumnoToolStripMenuItem_Click(listView1, TipoLista.Todos, sender, e);
            else if (tabControl3.SelectedIndex == 1)
                copiar.segundoApellidoDelAlumnoToolStripMenuItem_Click(listView2, TipoLista.Sin_Asignar, sender, e);
            else if (tabControl3.SelectedIndex == 2)
                copiar.segundoApellidoDelAlumnoToolStripMenuItem_Click(listView3, TipoLista.Finalizados, sender, e);
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedIndex == 0)
                copiar.matrículaToolStripMenuItem_Click(listView1, TipoLista.Todos, sender, e);
            else if (tabControl3.SelectedIndex == 1)
                copiar.matrículaToolStripMenuItem_Click(listView2, TipoLista.Sin_Asignar, sender, e);
            else if (tabControl3.SelectedIndex == 2)
                copiar.matrículaToolStripMenuItem_Click(listView3, TipoLista.Finalizados, sender, e);
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedIndex == 0)
                copiar.fechaDeInicioToolStripMenuItem_Click(listView1, TipoLista.Todos, sender, e);
            else if (tabControl3.SelectedIndex == 1)
                copiar.fechaDeInicioToolStripMenuItem_Click(listView2, TipoLista.Sin_Asignar, sender, e);
            else if (tabControl3.SelectedIndex == 2)
                copiar.fechaDeInicioToolStripMenuItem_Click(listView3, TipoLista.Finalizados, sender, e);
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedIndex == 0)
                copiar.fechaDeDefensaToolStripMenuItem_Click(listView1, TipoLista.Todos, sender, e);
            else if (tabControl3.SelectedIndex == 1)
                copiar.fechaDeDefensaToolStripMenuItem_Click(listView2, TipoLista.Sin_Asignar, sender, e);
            else if (tabControl3.SelectedIndex == 2)
                copiar.fechaDeDefensaToolStripMenuItem_Click(listView3, TipoLista.Finalizados, sender, e);
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedIndex == 0)
                copiar.convocatoriaToolStripMenuItem_Click(listView1, TipoLista.Todos, sender, e);
            else if (tabControl3.SelectedIndex == 1)
                copiar.convocatoriaToolStripMenuItem_Click(listView2, TipoLista.Sin_Asignar, sender, e);
            else if (tabControl3.SelectedIndex == 2)
                copiar.convocatoriaToolStripMenuItem_Click(listView3, TipoLista.Finalizados, sender, e);
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedIndex == 0)
                copiar.notaToolStripMenuItem_Click(listView1, TipoLista.Todos, sender, e);
            else if (tabControl3.SelectedIndex == 1)
                copiar.notaToolStripMenuItem_Click(listView2, TipoLista.Sin_Asignar, sender, e);
            else if (tabControl3.SelectedIndex == 2)
                copiar.notaToolStripMenuItem_Click(listView3, TipoLista.Finalizados, sender, e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedIndex == 0)
                copiar.copiarConFormato_Click(listView1, TipoLista.Todos, sender, e);
            else if (tabControl3.SelectedIndex == 1)
                copiar.copiarConFormato_Click(listView2, TipoLista.Sin_Asignar, sender, e);
            else if (tabControl3.SelectedIndex == 2)
                copiar.copiarConFormato_Click(listView3, TipoLista.Finalizados, sender, e);
        }
        #endregion

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new Preferencias().ShowDialog(this);
            Refresh();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            VistaLista lista = listView1;
            TipoLista tipoLista = TipoLista.Todos;

            if (tabControl3.SelectedIndex == 1)
            {
                tipoLista = TipoLista.Sin_Asignar;
                lista = listView2;
            }
            else if (tabControl3.SelectedIndex == 2)
            {
                tipoLista = TipoLista.Finalizados;
                lista = listView3;
            }

            new Form8(lista, tipoLista).ShowDialog();
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (sender.GetType() == typeof(VistaLista))
                {
                    VistaLista lista = listView1;
                    TipoLista tipoLista = TipoLista.Todos;

                    if (tabControl3.SelectedIndex == 1)
                    {
                        tipoLista = TipoLista.Sin_Asignar;
                        lista = listView2;
                    }
                    else if (tabControl3.SelectedIndex == 2)
                    {
                        tipoLista = TipoLista.Finalizados;
                        lista = listView3;
                    }

                    new Form8(lista, tipoLista).ShowDialog();
                }
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {

        }
        private void actualizarStatusLabelNumeroProyectos()
        {
            if (tabControl3.SelectedIndex == 0)
                toolStripStatusLabel2.Text = listView1.Items.Count + " proyectos";
            else if (tabControl3.SelectedIndex == 1)
                toolStripStatusLabel2.Text = listView2.Items.Count + " proyectos";
            else if (tabControl3.SelectedIndex == 2)
                toolStripStatusLabel2.Text = listView3.Items.Count + " proyectos";
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox7.SelectedIndex == 0)
            {
                comboBox7.Items.Clear();
                comboBox7.Items.Add("- Borrar búsquedas recientes -");
                button10.Enabled = false;
            }
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox2.SelectedIndex == 0)
            {
                toolStripComboBox2.Items.Clear();
                toolStripComboBox2.Items.Add("- Borrar búsquedas recientes -");
                toolStripButton1.Enabled = false;
            }
        }

        private void vistapreviadeimpresiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.PrintPreviewControl.Zoom = 1.0;
            printPreviewDialog1.ShowDialog(this);
            indiceActual = 0;
        }
        private int indiceActual = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string titulo = "Lista de TFGs";
            VistaLista listView = listView1;
            if(tabControl3.SelectedIndex == 1)
            {
                listView = listView2;
                titulo = "TFGs sin asignar";
            } else if (tabControl3.SelectedIndex == 2)
            {
                listView = listView3;
                titulo = "TFGs finalizados";
            }

            Font fuente = new Font("Segoe", 7);
            Brush brush = new SolidBrush(Constantes.DEFAULT_COLOR_TEXT);
            Point itemAnteriorPunto = new Point(10, 10);
            if(indiceActual == 0)
            {
                e.Graphics.DrawString(titulo, new Font("Segoe", 20, FontStyle.Bold), brush, new Point(itemAnteriorPunto.X + 300, 20));
                itemAnteriorPunto = new Point(10, itemAnteriorPunto.Y + 65);
            }
            for(int i = indiceActual; i < listView.Items.Count; i++)
            {
                for(int j = 0; j < listView.Items[i].SubItems.Count; j++)
                {
                    string imprimir = listView.Items[i].SubItems[j].Text + ';';
                    SizeF stringSize = e.Graphics.MeasureString(imprimir, fuente, e.MarginBounds.Size, StringFormat.GenericDefault);
                    Size stringFinalSize = new Size((int)(stringSize.Width + 10), (int)(stringSize.Height));
                    Rectangle itemRect = new Rectangle(itemAnteriorPunto, stringFinalSize);
                    e.Graphics.DrawString(imprimir, fuente, brush, itemRect);
                    itemAnteriorPunto = new Point(stringSize.ToSize().Width + itemAnteriorPunto.X, itemAnteriorPunto.Y);
                }          
                if (itemAnteriorPunto.Y >= 1100) {
                    e.HasMorePages = true;
                    indiceActual = i + 1;
                    return;
                } else e.HasMorePages = false;
                itemAnteriorPunto = new Point(10, itemAnteriorPunto.Y + listView.Items[i].Bounds.Height);
            }    
        }

        private void contenidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form9(1).ShowDialog(this);
        }

        private void índiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form9(0).ShowDialog(this);
        }

        private void mostrarProyectoEnLaListaPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indice = 0;
            if (tabControl3.SelectedIndex == 1) indice = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[listView2.SelectedIndices[0]]);
            else if (tabControl3.SelectedIndex == 2) indice = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados[listView3.SelectedIndices[0]]);
            SeleccionarItemLista(indice);
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            int indice = 0;
            if (tabControl3.SelectedIndex == 0)
            {
                indice = listView1.SelectedIndices[0];
            }
            else if (tabControl3.SelectedIndex == 1)
            {
                indice = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[listView2.SelectedIndices[0]]);
            }
            ProyectoIndice proyectoAntesAñadir = new ProyectoIndice(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Copiar(), indice);
            if (vista.BotonModificarProfesor(this, ref tabControl3, ref listView1, listView2))
            {
                MessageBox.Show("Datos de profesor actualizados con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Operacion op = new Operacion(TOperacion.Modificar, proyectoAntesAñadir);
                ProyectoIndice proyectoAñadidoAlumno = new ProyectoIndice(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Copiar(), indice);
                op.ListaProyectosDespues.Add(proyectoAñadidoAlumno);
                deshacer.Pila.Push(op);
                deshacer.VaciarRehacer();
                rehacerToolStripMenuItem.Enabled = false;
                ForwardStripButton1.Enabled = false;
                deshacerToolStripMenuItem.Enabled = true;
                BackToolStripButton1.Enabled = true;
                if (tabControl3.SelectedIndex == 0)
                {
                    vista.ActualizarDatosRichTextBox(ref richTextBox2, listView1, TipoLista.Todos, TDatos.Profesor);
                } else if (tabControl3.SelectedIndex == 1)
                {
                    vista.ActualizarDatosRichTextBox(ref richTextBox2, listView2, TipoLista.Sin_Asignar, TDatos.Profesor);
                }
                toolStripStatusLabel1.Text = fichero.ArchivoActual + '*';
            }
        }

        private void toolStripComboBox2_TextUpdate(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(toolStripComboBox2.Text))
            {
                toolStripButton1.Enabled = true;
                toolStripDropDownButton1.Enabled = true;
            }
            else
            {
                toolStripButton1.Enabled = false;
                toolStripDropDownButton1.Enabled = false;
            }
        }
    }

    public class ToolStripSystemRendererFix : ToolStripSystemRenderer //soluciona el bug al cambiar la propiedad de renderizado del toolstrip a system
    {
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (!(e.ToolStrip.GetType() == typeof(ToolStrip) || e.ToolStrip.GetType() == typeof(MenuStrip)))
            {
                base.OnRenderToolStripBorder(e);
            }
        }
    }
}
