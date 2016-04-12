using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorTFG
{
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

        public void OnListView1SelectedIndexChange(ListView listView, ComboBox comboBox1, TextBox textBox8, DateTimePicker dateTimePicker3, NumericUpDown numericUpDown1, GroupBox groupBox3, RichTextBox richTextBox2, params Button[] buttons)
        {
            if (listView.SelectedItems.Count > 1)
            {
                comboBox1.Enabled = false;
                textBox8.Enabled = false;
                dateTimePicker3.Enabled = false;
                numericUpDown1.Enabled = false;
                groupBox3.Enabled = false;
                buttons[0].Enabled = false;
                buttons[1].Enabled = false;
                buttons[2].Enabled = true;
                buttons[3].Enabled = false;
                buttons[4].Enabled = true;
                richTextBox2.Clear();
            }
            else if (listView.SelectedItems.Count == 1)
            {
                comboBox1.Enabled = true;
                textBox8.Enabled = true;
                dateTimePicker3.Enabled = true;
                numericUpDown1.Enabled = true;
                groupBox3.Enabled = true;
                buttons[0].Enabled = true;
                buttons[1].Enabled = true;
                buttons[4].Enabled = true;
                
                richTextBox2.Text = "NOMBRE: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].Profesor.Nombre + " PRIMER APELLIDO: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].Profesor.PrimerApellido + " SEGUNDO APELLIDO " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].Profesor.SegundoApellido + "\nCORREO: " +
                    MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].Profesor.Correo + " DESPACHO: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].Profesor.Despacho;
                if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[listView.SelectedIndices[0]].Asignado)
                {
                    buttons[3].Enabled = false;
                    buttons[2].Enabled = true;
                }
                else
                {
                    buttons[3].Enabled = true;
                    buttons[2].Enabled = false;
                }

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
            }
        }

        public void OnListView2SelectedIndexChange(ListView listView, params Button[] buttons) //8 y 9
        {
            buttons[1].Enabled = true;
            if (listView.SelectedItems.Count == 1)
                buttons[0].Enabled = true;
            else if (listView.SelectedItems.Count > 1)
                buttons[0].Enabled = false;
            else {
                buttons[1].Enabled = false;
                buttons[1].Enabled = false;
            }
        }
    }
}
