using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GestorTFG
{
    class LeerEscribirArchivo
    {
        private FileStream fs;
        private string path;
        private LeerArchivo leerArchivo;
        private EscribirArchivo escribirArchivo;

        public string ArchivoActual
        {
            get
            {
                return path;
            }
        }

        public LeerEscribirArchivo()
        {
            //fs = File.Open("lista.tfg", FileMode.OpenOrCreate);
            fs = new FileStream("Nueva lista de proyectos", FileMode.OpenOrCreate);
            path = "Nueva lista de proyectos";
            leerArchivo = new LeerArchivo(fs);
            escribirArchivo = new EscribirArchivo(fs);
        }

        public void LeerArchivo()
        {
            leerArchivo.leerListaProyectos();
        }

        public void CambiarArchivo(string path)
        {
            fs = new FileStream(path, FileMode.OpenOrCreate);
        }

        public void EscribirArchivo()
        {
            escribirArchivo.EscribirListaProyectos();
        }

        public void CerrarFichero()
        {
            escribirArchivo.CerrarEscritura();
            leerArchivo.CerrarLectura();
            fs.Close();
        }

        public void CerrarLectura()
        {
            leerArchivo.CerrarLectura();
        }

        public void CerrarEscritura()
        {
            escribirArchivo.CerrarEscritura();
        }

        public void AbrirLectura(string path)
        {
            this.path = path;
            leerArchivo.AbrirLectura(this.path);
        }

        public void AbrirEscritura(string path)
        {
            this.path = path;
            escribirArchivo.AbrirEscritura(this.path);
        }
    }
}
