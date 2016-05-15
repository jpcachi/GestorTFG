using System;
using System.IO;
using System.Text;

namespace GestorTFG
{
    public class LeerEscribirArchivo
    {
        private FileStream fs;
        private string path;
        private LeerArchivo leerArchivo;
        private EscribirArchivo escribirArchivo;
        /// <summary>
        /// Obtiene o establece la ruta del archivo actualmente en uso
        /// </summary>
        public string ArchivoActual
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }

        public bool esArchivoTXT
        {
            get
            {
                return path.Substring(path.Length - 3).ToUpperInvariant() == "TXT";
            }
        }
        public LeerEscribirArchivo()
        {
            byte[] descodificar = Convert.FromBase64String("TnVldmEgbGlzdGEgZGUgcHJveWVjdG9z");
            string proyecto = Encoding.UTF8.GetString(descodificar);
            //fs = File.Open("lista.tfg", FileMode.OpenOrCreate);
            fs = new FileStream("TnVldmEgbGlzdGEgZGUgcHJveWVjdG9z", FileMode.OpenOrCreate);
            path = proyecto;
            leerArchivo = new LeerArchivo(fs);
            escribirArchivo = new EscribirArchivo(fs);
        }
        public LeerEscribirArchivo(bool busqueda)
        {
            leerArchivo = new LeerArchivo(fs);
            escribirArchivo = new EscribirArchivo(fs);
        }
        /// <summary>
        /// Carga los datos cifrados de un archivo .tfg a la base de datos del programa
        /// </summary>
        public void LeerArchivo()
        {
            leerArchivo.leerListaProyectos();
        }
        /// <summary>
        /// Función en desuso. Será eliminada en las próximas versiones
        /// </summary>
        /// <param name="path"></param>
        public void CambiarArchivo(string path)
        {
            fs = new FileStream(path, FileMode.OpenOrCreate);
        }
        /// <summary>
        /// Escribe los datos actuales de la base de datos del programa en un fichero cifrado .tfg
        /// </summary>
        public void EscribirArchivo()
        {
            escribirArchivo.EscribirListaProyectos();
        }
        /// <summary>
        /// Cierra los flujos de lectura y escritura del programa
        /// </summary>
        public void CerrarFichero()
        {
            escribirArchivo.CerrarEscritura();
            leerArchivo.CerrarLectura();
            fs.Close();
        }
        /// <summary>
        /// Cierra el flujo de lectura
        /// </summary>
        public void CerrarLectura()
        {
            leerArchivo.CerrarLectura();
        }
        /// <summary>
        /// Cierra el flujo de escritura
        /// </summary>
        public void CerrarEscritura()
        {
            escribirArchivo.CerrarEscritura();
        }
        /// <summary>
        /// Abre el flujo de lectura
        /// </summary>
        /// <param name="path">Ruta del archivo del cual se leen los datos</param>
        public void AbrirLectura(string path)
        {
            this.path = path;
            leerArchivo.AbrirLectura(this.path);
        }
        /// <summary>
        /// Abre el flujo de escritura
        /// </summary>
        /// <param name="path">Ruta del archivo en el cual se escriben los datos</param>
        public void AbrirEscritura(string path)
        {
            this.path = path;
            escribirArchivo.AbrirEscritura(this.path);
        }
        /// <summary>
        /// Carga la lista de proyectos de un archivo de texto en la base de datos del programa
        /// </summary>
        public void ImportarArchivo()
        {
            leerArchivo.ImportarListaProyectos();
        }
        /// <summary>
        /// Escribe la lista de proyectos actual en la base de datos del programa en un archivo de texto
        /// </summary>
        public void ExportarArchivo()
        {
            escribirArchivo.ExportarListaProyectos();
        }

        public void ExportarArchivo(TipoLista lista)
        {
            escribirArchivo.ExportarListaProyectos(lista);
        }

        public void DeshacerLectura()
        {
            MListaProyectos.getMListaProyectos.getMProyectos.AñadirListas(leerArchivo.Respaldo);
        }

    }
}
