using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorTFG
{
    /// <summary>
    /// clase encargada de los eventos de seleccion de item en listview y combobox
    /// </summary>
    class CEventos
    {
        public void OnListViewSelectedIndexChange(ListView ListView, ComboBox modificar, TextBox modificarValue, Button[] botones, ref GroupBox finalizar, int index)
        {
            switch(index)
            {
                case 1:
                    if (ListView.SelectedIndices.Count > 1)
                    {
                        modificar.SelectedIndex = 0;
                        modificar.Enabled = false;
                        modificarValue.Enabled = false;
                        finalizar.Enabled = false;
                        botones[0].Enabled = false;
                        botones[1].Enabled = false;
                        botones[2].Enabled = true;
                        botones[3].Enabled = false;
                        botones[4].Enabled = true;
                    } else if(ListView.SelectedIndices.Count == 1)
                    {
                        modificarValue.Enabled = true;
                        modificar.Enabled = true;
                        if (!MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[ListView.SelectedIndices[0]].getMTFG.Finalizado && MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[ListView.SelectedIndices[0]].Asignado)
                            finalizar.Enabled = true;
                        else finalizar.Enabled = false;
                        botones[0].Enabled = true;
                        botones[1].Enabled = true;
                        if (!MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[ListView.SelectedIndices[0]].Asignado)
                        {
                            botones[2].Enabled = false;
                            botones[3].Enabled = true;
                        }
                        else {
                            botones[2].Enabled = true;
                            botones[3].Enabled = false;
                        }
                        botones[4].Enabled = true;
                    } else if (ListView.SelectedIndices.Count == 0)
                    {
                        modificar.SelectedIndex = 0;
                        modificarValue.Enabled = false;
                        modificar.Enabled = false;
                        finalizar.Enabled = false;
                        botones[0].Enabled = false;
                        botones[1].Enabled = false;
                        botones[2].Enabled = false;
                        botones[3].Enabled = false;
                        botones[4].Enabled = false;
                    }
                    break;
                case 2:
                    modificar.SelectedIndex = 0;
                    modificarValue.Enabled = false;
                    modificar.Enabled = false;
                    finalizar.Enabled = false;
                    botones[0].Enabled = false;
                    botones[1].Enabled = false;
                    botones[2].Enabled = false;
                    if (ListView.SelectedIndices.Count == 1)
                        botones[3].Enabled = true;
                    else botones[3].Enabled = false;
                    botones[4].Enabled = false;
                    break;
            }
        }

        public void OnListView1SelectedIndexChange(ListView listView, ref ComboBox comboBox1, TextBox textBox8, DateTimePicker dateTimePicker3, NumericUpDown numericUpDown1, GroupBox groupBox3, RichTextBox richTextBox1, RichTextBox richTextBox2, params Button[] buttons)
        {
            if (listView.SelectedIndices.Count > 1)
            {
                comboBox1.Enabled = false;
                textBox8.Enabled = false;
                dateTimePicker3.Enabled = false;
                numericUpDown1.Enabled = false;
                groupBox3.Enabled = false;
                buttons[0].Enabled = false;
                buttons[1].Enabled = false;
                bool enc = false;
                for(int i = 0; i < listView.SelectedIndices.Count; i++)
                {
                    if (!MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[i]].Asignado || MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[i]].getMTFG.Finalizado) enc = true;
                    if (enc) break;
                }
                if (!enc)
                    buttons[2].Enabled = true;
                else
                    buttons[2].Enabled = false;
                buttons[3].Enabled = false;
                buttons[4].Enabled = true;

                richTextBox2.Clear();
                richTextBox1.Clear();
            }
            else if (listView.SelectedIndices.Count == 1)
            {
                comboBox1.Enabled = true;
                textBox8.Enabled = true;
                dateTimePicker3.Enabled = true;
                numericUpDown1.Enabled = true;
                if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].Asignado)
                {
                    if (!MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].getMTFG.Finalizado)
                        groupBox3.Enabled = true;
                }
                else groupBox3.Enabled = false;
                buttons[0].Enabled = true;
                buttons[1].Enabled = true;
                buttons[4].Enabled = true;

                richTextBox2.Text = ActualizarDatosRichTextBox(listView.SelectedIndices[0], TipoLista.Todos, TDatos.Profesor);/*
                    "Información sobre el Profesor:\r\nNombre: " + 
                    MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].Profesor.Nombre + "\r\nPrimer apellido: " +
                    MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].Profesor.PrimerApellido + "\r\nSegundo apellido: " +
                    MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].Profesor.SegundoApellido + "\r\nCorreo electrónico: " +
                    MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].Profesor.Correo + "\r\nDespacho: " + 
                    MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].Profesor.Despacho;*/

                richTextBox1.Text = ActualizarDatosRichTextBox(listView.SelectedIndices[0], TipoLista.Todos, TDatos.TFG);
                    /*"Información sobre el TFG:\r\nTítulo: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].getMTFG.Titulo + "\r\nDescripción: " +
                    MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].getMTFG.Descripcion + "\r\nAsignado: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].Asignado +
                    "\r\nFinalizado: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].getMTFG.Finalizado;*/

                if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].Asignado)
                {
                    buttons[3].Enabled = false;
                    if(!MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].getMTFG.Finalizado)
                        buttons[2].Enabled = true;
                }
                else
                {
                    buttons[3].Enabled = true;
                    buttons[2].Enabled = false;
                }
                ActualizarComboBoxModificar(ref comboBox1, listView);
            }
            else
            {
                comboBox1.Enabled = false;
                textBox8.Enabled = false;
                dateTimePicker3.Enabled = false;
                numericUpDown1.Enabled = false;
                groupBox3.Enabled = false;
                buttons[0].Enabled = false;
                buttons[1].Enabled = false;
                buttons[2].Enabled = false;
                buttons[3].Enabled = false;
                buttons[4].Enabled = false;
                richTextBox2.Clear();
                richTextBox1.Clear();
            }
        }

        public void OnListView2SelectedIndexChange(ListView listView, ref RichTextBox richTextBox1, ref RichTextBox richTextBox2, params Button[] buttons) //8 y 9
        {
            buttons[1].Enabled = true;
            if (listView.SelectedIndices.Count == 1)
            {
                buttons[0].Enabled = true;
                richTextBox1.Text = ActualizarDatosRichTextBox(listView.SelectedIndices[0], TipoLista.Sin_Asignar, TDatos.TFG);
                richTextBox2.Text = ActualizarDatosRichTextBox(listView.SelectedIndices[0], TipoLista.Sin_Asignar, TDatos.Profesor);
            }
            else if (listView.SelectedIndices.Count > 1)
            {
                buttons[0].Enabled = false;
                richTextBox1.Clear();
                richTextBox2.Clear();
            }
            else
            {
                buttons[1].Enabled = false;
                buttons[1].Enabled = false;
                richTextBox1.Clear();
                richTextBox2.Clear();
            }
        }

        public void ActualizarComboBoxModificar(ref ComboBox comboBox1, ListView listView)
        {
            int longitud = comboBox1.Items.Count;
            if (longitud >= 3)
            {
                for (int i = longitud - 1; i > 2; i--) comboBox1.Items.RemoveAt(i);
            }
            if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].Asignado)
            {
                comboBox1.Items.Add("Nombre del Alumno");
                comboBox1.Items.Add("Primer Apellido");
                comboBox1.Items.Add("Segundo Apellido");
                comboBox1.Items.Add("Matrícula");
                comboBox1.Items.Add("Fecha de inicio");
                if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].getMTFG.Finalizado)
                {
                    comboBox1.Items.Add("Fecha de defensa");
                    comboBox1.Items.Add("Convocatoria");
                    comboBox1.Items.Add("Calificación");
                }
            }
        }

        public string ActualizarDatosRichTextBox(int indice, TipoLista indiceLista, TDatos mostrar)
        {
            string texto = null;
            switch (mostrar)
            {
                case TDatos.Profesor:
                    texto = "Información sobre el Profesor:\r\nNombre: " +
                    MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indiceLista][indice].Profesor.Nombre + "\r\nPrimer apellido: " +
                    MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indiceLista][indice].Profesor.PrimerApellido + "\r\nSegundo apellido: " +
                    MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indiceLista][indice].Profesor.SegundoApellido + "\r\nCorreo electrónico: " +
                    MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indiceLista][indice].Profesor.Correo + "\r\nDespacho: " +
                    MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indiceLista][indice].Profesor.Despacho;
                    break;
                case TDatos.TFG:
                    texto = "Información sobre el TFG:\r\nTítulo: " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indiceLista][indice].getMTFG.Titulo + "\r\nDescripción: " +
                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indiceLista][indice].getMTFG.Descripcion + "\r\nAsignado a: " + (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indiceLista][indice].Asignado ? (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indiceLista][indice].Alumno.Nombre + " "+ MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indiceLista][indice].Alumno.PrimerApellido + " " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indiceLista][indice].Alumno.SegundoApellido) : "Sin asignar") +
                "\r\nFinalizado: " + (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indiceLista][indice].getMTFG.Finalizado ? "Sí" : "No");
                    break;
            }
            return texto;
        }
    }
}
