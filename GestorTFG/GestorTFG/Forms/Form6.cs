using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            this.Close();
        }
    }
}
