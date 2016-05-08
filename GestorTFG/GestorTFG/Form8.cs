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
                alumno_nombre.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].Alumno.Nombre;
                alumno_apellido_1.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].Alumno.PrimerApellido;
                alumno_apellido_2.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].Alumno.SegundoApellido;
                alumno_matricula.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].Alumno.Matricula;
                alumno_inicio.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].Alumno.FechaInicio;
                if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].getMTFG.Finalizado)
                {
                    finalizar_defensa.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].getMTFG.getMFinalizado.Defensa;
                    finalizar_convocatoria.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].getMTFG.getMFinalizado.Convocatoria;
                    finalizar_calificacion.Text = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)lista][listView.SelectedIndices[0]].getMTFG.getMFinalizado.Nota.ToString();
                    estado.Text = "Finalizado";
                    estado.ForeColor = Color.Green;
                } else
                {
                    estado.Text = "No Finalizado";
                    estado.ForeColor = Color.Maroon;
                }
            } else
            {
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
