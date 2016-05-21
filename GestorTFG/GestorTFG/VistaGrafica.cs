using GestorTFG;
using System.Windows.Forms;

namespace GestorTFG
{
    /// <summary>
    /// Clase encargada de conectar los eventos con su interfaz gráfica
    /// <internal>Las partes de codigo marcadas como comentario corresponden a una implementación de listview no virtual</internal>
    /// </summary>
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
        public void BotonAñadirProyecto(TextBox Titulo, TextBox Descripcion, DateTimePicker Fecha, TextBox ProfesorNombre, TextBox ProfesorApellido1, TextBox ProfesorApellido2, TextBox ProfesorCorreo, TextBox ProfesorDespacho, ref VistaLista listView1, ref VistaLista listView2)
        {
            if (!(EstanVacios(Titulo, Descripcion, ProfesorNombre, ProfesorApellido1, ProfesorApellido2, ProfesorDespacho, ProfesorCorreo)))
            {
                cProyectos.AñadirProyecto(Titulo.Text.Trim(), Descripcion.Text.Trim(), Fecha.Text.Trim(), ProfesorNombre.Text.Trim(), ProfesorApellido1.Text.Trim(), ProfesorApellido2.Text.Trim(), ProfesorCorreo.Text.Trim(), ProfesorDespacho.Text.Trim());
                AñadirProyectoVistaTabla(ref listView1);
                //ActualizarVistaTabla(ref listView2, TipoLista.Sin_Asignar);
                listView1.SelectedIndices.Clear();
                if(listView1.Items.Count > 0)
                    listView1.Items[listView1.Items.Count - 1].Selected = true;
            }
            else MessageBox.Show("Rellene todos los campos antes de continuar", "Faltan campos por rellenar", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool BotonEliminarProyecto(ref VistaLista listView1, ref VistaLista listView2, ref VistaLista listView3, TabControl tabControl3)
        {
            bool resul = false;
            string mensaje = "¿Desea eliminar los TFG seleccionados?";
            if ((tabControl3.SelectedIndex == 0 && listView1.SelectedIndices.Count == 1) || (tabControl3.SelectedIndex == 1 && listView2.SelectedIndices.Count == 1))
                mensaje = "¿Desea eliminar el TFG seleccionado?";
            if (MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (tabControl3.SelectedIndex == 0)
                {
                    for (int i = listView1.SelectedIndices.Count - 1; i > -1; i--)
                    {
                        //istaProyectos.getMListaProyectos.getMProyectos.Borrar(listView1.SelectedIndices[i]);
                        //listView1.Items.RemoveAt(listView1.SelectedIndices[listView1.SelectedIndices.Count - 1]);
                        if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[i]].getMTFG.Finalizado)
                            MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados.Remove(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView1.SelectedIndices[i]]);
                        cProyectos.EliminarProyecto(listView1.SelectedIndices[i]);
                        
                    }
                    ActualizarVistaTabla(ref listView1, TipoLista.Todos);
                    ActualizarVistaTabla(ref listView3, TipoLista.Finalizados);
                    listView1.SelectedIndices.Clear();
                }
                else if (tabControl3.SelectedIndex == 1)
                {

                    for (int i = listView2.SelectedIndices.Count - 1; i > -1; i--)
                    {
                        int numelems = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[listView2.SelectedIndices[i]]);
                        //listView1.Items.RemoveAt(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[numelems]));
                        //listView2.Items.RemoveAt(listView2.SelectedIndices[numelems]);
                        //MListaProyectos.getMListaProyectos.getMProyectos.Borrar(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[numelems]);
                        cProyectos.EliminarProyecto(numelems);
                    }
                    ActualizarVistaTabla(ref listView1, TipoLista.Todos);
                    ActualizarVistaTabla(ref listView2, TipoLista.Sin_Asignar);
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

        public void ActualizarVistaTabla(ref VistaLista listView, TipoLista index)
        {/*
            listView.Items.Clear();
            foreach(MProyecto mProyecto in MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)index])
            {
                ListViewItem listViewItem = new ListViewItem(mProyecto.getMTFG.Titulo);
                listViewItem.SubItems.Add(mProyecto.getMTFG.Descripcion);
                listViewItem.SubItems.Add(mProyecto.getMTFG.Fecha);
                if (mProyecto.Asignado)
                {
                    listViewItem.SubItems.Add(mProyecto.Alumno.Nombre);
                    listViewItem.SubItems.Add(mProyecto.Alumno.PrimerApellido);
                    listViewItem.SubItems.Add(mProyecto.Alumno.SegundoApellido);
                    listViewItem.SubItems.Add(mProyecto.Alumno.Matricula);
                    listViewItem.SubItems.Add(mProyecto.Alumno.FechaInicio);
                    if (mProyecto.getMTFG.Finalizado)
                    {
                        listViewItem.SubItems.Add(mProyecto.getMTFG.getMFinalizado.Defensa);
                        listViewItem.SubItems.Add(mProyecto.getMTFG.getMFinalizado.Convocatoria);
                        listViewItem.SubItems.Add(mProyecto.getMTFG.getMFinalizado.Nota.ToString());
                    }
                } 
                listView.Items.Add(listViewItem);
            }*/
            listView.VirtualListSize = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)index].Count;
        }

        public void RefrescarItemsVistaTabla(ref VistaLista listView, TipoLista index)
        {
            listView.RedrawItems(0, MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)index].Count - 1, false);
        }

        public void AñadirProyectoVistaTabla(ref VistaLista listView)
        {
            MProyecto mProyecto = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Count - 1];
            ListViewItem listViewItem = new ListViewItem(mProyecto.getMTFG.Titulo);
            listViewItem.SubItems.Add(mProyecto.getMTFG.Descripcion);
            listViewItem.SubItems.Add(mProyecto.getMTFG.Fecha);
            listView.VirtualListSize = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Count;
            //listView.Items.Add(listViewItem);
        }

        public void TabControlChange(ref VistaLista listView, int tabindex)
        {
            ActualizarVistaTabla(ref listView, (TipoLista)tabindex);
        }

        public void ItemSeleccionadoLista(ListView listView, ref ComboBox comboBox1, TextBox textBox8, DateTimePicker dateTimePicker3, NumericUpDown numericUpDown1, GroupBox groupBox3, RichTextBox richTextBox1, RichTextBox richTextBox2, params Button[] buttons)
        {
            cEventos.OnListView1SelectedIndexChange(listView, ref comboBox1, textBox8, dateTimePicker3, numericUpDown1, groupBox3, richTextBox1, richTextBox2, buttons);
        }

        public void ItemSeleccionadoLista2(ListView listView, ref ComboBox comboBox1, TextBox textBox8, DateTimePicker dateTimePicker3, NumericUpDown numericUpDown1, ref RichTextBox richTextBox1, ref RichTextBox richTextBox2, params Button[] buttons)
        {
            cEventos.OnListView2SelectedIndexChange(listView, ref comboBox1, textBox8, dateTimePicker3, numericUpDown1 ,ref richTextBox1, ref richTextBox2, buttons);
        }

        public void ItemSeleccionadoLista3(ListView listView, ref ComboBox comboBox1, TextBox textBox8, DateTimePicker dateTimePicker3, NumericUpDown numericUpDown1, RichTextBox richTextBox1, RichTextBox richTextBox2)
        {
            cEventos.OnListView3SelectedIndexChange(listView, ref comboBox1, textBox8, dateTimePicker3, numericUpDown1, richTextBox1, richTextBox2);
        }

        public bool BotonAñadirAlumno(Form1 ventanaAnterior, ref TabControl tabControl3, ref VistaLista listView1, VistaLista listView2, ref Button button7, ref Button button8, ref GroupBox groupBox3)
        {
            string[] datosAlumno = new string[5];
            Form2 AsignarAlumno = new Form2(datosAlumno);
            AsignarAlumno.VentanaAnterior = ventanaAnterior;
            if (AsignarAlumno.ShowDialog(ventanaAnterior) == DialogResult.Cancel) return false;
            if (datosAlumno != null)
            {
                if (tabControl3.SelectedIndex == 0)
                {
                    cAlumno.AsignarAlumno(datosAlumno[0], datosAlumno[1], datosAlumno[2], datosAlumno[3], datosAlumno[4], listView1.SelectedIndices[0]);
                    listView1.RedrawItems(listView1.SelectedIndices[0], listView1.SelectedIndices[0], false);
                }
                else if (tabControl3.SelectedIndex == 1)
                {
                    int indexAssign = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[listView2.SelectedIndices[0]]);
                    cAlumno.AsignarAlumno(datosAlumno[0], datosAlumno[1], datosAlumno[2], datosAlumno[3], datosAlumno[4], indexAssign);
                    ActualizarVistaTabla(ref listView2, TipoLista.Sin_Asignar);
                    tabControl3.SelectedIndex = 0;
                    listView1.Items[indexAssign].Selected = true;
                }
                /*
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
                datosModelo.Clear();*/

                button7.Enabled = true;
                button8.Enabled = false;
                groupBox3.Enabled = true;
            }
            return true;
        }

        public void BotonEliminarAlumno(ref VistaLista listView, ref Button eliminarAlumno, ref Button AsignarAlumno, ref GroupBox grupoFinalizar)
        {
            for (int i = 0; i < listView.SelectedIndices.Count; i++)
            {
                cAlumno.EliminarAlumno(listView.SelectedIndices[i]);

                //listView.Items[i].SubItems.RemoveAt(7);
                //listView.Items[i].SubItems.RemoveAt(6);
                //listView.Items[i].SubItems.RemoveAt(5);
                //listView.Items[i].SubItems.RemoveAt(4);
                //listView.Items[i].SubItems.RemoveAt(3);
                listView.RedrawItems(listView.SelectedIndices[i], listView.SelectedIndices[i], false);
            }
            
            eliminarAlumno.Enabled = false;
            AsignarAlumno.Enabled = true;
            grupoFinalizar.Enabled = false;

        }

        public bool BotonModificarProfesor(Form1 ventanaAnterior, ref TabControl tabControl3, ref VistaLista listView1, VistaLista listView2)
        {
            string[] datosProfesor = new string[5];
            int indice = 0;
            if(tabControl3.SelectedIndex == 0)
            {
                indice = listView1.SelectedIndices[0];
            } else if(tabControl3.SelectedIndex == 1)
            {
                indice = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[listView2.SelectedIndices[0]]);
            }
            datosProfesor[0] = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Profesor.Nombre;
            datosProfesor[1] = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Profesor.PrimerApellido;
            datosProfesor[2] = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Profesor.SegundoApellido;
            datosProfesor[3] = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Profesor.Correo;
            datosProfesor[4] = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Profesor.Despacho;

            return new Form10(datosProfesor, indice).ShowDialog(ventanaAnterior) == DialogResult.OK;
        }
        
        public void CrearNuevaLista()
        {
            cProyectos.CrearNuevaLista();
        }
        
        public void GuardarLista()
        {
            cProyectos.GuardarProyectos();
        }
        
        public void BotonModificar(ComboBox comboBox1, TextBox textBox8, ComboBox comboBox3, DateTimePicker dateTimePicker3, NumericUpDown numericUpDown1, ref VistaLista listView, TipoLista indiceLista)
        {
            string valor = "";
            //int indice = listView.SelectedIndices[0];
            int indice = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indiceLista][listView.SelectedIndices[0]]);//listView.SelectedIndices[0];
            switch (comboBox1.SelectedIndex)
            {
                case 2: case 7: case 8: valor = dateTimePicker3.Text; break;
                case 9: valor = comboBox3.Text; break;
                case 10: valor = numericUpDown1.Value.ToString(); break;
                default: valor = textBox8.Text; break;
            }

            cProyectos.ModificarProyecto(comboBox1.SelectedIndex, valor, indice);
            listView.RedrawItems(listView.SelectedIndices[0], listView.SelectedIndices[0], false);
            //ActualizarVistaTabla(ref listView, indiceLista);
            //listView.Items[indice].Selected = true;
        }

        public void BotonFinalizar(DateTimePicker dateTimePicker2, ComboBox comboBox2, NumericUpDown numericUpDown2, ref VistaLista listView1)
        {
            if (string.IsNullOrWhiteSpace(comboBox2.Text))
            {
                MessageBox.Show("Rellene el campo \"Convocatoria\" para finalizar el proyecto seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            cProyectos.FinalizarProyecto(dateTimePicker2.Text, comboBox2.Text.Trim(), (float) numericUpDown2.Value, listView1.SelectedIndices[0]);
            //listView1.SelectedItems[0].SubItems.Add(dateTimePicker2.Text);
            //listView1.SelectedItems[0].SubItems.Add(comboBox2.Text.Trim());
            //listView1.SelectedItems[0].SubItems.Add(numericUpDown2.Value.ToString());
            listView1.RedrawItems(listView1.SelectedIndices[0], listView1.SelectedIndices[listView1.SelectedIndices.Count - 1], false);
        }
        
        public void ActualizarComboBoxModificar(ref ComboBox comboBox1, ListView listView, TipoLista lista) 
        {
            cEventos.ActualizarComboBoxModificar(ref comboBox1, listView, lista);
        }

        public void ActualizarDatosRichTextBox(ref RichTextBox richTextBox, ListView listView, TipoLista indiceLista ,TDatos mostrar)
        {
            if (listView.SelectedIndices.Count == 1)
                richTextBox.Text = cEventos.ActualizarDatosRichTextBox(listView.SelectedIndices[0], indiceLista, mostrar);
            else richTextBox.Clear();
        }
    }
}
