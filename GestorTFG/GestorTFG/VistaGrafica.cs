using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorTFG
{
    class VistaGrafica
    {
        private CAlumno cAlumno;
        private CProyectos cProyectos;
        private CEventos cEventos;

        public bool Cambios
        {
            get
            {
                return cProyectos.Cambios;
            }
        }

        public bool NuevaLista
        {
            get
            {
                return cProyectos.NuevaLista;
            }
        }

        public VistaGrafica()
        {
            cAlumno = new CAlumno();
            cProyectos = new CProyectos();
            cEventos = new CEventos();
        }
        public void BotonAñadirProyecto(TextBox Titulo, TextBox Descripcion, DateTimePicker Fecha, TextBox ProfesorNombre, TextBox ProfesorApellido1, TextBox ProfesorApellido2, TextBox ProfesorCorreo, TextBox ProfesorDespacho, ref ListView listView1, ref ListView listView2)
        {
            if (!(EstanVacios(Titulo, Descripcion, ProfesorNombre, ProfesorApellido1, ProfesorApellido2, ProfesorDespacho, ProfesorCorreo)))
            {
                cProyectos.AñadirProyecto(Titulo.Text.Trim(), Descripcion.Text.Trim(), Fecha.Text.Trim(), ProfesorNombre.Text.Trim(), ProfesorApellido1.Text.Trim(), ProfesorApellido2.Text.Trim(), ProfesorCorreo.Text.Trim(), ProfesorDespacho.Text.Trim());
                AñadirProyectoVistaTabla(ref listView1);
                ActualizarVistaTabla(ref listView2, 1);
                listView1.SelectedIndices.Clear();
                if(listView1.Items.Count > 0)
                    listView1.Items[listView1.Items.Count - 1].Selected = true;
            }
            else MessageBox.Show("Rellene todos los campos antes de continuar", "Faltan campos por rellenar", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool BotonEliminarProyecto(ref ListView listView1, ref ListView listView2, TabControl tabControl3)
        {
            bool resul = false;
            string mensaje = "¿Desea eliminar los TFG seleccionados?";
            if ((tabControl3.SelectedIndex == 0 && listView1.SelectedItems.Count == 1) || (tabControl3.SelectedIndex == 1 && listView2.SelectedItems.Count == 1))
                mensaje = "¿Desea eliminar el TFG seleccionado?";
            if (MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (tabControl3.SelectedIndex == 0)
                {
                    while (listView1.SelectedIndices.Count > 0)
                    {
                        MListaProyectos.getMListaProyectos.getMProyectos.Borrar(listView1.SelectedIndices[listView1.SelectedIndices.Count - 1]);
                        listView1.Items.RemoveAt(listView1.SelectedIndices[listView1.SelectedIndices.Count - 1]);
                    }
                }
                else if (tabControl3.SelectedIndex == 1)
                {

                    while (listView2.SelectedIndices.Count > 0)
                    {
                        int numelems = listView2.SelectedIndices.Count - 1;
                        listView1.Items.RemoveAt(/*lista.ListaNoAsignados[numelems].Indice*/MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[numelems]));
                        listView2.Items.RemoveAt(listView2.SelectedIndices[numelems]);
                        MListaProyectos.getMListaProyectos.getMProyectos.Borrar(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[numelems]);
                        //lista.Eliminar(lista.ListaNoAsignados[numelems].Indice);
                    }
                }
                resul = true;
            }
            return resul;
        }

        public bool EstanVacios(params TextBox[] datos)
        {
            bool enc = false;
            foreach(TextBox dato in datos)
            {
                if (string.IsNullOrWhiteSpace(dato.Text))
                {
                    enc = true;
                    break;
                }
            }
            return enc;
        }

        public void ActualizarVistaTabla(ref ListView listView, int index)
        {
            listView.Items.Clear();
            foreach(MProyecto mProyecto in MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[index])
            {
                ListViewItem listViewItem = new ListViewItem(mProyecto.getMTFG.Titulo);
                listViewItem.SubItems.Add(mProyecto.getMTFG.Descripcion);
                listViewItem.SubItems.Add(mProyecto.getMTFG.Fecha);
                if (mProyecto.Asignado)
                {
                    listViewItem.SubItems.Add(mProyecto.Alumno.Nombre);
                    listViewItem.SubItems.Add(mProyecto.Alumno.PrimerApellido);
                    listViewItem.SubItems.Add(mProyecto.Alumno.SegundoApellido);
                    listViewItem.SubItems.Add(mProyecto.Alumno.FechaInicio);
                    listViewItem.SubItems.Add(mProyecto.Alumno.Matricula);
                    if (mProyecto.getMTFG.Finalizado)
                    {
                        listViewItem.SubItems.Add(mProyecto.getMTFG.getMFinalizado.Defensa);
                        listViewItem.SubItems.Add(mProyecto.getMTFG.getMFinalizado.Convocatoria);
                        listViewItem.SubItems.Add(mProyecto.getMTFG.getMFinalizado.Nota.ToString());
                    }
                } 
                listView.Items.Add(listViewItem);
            }
        }

        public void AñadirProyectoVistaTabla(ref ListView listView)
        {
            MProyecto mProyecto = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Count - 1];
            ListViewItem listViewItem = new ListViewItem(mProyecto.getMTFG.Titulo);
            listViewItem.SubItems.Add(mProyecto.getMTFG.Descripcion);
            listViewItem.SubItems.Add(mProyecto.getMTFG.Fecha);
            listView.Items.Add(listViewItem);
        }

        public void TabControlChange(ref ListView listView, int tabindex)
        {
            ActualizarVistaTabla(ref listView, tabindex);
        }
        /*public void ItemSeleccionadoLista1(ListView ListView, ComboBox modificar, TextBox modificarValue, Button[] botones, ref GroupBox finalizar)
        {
            cEventos.OnListViewSelectedIndexChange(ListView, modificar, modificarValue, botones, ref finalizar, 1);
        }

        public void ItemSeleccionadoLista2(ListView ListView, ComboBox modificar, TextBox modificarValue, Button[] botones, ref GroupBox finalizar)
        {
            cEventos.OnListViewSelectedIndexChange(ListView, modificar, modificarValue, botones, ref finalizar, 2);
        }*/

        public void ItemSeleccionadoLista(ListView listView, ref ComboBox comboBox1, TextBox textBox8, DateTimePicker dateTimePicker3, NumericUpDown numericUpDown1, GroupBox groupBox3, RichTextBox richTextBox1, RichTextBox richTextBox2, params Button[] buttons)
        {
            cEventos.OnListView1SelectedIndexChange(listView, ref comboBox1, textBox8, dateTimePicker3, numericUpDown1, groupBox3, richTextBox1, richTextBox2, buttons);
        }

        public void ItemSeleccionadoLista2(ListView listView, params Button[] buttons)
        {
            cEventos.OnListView2SelectedIndexChange(listView, buttons);
        }

        public bool BotonAñadirAlumno(Form1 ventanaAnterior, ref TabControl tabControl3, ref ListView listView1, ListView listView2, ref Button button7, ref Button button8, ref GroupBox groupBox3)
        {
            string[] datosAlumno = new string[5];
            Form2 AsignarAlumno = new Form2(datosAlumno);
            AsignarAlumno.VentanaAnterior = ventanaAnterior;
            if (AsignarAlumno.ShowDialog(ventanaAnterior) == DialogResult.Cancel) return false;
            if (datosAlumno != null)
            {
                if (tabControl3.SelectedIndex == 0)
                    MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].AsignarAlumno(datosAlumno[0], datosAlumno[1], datosAlumno[2], datosAlumno[3], datosAlumno[4]);
                else if (tabControl3.SelectedIndex == 1)
                {
                    int indexAssign = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[listView2.SelectedIndices[0]]);
                    MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indexAssign].AsignarAlumno(datosAlumno[0], datosAlumno[1], datosAlumno[2], datosAlumno[3], datosAlumno[4]);
                    tabControl3.SelectedIndex = 0;
                    listView1.Items[indexAssign].Selected = true;
                }
                List<string> datosModelo = new List<string>();
                datosModelo.Add(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Alumno.Nombre);
                datosModelo.Add(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Alumno.PrimerApellido);
                datosModelo.Add(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Alumno.SegundoApellido);
                datosModelo.Add(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Alumno.Matricula);
                datosModelo.Add(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[0]].Alumno.FechaInicio);

                foreach (string dato in datosModelo)
                {
                    listView1.SelectedItems[0].SubItems.Add(dato);
                }
                datosModelo.Clear();
                button7.Enabled = true;
                button8.Enabled = false;
                groupBox3.Enabled = true;
            }
            return true;
        }

        public void BotonEliminarAlumno(ref ListView listView, ref Button eliminarAlumno, ref Button AsignarAlumno, ref GroupBox grupoFinalizar)
        {
            for (int i = listView.SelectedIndices.Count - 1; i > -1; i--)
            {
                cAlumno.EliminarAlumno(i);
                listView.Items[i].SubItems.RemoveAt(7);
                listView.Items[i].SubItems.RemoveAt(6);
                listView.Items[i].SubItems.RemoveAt(5);
                listView.Items[i].SubItems.RemoveAt(4);
                listView.Items[i].SubItems.RemoveAt(3);
            }
            eliminarAlumno.Enabled = false;
            AsignarAlumno.Enabled = true;
            grupoFinalizar.Enabled = false;

        }
        
        public void CrearNuevaLista()
        {
            cProyectos.CrearNuevaLista();
        }
        
        public void GuardarLista()
        {
            cProyectos.GuardarProyectos();
        }
        
        public void BotonModificar(ComboBox comboBox1, TextBox textBox8, ComboBox comboBox3, DateTimePicker dateTimePicker3, NumericUpDown numericUpDown1, ref ListView listView)
        {
            string valor = "";
            int indice = listView.SelectedIndices[0];
            switch (comboBox1.SelectedIndex)
            {
                case 2: case 6: case 7: valor = dateTimePicker3.Text; break;
                case 8: valor = comboBox3.Text; break;
                case 9: valor = numericUpDown1.Value.ToString(); break;
                default: valor = textBox8.Text; break;
            }

            cProyectos.ModificarProyecto(comboBox1.SelectedIndex, valor, indice);
            ActualizarVistaTabla(ref listView, 0);
            listView.Items[indice].Selected = true;
        }

        public void BotonFinalizar(DateTimePicker dateTimePicker2, ComboBox comboBox2, NumericUpDown numericUpDown2, ref ListView listView1)
        {
            if (string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                MessageBox.Show("Rellene el campo \"Convocatoria\" para finalizar el proyecto seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            cProyectos.FinalizarProyecto(dateTimePicker2.Text, comboBox2.Text.Trim(), (float) numericUpDown2.Value, listView1.SelectedIndices[0]);
            listView1.SelectedItems[0].SubItems.Add(dateTimePicker2.Text);
            listView1.SelectedItems[0].SubItems.Add(comboBox2.Text.Trim());
            listView1.SelectedItems[0].SubItems.Add(numericUpDown2.Value.ToString());
        }
        
        public void ActualizarComboBoxModificar(ref ComboBox comboBox1, ListView listView1) 
        {
            cEventos.ActualizarComboBoxModificar(ref comboBox1, listView1);
        }
             
    }
}
