using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GestorTFG
{
    public partial class Form1 : Form
    {
        private VistaGrafica vista;
        private LeerEscribirArchivo Fichero;
        private Buscador buscador;
        //private Splitter splitterLeft;
        //Splitter splitterRight;
        private Splitter splitterDown;
        private Timer SelectedIndexChangedTimer = new Timer();
        private bool drop;
        private Form5 Form5;

        public Form1()
        {
            InitializeComponent();
            vista = new VistaGrafica();
            buscador = new Buscador();
            Fichero = new LeerEscribirArchivo();

            Size = new Size((int)(Screen.PrimaryScreen.Bounds.Size.Width * 0.9f), (int)(Screen.PrimaryScreen.Bounds.Size.Height* 0.9f));

            toolStripStatusLabel1.Text = Fichero.ArchivoActual;
            toolStripContainer1.TopToolStripPanel.MaximumSize = new Size(toolStripContainer1.TopToolStripPanel.MaximumSize.Width, toolStripContainer1.TopToolStripPanel.Height);
            toolStripComboBox1.Items.Add("Todos");
            toolStripComboBox1.Items.Add("Título");
            toolStripComboBox1.Items.Add("Descripción");
            toolStripComboBox1.Items.Add("Alumno");
            toolStripComboBox1.Items.Add("Profesor");
            toolStripComboBox1.SelectedIndex = 0;
            toolStrip1.Renderer = new ToolStripSystemRendererFix();
            toolStrip2.Renderer = new ToolStripSystemRendererFix();
            menuStrip1.Renderer = new ToolStripSystemRendererFix();
            listView1.Items.Add(new ListViewItem());
            listView3.Items.Add(new ListViewItem());
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
            //

            SelectedIndexChangedTimer.Interval = 1;
            SelectedIndexChangedTimer.Tick += SelectedIndexChangedTimer_Tick;
            //toolStripContainer1.DragOver += TopToolStripPanel_DragOver;
            //toolStripContainer1.DragDrop += TopToolStripPanel_DragDrop;
            ToolStripManager.Merge(toolStrip1, toolStrip2);
            toolStrip1.Dispose();
        }

        private void SelectedIndexChangedTimer_Tick(object sender, EventArgs e)
        {
            vista.ItemSeleccionadoLista(listView1, ref comboBox1, textBox8, dateTimePicker3, numericUpDown1, groupBox3, richTextBox2, button5, button6, button7, button8, button9);
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
            tabControl2.Height = Height - e.SplitY - 113;
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
            tabControl1.Width = Width - e.SplitX - 42;
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

            //Thread proceso = new Thread(new ThreadStart(Fichero.LeerArchivo));
            Fichero.LeerArchivo();
            vista.ActualizarVistaTabla(ref listView1, 0);
            vista.ActualizarVistaTabla(ref listView3, 2);
        }

        private void comboBox7_TextUpdate(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(comboBox7.Text))
                groupBox6.Enabled = true;
            else groupBox6.Enabled = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
                vista.ItemSeleccionadoLista(listView1, ref comboBox1, textBox8, dateTimePicker3, numericUpDown1, groupBox3, richTextBox2, button5, button6, button7, button8, button9);
            else
            {
                SelectedIndexChangedTimer.Enabled = true;
                SelectedIndexChangedTimer.Interval = 1;
                SelectedIndexChangedTimer.Start();
                SelectedIndexChangedTimer.Tick += SelectedIndexChangedTimer_Tick;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedIndex = 0;
            vista.BotonAñadirProyecto(textBox6, textBox7, dateTimePicker1, textBox1, textBox2, textBox3, textBox4, textBox5, ref listView1, ref listView2);
            vista.ActualizarComboBoxModificar(ref comboBox1, listView1);
            toolStripStatusLabel1.Text = Fichero.ArchivoActual + '*';
            if (MessageBox.Show("El Proyecto se ha añadido correctamente. ¿Desea asignar un nuevo alumno?", "Añadir Proyecto", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                vista.BotonAñadirAlumno(this, ref tabControl3, ref listView1, listView2, ref button7, ref button8, ref groupBox3);
                vista.ActualizarComboBoxModificar(ref comboBox1, listView1);
            }
            limpiarCamposAñadir();
        }

        private void tabControl3_Deselected(object sender, TabControlEventArgs e)
        {
            listView1.SelectedIndices.Clear();
        }

        private void listView1_Leave(object sender, EventArgs e)
        {
            //listView1.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 2:
                case 6:
                case 7:
                    textBox8.Visible = false;
                    numericUpDown1.Visible = false;
                    dateTimePicker3.Visible = true;
                    comboBox3.Visible = false;
                    break;
                case 8:
                    textBox8.Visible = false;
                    numericUpDown1.Visible = false;
                    dateTimePicker3.Visible = false;
                    comboBox3.Visible = true;
                    break;
                case 9:
                    textBox8.Visible = false;
                    numericUpDown1.Visible = true;
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

        private void tabControl1_Leave(object sender, EventArgs e)
        {
            //tabControl1.Focus();
        }

        private void groupBox4_Leave(object sender, EventArgs e)
        {
            //groupBox4.Focus();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            vista.BotonAñadirAlumno(this, ref tabControl3, ref listView1, listView2, ref button7, ref button8, ref groupBox3);
            vista.ActualizarComboBoxModificar(ref comboBox1, listView1);
            toolStripStatusLabel1.Text = Fichero.ArchivoActual + '*';

        }

        private void button12_Click(object sender, EventArgs e)
        {
            vista.BotonEliminarProyecto(ref listView1, ref listView2, tabControl3);
            toolStripStatusLabel1.Text = Fichero.ArchivoActual + '*';
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            vista.ItemSeleccionadoLista2(listView2, button8, button9);
        }

        private void tabControl3_Selected(object sender, TabControlEventArgs e)
        {

            button9.Enabled = false;
            button8.Enabled = false;
            if (e.TabPageIndex == 1)
            {
                vista.ActualizarVistaTabla(ref listView2, 1);
            }
            else if (e.TabPageIndex == 2)
            {
                vista.ActualizarVistaTabla(ref listView3, 2);
            }
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

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

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
                toolStrip2.Visible = true;
            else toolStrip2.Visible = false;
        }

        private void búsquedaToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (búsquedaToolStripMenuItem.Checked == true)
                panel2.Visible = true;
            else panel2.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            vista.BotonEliminarAlumno(ref listView1, ref button7, ref button8, ref groupBox3);
            vista.ActualizarComboBoxModificar(ref comboBox1, listView1);
            toolStripStatusLabel1.Text = Fichero.ArchivoActual + '*';
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
                timer1.Interval = 2000;
                timer1.Start();
                timer1.Tick += Timer_Tick;

            }
        }

        private void Guardar()
        {
            Fichero.CerrarLectura();
            Fichero.AbrirEscritura(Fichero.ArchivoActual);
            Fichero.EscribirArchivo();
            toolStripStatusLabel1.Text = Fichero.ArchivoActual;
            toolStripStatusLabel1.Text += " guardado correctamente.";
            Fichero.CerrarEscritura();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = Fichero.ArchivoActual;
            timer1.Stop();
        }

        private void newToolStripButton1_Click(object sender, EventArgs e)
        {
            if (vista.Cambios)
            {
                DialogResult result = MessageBox.Show("¿Desea guardar los datos en " + '"' + Fichero.ArchivoActual + '"' + " antes de continuar?", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Cancel) return;
                else if (result == DialogResult.Yes)
                {
                    saveToolStripButton1_Click(sender, e);
                    return;
                }
            }
            vista.CrearNuevaLista();
            vista.ActualizarVistaTabla(ref listView1, 0);
            toolStripStatusLabel1.Text = "Nueva lista de proyectos";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vista.Cambios)
            {
                DialogResult result = MessageBox.Show("¿Desea guardar los datos en " + '"' + Fichero.ArchivoActual + '"' + " antes de salir?", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Cancel) e.Cancel = true;
                else if (result == DialogResult.Yes)
                {
                    if (vista.NuevaLista)
                    {
                        if (GuardarComo() == DialogResult.Cancel) e.Cancel = true;
                    }
                    else Guardar();
                    Fichero.CerrarFichero();
                }
                else Fichero.CerrarFichero();
            }
            else Fichero.CerrarFichero();
        }

        private void openToolStripButton1_Click(object sender, EventArgs e)
        {
            if (vista.Cambios)
            {
                DialogResult result = MessageBox.Show("¿Desea guardar los datos en " + '"' + Fichero.ArchivoActual + '"' + " antes de continuar?", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Cancel) return;
                else if (result == DialogResult.Yes)
                {
                    saveToolStripButton1_Click(sender, e);
                    //return;
                }
            }
            OpenFileDialog cargar = new OpenFileDialog();
            cargar.Filter = "Lista de Proyectos (*.tfg)|*.tfg|Todos los archivos (*.*)|*.*";
            cargar.FilterIndex = 1;
            if (cargar.ShowDialog() == DialogResult.OK)
            {
                string fichero = Fichero.ArchivoActual;
                try
                {
                    Fichero.CerrarEscritura();
                    Fichero.AbrirLectura(cargar.FileName);
                    Fichero.LeerArchivo();
                    vista.ActualizarVistaTabla(ref listView1, 0);
                    toolStripStatusLabel1.Text = Fichero.ArchivoActual;
                    Fichero.CerrarLectura();
                    toolStripStatusLabel1.Text = Fichero.ArchivoActual;
                    vista.GuardarLista();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El archivo no tiene el formato especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                    Fichero.ArchivoActual = fichero;
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
            guardarComo.Filter = "Lista de Proyectos (*.tfg)|*.tfg|Todos los archivos (*.*)|*.*";
            guardarComo.FilterIndex = 1;
            DialogResult result = guardarComo.ShowDialog();
            if (result == DialogResult.OK)
            {
                Fichero.CerrarLectura();
                Fichero.AbrirEscritura(guardarComo.FileName);
                toolStripStatusLabel1.Text = guardarComo.FileName;
                vista.GuardarLista();
                Fichero.EscribirArchivo();
                Fichero.CerrarEscritura();
            }
            return result;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            toolStrip2.Size = new Size(Width, 25);
        }

        private void button7_EnabledChanged(object sender, EventArgs e)
        {
            if (button7.Enabled) removeStripButton1.Enabled = true;
            else removeStripButton1.Enabled = false;
        }

        private void button8_EnabledChanged(object sender, EventArgs e)
        {
            if (button8.Enabled) addStripButton1.Enabled = true;
            else addStripButton1.Enabled = false;
        }

        private void button9_EnabledChanged(object sender, EventArgs e)
        {
            if (button9.Enabled) deleteStripButton1.Enabled = true;
            else deleteStripButton1.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            vista.BotonModificar(comboBox1, textBox8, comboBox3, dateTimePicker3, numericUpDown1, ref listView1);
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
            if (textBox8.Visible) textBox8.Clear();
            else if (comboBox3.Visible) comboBox3.ResetText();
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
            buscador.BuscarProyecto(comboBox7.Text.Trim(), (TCampos)comboBox10.SelectedIndex, comboBox9.SelectedIndex, comboBox8.SelectedIndex, dateTimePicker4, numericUpDown4);
            if (!comboBox7.Items.Contains(comboBox7.Text.Trim()))
                comboBox7.Items.Add(comboBox7.Text.Trim());
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.SelectedIndex > 0) dateTimePicker4.Enabled = true;
            else dateTimePicker4.Enabled = false;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex > 0) numericUpDown4.Enabled = true;
            else numericUpDown4.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            vista.BotonFinalizar(dateTimePicker2, comboBox2, numericUpDown2, ref listView1);
            vista.ActualizarComboBoxModificar(ref comboBox1, listView1);
            groupBox3.Enabled = false;
            button7.Enabled = false;
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

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                //vista.ItemSeleccionadoLista(listView1, ref comboBox1, textBox8, dateTimePicker3, numericUpDown1, groupBox3, richTextBox2, button5, button6, button7, button8, button9);
            }
        }

        private void comboBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button10.PerformClick();
            }
        }

        private void toolStrip2_EndDrag(object sender, EventArgs e)
        {

        }

        
        /*
        private void TopToolStripPanel_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ToolStrip)))
                e.Effect = DragDropEffects.Move;
        }

        private void TopToolStripPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ToolStrip)))
            {
                toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip2);
                Form5.Close();
                
            }
        }*/



        private void toolStrip2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //ToolStripContainer aux = (ToolStripContainer)Form5.Controls[0];
                //Form5.DoDragDrop(aux.TopToolStripPanel.Controls[0], DragDropEffects.Move);
            }
        }

        private void toolStripContainer1_TopToolStripPanel_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void toolStripContainer1_DragOver(object sender, DragEventArgs e)
        {

        }

        private void toolStrip2_EndDrag_1(object sender, EventArgs e)
        {
            Point puntero = toolStripContainer1.TopToolStripPanel.PointToClient(MousePosition);
            if (Form5 == null || !Form5.Visible)
            {
                if (!(puntero.X >= -50 && puntero.X <= toolStripContainer1.TopToolStripPanel.Width && puntero.Y >= 0 && puntero.Y <= toolStripContainer1.TopToolStripPanel.Height))
                {
                    Form5 = new Form5(this);
                    Form5.Size = toolStrip2.Size;
                    Form5.Height = 65;
                    Form5.Width = Form5.Width + 18;
                    Form5.FormBorderStyle = FormBorderStyle.FixedDialog;
                    ToolStripContainer aux = (ToolStripContainer)Form5.Controls[0];
                    Form5.Controls[0].Dock = DockStyle.Fill;
                    aux.TopToolStripPanel.Controls.Add(toolStrip2);
                    Form5.TopLevel = true;
                    Form5.Location = MousePosition;
                    Form5.Show();
                    toolStripContainer1.TopToolStripPanel.Controls.Clear();
                }
            } else
            {
                
                if (puntero.X >= -50 && puntero.X <= toolStripContainer1.TopToolStripPanel.Width && puntero.Y >= 0 && puntero.Y <= toolStripContainer1.TopToolStripPanel.Height)
                {
                    //Point posicionRelativa = toolStrip1.PointToClient(MousePosition);
                    List<ToolStrip> listaToolStrip = new List<ToolStrip>();
                    ToolStripContainer aux = (ToolStripContainer)Form5.Controls[0];
                    ToolStrip toolStripAñadido = aux.TopToolStripPanel.Controls[0] as ToolStrip;
                    toolStripContainer1.TopToolStripPanel.Controls.Clear();
                    toolStripContainer1.TopToolStripPanel.Controls.Add(toolStripAñadido);
                    toolStripAñadido.Location = new Point(puntero.X, toolStripAñadido.Location.Y);
                    //toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip1);
                    Form5.Close();
                } else toolStripContainer1.TopToolStripPanel.Controls.Clear();
            }
        }

        public void AñadirElementoToolStripContainer(ToolStrip toolStrip)
        {
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip);
        }

        private void toolStrip2_BeginDrag(object sender, EventArgs e)
        {
            Point puntero = toolStripContainer1.TopToolStripPanel.PointToClient(MousePosition);
            if (!(puntero.X >= -50 && puntero.X <= toolStripContainer1.TopToolStripPanel.Width && puntero.Y >= 0 && puntero.Y <= toolStripContainer1.TopToolStripPanel.Height))
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
            aux.DecimalPlaces = 2;
            aux.Value = 0;
            if (aprobadosToolStripMenuItem.Checked)
            {
                opcion = 1;
                aux.Value = (decimal)4.99;
            }
            else if (suspensosToolStripMenuItem.Checked)
            {
                opcion = 2;
                aux.Value = 5;
            }

            buscador.BuscarProyecto(toolStripComboBox2.Text.Trim(), (TCampos)toolStripComboBox1.SelectedIndex, 0, opcion, new DateTimePicker(), aux);
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
    }

    public class ToolStripSystemRendererFix : ToolStripSystemRenderer //soluciona el bug al cambiar la propiedad de renderizado del toolstrip a system
    {
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //aqui no tiene que haber nada
        }

    }

}
