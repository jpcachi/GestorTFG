using System;
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
            timer1.Interval = 500;
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
