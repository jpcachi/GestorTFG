using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorTFG
{
    public partial class Form3 : Form
    {
        private Form1 ventanaPrincipal;
        public Form3()
        {
            InitializeComponent();
            ventanaPrincipal = new Form1();
            timer1.Enabled = true;
            timer1.Interval = 2000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Hide();
            ventanaPrincipal.ShowDialog();
            Close();
        }
    }
}
