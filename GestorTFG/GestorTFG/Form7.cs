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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            Cursor.Hide();
        }

        private void Form7_KeyDown(object sender, KeyEventArgs e)
        {
            Cursor.Show();
            Close();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Show();
            Close();
        }
    }
}
