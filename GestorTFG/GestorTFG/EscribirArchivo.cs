using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GestorTFG
{
    class EscribirArchivo
    {
        private FileStream fs;
        private StreamWriter bw;
        public EscribirArchivo(FileStream fs)
        {
            this.fs = fs;
            bw = new StreamWriter(this.fs);
        }

        private void EscribirProyecto(MProyecto proyecto)
        {
            string datos = proyecto.getMTFG.Titulo + ";" + proyecto.getMTFG.Descripcion + ";" + proyecto.getMTFG.Fecha + ";" + proyecto.Profesor.Nombre + ";" + proyecto.Profesor.PrimerApellido + ";" +
                proyecto.Profesor.SegundoApellido + ";" + proyecto.Profesor.Correo + ";" + proyecto.Profesor.Despacho + ";";
            if (proyecto.Asignado)
            {
                datos += proyecto.Alumno.Nombre + ";" + proyecto.Alumno.PrimerApellido + ";" + proyecto.Alumno.SegundoApellido + ";" + proyecto.Alumno.Matricula + ";" + proyecto.Alumno.FechaInicio + ";";
                if (proyecto.getMTFG.Finalizado)
                {
                    datos += proyecto.getMTFG.getMFinalizado.Defensa + ";" + proyecto.getMTFG.getMFinalizado.Convocatoria + ";" + proyecto.getMTFG.getMFinalizado.Nota.ToString();
                }
                else datos += ";;";
            }
            else datos += ";;;;;;;";
            byte[] codificar = Encoding.UTF8.GetBytes(datos);
            bw.Write(Convert.ToBase64String(codificar));
        }

        public void EscribirListaProyectos()
        {
            
            foreach(MProyecto proyecto in MListaProyectos.getMListaProyectos.getMProyectos.getProyectos)
            {
                EscribirProyecto(proyecto);
                bw.Write("\r\n");
            }
        }

        private void ExportarProyecto(MProyecto proyecto)
        {
            string datos = proyecto.getMTFG.Titulo + ";" + proyecto.getMTFG.Descripcion + ";" + proyecto.getMTFG.Fecha + ";" + proyecto.Profesor.Nombre + ";" + proyecto.Profesor.PrimerApellido + ";" +
                proyecto.Profesor.SegundoApellido + ";" + proyecto.Profesor.Correo + ";" + proyecto.Profesor.Despacho + ";";
            if (proyecto.Asignado)
            {
                datos += proyecto.Alumno.Nombre + ";" + proyecto.Alumno.PrimerApellido + ";" + proyecto.Alumno.SegundoApellido + ";" + proyecto.Alumno.Matricula + ";" + proyecto.Alumno.FechaInicio + ";";
                if (proyecto.getMTFG.Finalizado)
                {
                    datos += proyecto.getMTFG.getMFinalizado.Defensa + ";" + proyecto.getMTFG.getMFinalizado.Convocatoria + ";" + proyecto.getMTFG.getMFinalizado.Nota.ToString();
                }
                else datos += ";;";
            }
            else datos += ";;;;;;;";
            bw.Write(datos);
        }

        public void ExportarListaProyectos()
        {

            foreach (MProyecto proyecto in MListaProyectos.getMListaProyectos.getMProyectos.getProyectos)
            {
                ExportarProyecto(proyecto);
                bw.Write("\r\n");
            }
        }

        public void CerrarEscritura()
        {
            bw.Close();
        }

        public void AbrirEscritura(string path)
        {
            bw = new StreamWriter(path);
        }
    }
}
