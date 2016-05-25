using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorTFG
{
    public partial class Form12 : Form
    {
        private Copiar copiar;
        private MProyecto mProyecto;
        private int indice;
        private TipoLista tLista;
        public Form12(int indice, TipoLista tLista)
        {
            copiar = new Copiar();
            this.tLista = tLista;
            this.indice = indice;
            mProyecto = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)tLista][indice];

            InitializeComponent();
            titulo.Text = mProyecto.getMTFG.Titulo;
            descripcion.Text = mProyecto.getMTFG.Descripcion;
            registro.Text = mProyecto.getMTFG.Fecha;
            if (mProyecto.Asignado)
            {
                alumno_label.Visible = true;
                nombreCompletoAlumno.Visible = true;
                copiarAlumno.Visible = true;
                matricula_label.Visible = true;
                matriculaAlumno.Visible = true;
                copiarMatricula.Visible = true;
                fecha_inicio_label.Visible = true;
                fechaAlumno.Visible = true;
                copiarFechaInicio.Visible = true;
                nombreCompletoAlumno.Text = mProyecto.Alumno.Nombre + " " + mProyecto.Alumno.PrimerApellido + " " + mProyecto.Alumno.SegundoApellido;
                matriculaAlumno.Text = mProyecto.Alumno.Matricula;
                fechaAlumno.Text = mProyecto.Alumno.FechaInicio;
                if (mProyecto.getMTFG.Finalizado)
                {
                    estado.Text = "Finalizado";
                    defensa_label.Visible = true;
                    fechaDefensa.Visible = true;
                    copiarDefensa.Visible = true;
                    convocatoria_label.Visible = true;
                    Convocatoria.Visible = true;
                    copiarConvocatoria.Visible = true;
                    calificacion_label.Visible = true;
                    Calificacion.Visible = true;
                    copiarNota.Visible = true;
                    fechaDefensa.Text = mProyecto.getMTFG.getMFinalizado.Defensa;
                    Convocatoria.Text = mProyecto.getMTFG.getMFinalizado.Convocatoria;
                    Calificacion.Text = mProyecto.getMTFG.getMFinalizado.Nota.ToString();
                }
                else
                {
                    estado.Text = "Asignado";
                    defensa_label.Visible = false;
                    fechaDefensa.Visible = false;
                    copiarDefensa.Visible = false;
                    convocatoria_label.Visible = false;
                    Convocatoria.Visible = false;
                    copiarConvocatoria.Visible = false;
                    calificacion_label.Visible = false;
                    Calificacion.Visible = false;
                    copiarNota.Visible = false;
                }
            }
            else
            {
                estado.Text = "Sin asignar";
                alumno_label.Visible = false;
                nombreCompletoAlumno.Visible = false;
                copiarAlumno.Visible = false;
                matricula_label.Visible = false;
                matriculaAlumno.Visible = false;
                copiarMatricula.Visible = false;
                fecha_inicio_label.Visible = false;
                fechaAlumno.Visible = false;
                copiarFechaInicio.Visible = false;
                defensa_label.Visible = false;
                fechaDefensa.Visible = false;
                copiarDefensa.Visible = false;
                convocatoria_label.Visible = false;
                Convocatoria.Visible = false;
                copiarConvocatoria.Visible = false;
                calificacion_label.Visible = false;
                Calificacion.Visible = false;
                copiarNota.Visible = false;
            }

            nombreCompletoProfesor.Text = mProyecto.Profesor.Nombre + " " + mProyecto.Profesor.PrimerApellido + " " + mProyecto.Profesor.SegundoApellido;
            correoProfesor.Text = mProyecto.Profesor.Correo;
            despachoProfesor.Text = mProyecto.Profesor.Despacho;


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Color color1 = Color.FromArgb(200, Color.Black);
            Color color2 = Color.FromArgb(50, Color.Black);
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(panel1.Bounds, color1, color2, LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(linearGradientBrush, panel1.Bounds);
        }

        private void copiarDatos_Click(object sender, EventArgs e)
        {
            copiar.copiarConFormato_Click(indice, tLista, sender, e);
            MessageBox.Show("Todos los datos han sido copiados al portapapeles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void copiarProfesor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            copiar.CopiarNombreCompletoProfesor(indice, tLista, sender, e);
        }

        private void copiarCorreo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            copiar.CopiarCorreoProfesor(indice, tLista, sender, e);
        }

        private void copiarDespacho_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            copiar.CopiarDespachoProfesor(indice, tLista, sender, e);
        }

        private void copiarAlumno_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            copiar.CopiarNombreCompletoAlumno(indice, tLista, sender, e);
        }

        private void copiarMatricula_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            copiar.matrículaToolStripMenuItem_Click(indice, tLista, sender, e);
        }

        private void copiarFechaInicio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            copiar.fechaDeInicioToolStripMenuItem_Click(indice, tLista, sender, e);
        }

        private void copiarDefensa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            copiar.fechaDeRegistroToolStripMenuItem_Click(indice, tLista, sender, e);
        }

        private void copiarConvocatoria_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            copiar.convocatoriaToolStripMenuItem_Click(indice, tLista, sender, e);
        }

        private void copiarNota_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            copiar.notaToolStripMenuItem_Click(indice, tLista, sender, e);
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }
    }
}
