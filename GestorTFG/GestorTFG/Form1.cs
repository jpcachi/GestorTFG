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

        public Form1()
        {
            InitializeComponent();
            vista = new VistaGrafica();
            
            Fichero = new LeerEscribirArchivo();

            toolStripStatusLabel1.Text = Fichero.ArchivoActual;
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
        }

        private void comboBox7_TextUpdate(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(comboBox7.Text))
                groupBox6.Enabled = true;
            else groupBox6.Enabled = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            vista.ItemSeleccionadoLista(listView1, comboBox1, textBox8, dateTimePicker3, numericUpDown1, groupBox3, richTextBox2, button5, button6, button7, button8, button9);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedIndex = 0;
            vista.BotonAñadirProyecto(textBox1, textBox2, dateTimePicker1, textBox3, textBox4, textBox5, textBox6, textBox7, ref listView1, ref listView2);
            toolStripStatusLabel1.Text = Fichero.ArchivoActual + '*';
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
            vista.BotonAñadirAlumno(this, ref tabControl3, ref listView1, listView2, ref button7, ref button8);
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
        }
        
        private void button1_Click(object sender, EventArgs e)
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
            vista.BotonEliminarAlumno(ref listView1, ref button7, ref button8);
            toolStripStatusLabel1.Text = Fichero.ArchivoActual + '*';
        }

        private void Añadir_TextBoxChanged(object sender, EventArgs e)
        {
            if (!vista.EstanVacios(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7))
                button2.Enabled = true;          
            else button2.Enabled = false; 
            
            if(!string.IsNullOrEmpty(textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text + textBox5.Text + textBox6.Text + textBox7.Text))
                button1.Enabled = true;
            else button1.Enabled = false;
        }

        private void saveToolStripButton1_Click(object sender, EventArgs e)
        {
            if (vista.NuevaLista)
            {
                guardarcomoToolStripMenuItem_Click(sender, e);
            }
            else {
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
                    if (vista.NuevaLista) {
                        if (GuardarComo() == DialogResult.Cancel) e.Cancel = true;
                    }
                    else Guardar();
                    Fichero.CerrarFichero();
                } else Fichero.CerrarFichero();
            } else Fichero.CerrarFichero();
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
                    return;
                } 
            }
            OpenFileDialog cargar = new OpenFileDialog();
            cargar.Filter = "Lista de Proyectos (*.tfg)|*.tfg|Todos los archivos (*.*)|*.*";
            cargar.FilterIndex = 1;
            if (cargar.ShowDialog() == DialogResult.OK)
            {
                string fichero = Fichero.ArchivoActual;
                try {
                    Fichero.CerrarEscritura();
                    Fichero.AbrirLectura(cargar.FileName);
                    Fichero.LeerArchivo();
                    vista.ActualizarVistaTabla(ref listView1, 0);
                    toolStripStatusLabel1.Text = Fichero.ArchivoActual;
                    Fichero.CerrarLectura();
                } catch (Exception ex)
                {
                    MessageBox.Show("El archivo no tiene el formato especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Fichero.ArchivoActual = fichero;
                }
            }
            toolStripStatusLabel1.Text = Fichero.ArchivoActual;
            vista.GuardarLista();
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
            if ( result == DialogResult.OK)
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
    }

    public class ToolStripSystemRendererFix : ToolStripSystemRenderer //soluciona el bug al cambiar la propiedad de renderizado del toolstrip a system
    {
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //aqui no tiene que haber nada
        }

    }

}
