using System.Reflection;
using System.Windows.Forms;

namespace GestorTFG
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            textBox1.Text = "María del Carmen Gutierrez de Gregorio\r\nDavid Merinero Haro\r\nJuan Pedro Cachinero Bocanegra\r\nDavid Rodríguez Ardila\r\nGuillermo Escolar Fernández\r\nDaniel Martínez Hortelano";
            label2.Text = "Versión " + Application.ProductVersion + "a. (Compilación " + Assembly.GetEntryAssembly().ImageRuntimeVersion + ").";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.ProcessStartInfo sInfo = new System.Diagnostics.ProcessStartInfo("https://github.com/jpcachi/GestorTFG");
            System.Diagnostics.Process.Start(sInfo);
            Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.ProcessStartInfo sInfo = new System.Diagnostics.ProcessStartInfo("https://drive.google.com/open?id=0B-Itw97yB5ExVE9Qb2ZSSzMwZEU");
            System.Diagnostics.Process.Start(sInfo);
            Close();
        }
    }
}
