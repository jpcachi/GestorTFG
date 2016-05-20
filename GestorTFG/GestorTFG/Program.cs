using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GestorTFG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Form3());
            } catch(FileNotFoundException e)
            {
                MessageBox.Show("El programa no puede iniciarse porque falta Gestor_nucleo.dll en el equipo. Intente reinstalar el programa para corregir este problema.", "GestorTFG.exe - Error del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StreamWriter log = new StreamWriter("ERROR.log", true);
                log.WriteLine(DateTime.Now + " " + e.Message);
                log.Close();
            }
        }
    }
}
