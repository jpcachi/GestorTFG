using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorTFG
{
    public partial class Form8 : Form
    {
        private TipoLista lista;
        private Copiar copiar;
        private VistaLista listView;

        public Form8(VistaLista listView, TipoLista lista)
        {
            InitializeComponent();
            this.listView = listView;
            this.lista = lista;
            copiar = new Copiar();

            titulo.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].getMTFG.Titulo;
            descripcion.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].getMTFG.Descripcion;
            registro.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].getMTFG.Fecha;

            profesor_nombre.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].Profesor.Nombre;
            profesor_apellido_1.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].Profesor.PrimerApellido;
            profesor_apellido_2.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].Profesor.SegundoApellido;
            profesor_despacho.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].Profesor.Despacho;
            profesor_correo.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].Profesor.Correo;

            if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].Asignado)
            {
                alumno_nombre.Enabled = true;
                alumno_apellido_1.Enabled = true;
                alumno_apellido_2.Enabled = true;
                alumno_matricula.Enabled = true;
                alumno_inicio.Enabled = true;
                alumno_nombre.BackColor = SystemColors.ControlLightLight;
                alumno_apellido_1.BackColor = SystemColors.ControlLightLight;
                alumno_apellido_2.BackColor = SystemColors.ControlLightLight;
                alumno_matricula.BackColor = SystemColors.ControlLightLight;
                alumno_inicio.BackColor = SystemColors.ControlLightLight;
                alumno_nombre.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].Alumno.Nombre;
                alumno_apellido_1.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].Alumno.PrimerApellido;
                alumno_apellido_2.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].Alumno.SegundoApellido;
                alumno_matricula.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].Alumno.Matricula;
                alumno_inicio.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].Alumno.FechaInicio;
                if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].getMTFG.Finalizado)
                {
                    finalizar_defensa.Enabled = true;
                    finalizar_convocatoria.Enabled = true;
                    finalizar_calificacion.Enabled = true;
                    finalizar_defensa.BackColor = SystemColors.ControlLightLight;
                    finalizar_convocatoria.BackColor = SystemColors.ControlLightLight;
                    finalizar_calificacion.BackColor = SystemColors.ControlLightLight;
                    finalizar_defensa.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].getMTFG.getMFinalizado.Defensa;
                    finalizar_convocatoria.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].getMTFG.getMFinalizado.Convocatoria;
                    finalizar_calificacion.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].getMTFG.getMFinalizado.Nota.ToString();
                    estado.Text = "Finalizado";
                    estado.ForeColor = Color.Green;
                } else
                {
                    finalizar_defensa.BackColor = SystemColors.Control;
                    finalizar_convocatoria.BackColor = SystemColors.Control;
                    finalizar_calificacion.BackColor = SystemColors.Control;
                    finalizar_defensa.Enabled = false;
                    finalizar_convocatoria.Enabled = false;
                    finalizar_calificacion.Enabled = false;
                    estado.Text = "No Finalizado";
                    estado.ForeColor = Color.Goldenrod;

                }
            } else
            {
                alumno_nombre.BackColor = SystemColors.Control;
                alumno_apellido_1.BackColor = SystemColors.Control;
                alumno_apellido_2.BackColor = SystemColors.Control;
                alumno_matricula.BackColor = SystemColors.Control;
                alumno_inicio.BackColor = SystemColors.Control;
                finalizar_defensa.BackColor = SystemColors.Control;
                finalizar_convocatoria.BackColor = SystemColors.Control;
                finalizar_calificacion.BackColor = SystemColors.Control;
                alumno_nombre.Enabled = false;
                alumno_apellido_1.Enabled = false;
                alumno_apellido_2.Enabled = false;
                alumno_matricula.Enabled = false;
                alumno_inicio.Enabled = false;
                finalizar_defensa.Enabled = false;
                finalizar_convocatoria.Enabled = false;
                finalizar_calificacion.Enabled = false;
                estado.Text = "No Asignado";
                estado.ForeColor = Color.Maroon;
            }

        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void boton_copiar_Click(object sender, EventArgs e)
        {
            copiar.copiarConFormato_Click(listView, lista, sender, e);
            MessageBox.Show("Los datos han sido copiados al portapapeles", "Copiar al portapapeles", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
