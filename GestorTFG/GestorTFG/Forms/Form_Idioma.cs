using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorTFG.Forms
{
    public partial class Form_Idioma : Form
    {
        public Form_Idioma()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Color color1 = SystemColors.Control;
            Color color2 = SystemColors.ControlDark;
            Rectangle rect = new Rectangle(0, 0, Width + 9, panel1.Height - 1);
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, color1, color2, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(linearGradientBrush, rect);
        }
    }
}
