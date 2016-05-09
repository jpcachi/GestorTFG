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
    [ReadOnly(true)]
    [Browsable(false)]
    public partial class Form7 : Form
    {
        private bool clicked;
        public Form7()
        {
            clicked = false;
            InitializeComponent();
            Cursor.Hide();
        }

        private void Form7_KeyDown(object sender, KeyEventArgs e)
        {
            if (!clicked)
            {
                pictureBoxInterpolated1.Visible = true;
                clicked = true;
            }
            else if (clicked)
            {
                Cursor.Show();
                Close();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxInterpolated1.Visible = true;
        }

        private void pictureBoxInterpolated1_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Show();
            Close();
        }
    }
}
