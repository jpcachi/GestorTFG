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
        public void toolStripMenuItem1_Click(VistaLista listView1, TipoLista indice, object sender, EventArgs e)
        {
            string proyecto = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.Titulo + ";" +
                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.Descripcion + ";" +
                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.Fecha;
            if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Asignado)
            {
                proyecto += ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Alumno.Nombre + ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Alumno.PrimerApellido +
                    ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Alumno.SegundoApellido + ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Alumno.Matricula +
                    ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Alumno.FechaInicio;
                if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.Finalizado)
                    proyecto += ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Defensa + ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Convocatoria +
                        ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Nota;
            }
            Clipboard.SetText(proyecto);
        }

        public void copiarPorCampoToolStripMenuItem_DropDownOpening(VistaLista listView1, TipoLista indice, object sender, EventArgs e)
        {
            if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Asignado)
            {
                copiarPorCampoToolStripMenuItem.DropDownItems[3].Visible = true;
                copiarPorCampoToolStripMenuItem.DropDownItems[4].Visible = true;
                copiarPorCampoToolStripMenuItem.DropDownItems[5].Visible = true;
                copiarPorCampoToolStripMenuItem.DropDownItems[6].Visible = true;
                copiarPorCampoToolStripMenuItem.DropDownItems[7].Visible = true;
                if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.Finalizado)
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

        public void títuloToolStripMenuItem_Click(VistaLista listView1, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.Titulo);
        }

        public void descripciónToolStripMenuItem_Click(VistaLista listView1, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.Descripcion);
        }

        public void fechaDeRegistroToolStripMenuItem_Click(VistaLista listView1, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.Fecha);
        }

        public void nombreDelAlumnoToolStripMenuItem_Click(VistaLista listView1, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Alumno.Nombre);
        }

        public void primerApellidoDelAlumnoToolStripMenuItem_Click(VistaLista listView1, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Alumno.PrimerApellido);
        }

        public void segundoApellidoDelAlumnoToolStripMenuItem_Click(VistaLista listView1, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Alumno.SegundoApellido);
        }

        public void matrículaToolStripMenuItem_Click(VistaLista listView1, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Alumno.Matricula);
        }

        public void fechaDeInicioToolStripMenuItem_Click(VistaLista listView1, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Alumno.FechaInicio);
        }

        public void fechaDeDefensaToolStripMenuItem_Click(VistaLista listView1, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Defensa);
        }

        public void convocatoriaToolStripMenuItem_Click(VistaLista listView1, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Convocatoria);
        }

        public void notaToolStripMenuItem_Click(VistaLista listView1, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Nota.ToString());
        }

        public void copiarDatosDeProfesorToolStripMenuItem_Click(VistaLista listView1, TipoLista indice, object sender, EventArgs e)
        {
            Clipboard.SetText(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Profesor.Nombre +
                ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Profesor.PrimerApellido + ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Profesor.SegundoApellido + ";" +
                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Profesor.Despacho + ";" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Profesor.Correo);
        }

        public void copiarConFormato_Click(VistaLista listView1, TipoLista indice, object sender, EventArgs e)
        {
            string proyecto = "Título: " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.Titulo + "\r\nDescripción: " +
                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.Descripcion + "\r\nRegistrado el: " +
                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.Fecha + "\r\nNombre del profesor: " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Profesor.Nombre +
                " " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Profesor.PrimerApellido + " " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Profesor.SegundoApellido + "\r\nDespacho: " +
                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Profesor.Despacho + "\r\nCorreo electrónico: " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Profesor.Correo;
            if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Asignado)
            {
                proyecto += "\r\nNombre del alumno" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Alumno.Nombre + " " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Alumno.PrimerApellido +
                    " " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Alumno.SegundoApellido + "\r\nMatrícula: " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Alumno.Matricula +
                    "\r\nFecha de inicio" + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].Alumno.FechaInicio;
                if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.Finalizado)
                    proyecto += "\r\nFecha de la defensa: " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Defensa + "\r\nConvocatoria: " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Convocatoria +
                        "\r\nCalificación: " + MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[(int)indice][listView1.SelectedIndices[0]].getMTFG.getMFinalizado.Nota;
            }
            Clipboard.SetText(proyecto);
        }
    }
}
