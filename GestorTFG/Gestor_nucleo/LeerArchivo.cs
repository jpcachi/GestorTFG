using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GestorTFG
{
    class LeerArchivo
    {
        private StreamReader br;
        private FileStream fs;
        private List<MProyecto> respaldo;
        public List<MProyecto> Respaldo
        {
            get
            {
                return respaldo;
            }
        }
        public LeerArchivo(FileStream fs)
        {
            this.fs = fs;
            br = new StreamReader(this.fs);
            respaldo = new List<MProyecto>();
        }

        public string leerProyecto()
        {
            string dato = br.ReadLine();
            if (!string.IsNullOrWhiteSpace(dato))
            {
                byte[] descodificar = Convert.FromBase64String(dato);
                string proyecto = Encoding.UTF8.GetString(descodificar);
                string[] datos;
                datos = proyecto.Split(';');
                MProyecto mProyecto = Instanciar.NuevoProyecto.Crear(datos[0], datos[1], datos[2], datos[3], datos[4], datos[5], datos[7], datos[6]);
                if (!string.IsNullOrWhiteSpace(datos[8] + datos[9] + datos[10] + datos[11] + datos[12]))
                {
                    mProyecto.AsignarAlumno(datos[8], datos[9], datos[10], datos[11], datos[12]);
                    if (!string.IsNullOrWhiteSpace(datos[13] + datos[14] + datos[15]))
                    {
                        float nota;
                        float.TryParse(datos[15], out nota);
                        mProyecto.getMTFG.Finalizar(datos[13], datos[14], nota);
                    }
                }
                MListaProyectos.getMListaProyectos.getMProyectos.Añadir(mProyecto);
                return proyecto;
            }
            return null;
        }

        public void leerListaProyectos()
        {
            //MListaProyectos.getMListaProyectos.getMProyectos.CopiarListas(out respaldo);
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Clear();
            MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto.Clear();
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados.Clear();
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados.Clear();
            try
            {
                while (leerProyecto() != null) ;
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                //MListaProyectos.getMListaProyectos.getMProyectos.AñadirListas(respaldo);
            }
        }

        public string ImportarProyecto()
        {
            string dato = br.ReadLine();
            if (!string.IsNullOrWhiteSpace(dato))
            {
                string[] datos;
                datos = dato.Split(';');
                if (datos.Length < 7) throw new IOException();
                MProyecto mProyecto = Instanciar.NuevoProyecto.Crear(datos[0], datos[1], datos[2], datos[3], datos[4], datos[5], datos[7], datos[6]);
                if (!string.IsNullOrWhiteSpace(datos[8] + datos[9] + datos[10] + datos[11] + datos[12]))
                {
                    mProyecto.AsignarAlumno(datos[8], datos[9], datos[10], datos[11], datos[12]);
                    if (!string.IsNullOrWhiteSpace(datos[13] + datos[14] + datos[15]))
                    {
                        float nota;
                        float.TryParse(datos[15], out nota);
                        mProyecto.getMTFG.Finalizar(datos[13], datos[14], nota);
                    }
                }
                MListaProyectos.getMListaProyectos.getMProyectos.Añadir(mProyecto);
                return dato;
            }
            return null;
        }

        public void ImportarListaProyectos()
        {
            MListaProyectos.getMListaProyectos.getMProyectos.CopiarListas(ref respaldo);
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Clear();
            MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto.Clear();
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados.Clear();
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados.Clear();
            while (ImportarProyecto() != null) ;
        }

        public void CerrarLectura()
        {
            br.Close();
        }

        public void AbrirLectura(string path)
        {
            br = new StreamReader(path);
        }
    }
}
