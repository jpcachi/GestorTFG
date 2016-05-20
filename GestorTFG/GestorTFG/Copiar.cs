using System;
using System.Windows.Forms;

namespace GestorTFG
{
    class Copiar
    {
        private ToolStripMenuItem copiarPorCampoToolStripMenuItem;
        public Copiar() { }
        public Copiar(ToolStripMenuItem copiarPorCampoToolStripMenuItem)
        {
            this.copiarPorCampoToolStripMenuItem = copiarPorCampoToolStripMenuItem;
        }
        public void toolStripMenuItem1_Click(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            string proyecto = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.Titulo + ";" +
                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.Descripcion + ";" +
                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.Fecha;
            if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Asignado)
            {
                proyecto += ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Alumno.Nombre + ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Alumno.PrimerApellido +
                    ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Alumno.SegundoApellido + ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Alumno.Matricula +
                    ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Alumno.FechaInicio;
                if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.Finalizado)
                    proyecto += ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.getMFinalizado.Defensa + ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.getMFinalizado.Convocatoria +
                        ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.getMFinalizado.Nota;
            }
            Clipboard.SetText(proyecto);
        }

        public void copiarPorCampoToolStripMenuItem_DropDownOpening(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Asignado)
            {
                copiarPorCampoToolStripMenuItem.DropDownItems[3].Visible = true;
                copiarPorCampoToolStripMenuItem.DropDownItems[4].Visible = true;
                copiarPorCampoToolStripMenuItem.DropDownItems[5].Visible = true;
                copiarPorCampoToolStripMenuItem.DropDownItems[6].Visible = true;
                copiarPorCampoToolStripMenuItem.DropDownItems[7].Visible = true;
                if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.Finalizado)
                {
                    copiarPorCampoToolStripMenuItem.DropDownItems[8].Visible = true;
                    copiarPorCampoToolStripMenuItem.DropDownItems[9].Visible = true;
                    copiarPorCampoToolStripMenuItem.DropDownItems[10].Visible = true;
                }
                else
                {
                    copiarPorCampoToolStripMenuItem.DropDownItems[8].Visible = false;
                    copiarPorCampoToolStripMenuItem.DropDownItems[9].Visible = false;
                    copiarPorCampoToolStripMenuItem.DropDownItems[10].Visible = false;
                }
            }
            else
            {
                copiarPorCampoToolStripMenuItem.DropDownItems[3].Visible = false;
                copiarPorCampoToolStripMenuItem.DropDownItems[4].Visible = false;
                copiarPorCampoToolStripMenuItem.DropDownItems[5].Visible = false;
                copiarPorCampoToolStripMenuItem.DropDownItems[6].Visible = false;
                copiarPorCampoToolStripMenuItem.DropDownItems[7].Visible = false;
                copiarPorCampoToolStripMenuItem.DropDownItems[8].Visible = false;
                copiarPorCampoToolStripMenuItem.DropDownItems[9].Visible = false;
                copiarPorCampoToolStripMenuItem.DropDownItems[10].Visible = false;
            }
        }

        public void títuloToolStripMenuItem_Click(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.Titulo);
        }

        public void descripciónToolStripMenuItem_Click(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.Descripcion);
        }

        public void fechaDeRegistroToolStripMenuItem_Click(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.Fecha);
        }

        public void nombreDelAlumnoToolStripMenuItem_Click(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Alumno.Nombre);
        }

        public void primerApellidoDelAlumnoToolStripMenuItem_Click(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Alumno.PrimerApellido);
        }

        public void segundoApellidoDelAlumnoToolStripMenuItem_Click(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Alumno.SegundoApellido);
        }

        public void matrículaToolStripMenuItem_Click(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Alumno.Matricula);
        }

        public void fechaDeInicioToolStripMenuItem_Click(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Alumno.FechaInicio);
        }

        public void fechaDeDefensaToolStripMenuItem_Click(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.getMFinalizado.Defensa);
        }

        public void convocatoriaToolStripMenuItem_Click(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.getMFinalizado.Convocatoria);
        }

        public void notaToolStripMenuItem_Click(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.getMFinalizado.Nota.ToString());
        }

        public void copiarDatosDeProfesorToolStripMenuItem_Click(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Profesor.Nombre +
                ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Profesor.PrimerApellido + ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Profesor.SegundoApellido + ";" +
                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Profesor.Despacho + ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Profesor.Correo);
        }

        public void CopiarNombreCompletoProfesor(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Profesor.Nombre + " " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Profesor.PrimerApellido + " " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Profesor.SegundoApellido);
        }

        public void CopiarCorreoProfesor(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Profesor.Correo);
        }

        public void CopiarDespachoProfesor(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Profesor.Despacho);
        }

        public void CopiarNombreCompletoAlumno(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Alumno.Nombre + " " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Alumno.PrimerApellido + " " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Alumno.SegundoApellido);
        }

        public void copiarConFormato_Click(int indiceSeleccionado, TipoLista indice, object sender, EventArgs e)
        {
            string proyecto = "Título: " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.Titulo + "\r\nDescripción: " +
                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.Descripcion + "\r\nRegistrado el: " +
                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.Fecha + "\r\nNombre del profesor: " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Profesor.Nombre +
                " " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Profesor.PrimerApellido + " " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Profesor.SegundoApellido + "\r\nDespacho: " +
                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Profesor.Despacho + "\r\nCorreo electrónico: " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Profesor.Correo;
            if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Asignado)
            {
                proyecto += "\r\nNombre del alumno" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Alumno.Nombre + " " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Alumno.PrimerApellido +
                    " " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Alumno.SegundoApellido + "\r\nMatrícula: " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Alumno.Matricula +
                    "\r\nFecha de inicio" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].Alumno.FechaInicio;
                if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.Finalizado)
                    proyecto += "\r\nFecha de la defensa: " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.getMFinalizado.Defensa + "\r\nConvocatoria: " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.getMFinalizado.Convocatoria +
                        "\r\nCalificación: " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][indiceSeleccionado].getMTFG.getMFinalizado.Nota;
            }
            Clipboard.SetText(proyecto);
        }
    }
}
