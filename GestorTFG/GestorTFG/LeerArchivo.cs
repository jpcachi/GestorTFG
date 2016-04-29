using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GestorTFG
{
    class LeerArchivo
    {
        private StreamReader br;
        private FileStream fs;
        public LeerArchivo(FileStream fs)
        {
            this.fs = fs;
            br = new StreamReader(this.fs);
        }

        public string leerProyecto()
        {
            string dato = br.ReadLine();
            if (!string.IsNullOrWhiteSpace(dato))
            {
                byte[] descodificar = Convert.FromBase64String(dato);
                string proyecto = System.Text.Encoding.UTF8.GetString(descodificar);
                Console.WriteLine(proyecto);
                string[] datos;
                datos = proyecto.Split(';');
                Console.WriteLine(datos.Length);
                MProyecto mProyecto = Instanciar.NuevoProyecto.Crear(datos[0], datos[1], datos[2], datos[3], datos[4], datos[5], datos[6], datos[7]);
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
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Clear();
            int i = 0;
            while (leerProyecto() != null) Console.WriteLine(i++);
        }

        public string ImportarProyecto()
        {
            string dato = br.ReadLine();
            if (!string.IsNullOrWhiteSpace(dato))
            {
                Console.WriteLine(dato);
                string[] datos;
                datos = dato.Split(';');
                Console.WriteLine(datos.Length);
                MProyecto mProyecto = Instanciar.NuevoProyecto.Crear(datos[0], datos[1], datos[2], datos[3], datos[4], datos[5], datos[6], datos[7]);
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
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Clear();
            int i = 0;
            while (ImportarProyecto() != null) Console.WriteLine(i++);
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
