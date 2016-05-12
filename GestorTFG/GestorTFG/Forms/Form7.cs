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
        private PictureBoxInterpolated pictureBox2;
        private PictureBoxInterpolated pictureBoxInterpolated2;
        public Form7()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            this.pictureBoxInterpolated2 = new GestorTFG.PictureBoxInterpolated();
            this.pictureBox2 = new GestorTFG.PictureBoxInterpolated();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInterpolated2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxInterpolated2
            // 
            this.pictureBoxInterpolated2.BackColor = System.Drawing.Color.Navy;
            this.pictureBoxInterpolated2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxInterpolated2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxInterpolated1.Image")));
            this.pictureBoxInterpolated2.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            this.pictureBoxInterpolated2.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxInterpolated2.Name = "pictureBoxInterpolated2";
            this.pictureBoxInterpolated2.Size = new System.Drawing.Size(720, 400);
            this.pictureBoxInterpolated2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxInterpolated2.TabIndex = 2;
            this.pictureBoxInterpolated2.TabStop = false;
            this.pictureBoxInterpolated2.Visible = false;
            this.pictureBoxInterpolated2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxInterpolated1_MouseDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Navy;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox2.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(720, 400);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);


            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(720, 400);
            this.Controls.Add(this.pictureBoxInterpolated2);
            this.Controls.Add(this.pictureBox2);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form7";
            this.ShowInTaskbar = false;
            this.Text = "Form7";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form7_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInterpolated2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            //InitializeComponent();
            Cursor.Hide();
            clicked = false;
        }

        private void Form7_KeyDown(object sender, KeyEventArgs e)
        {
            if (!clicked)
            {
                pictureBoxInterpolated2.Visible = true;
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
            pictureBoxInterpolated2.Visible = true;
        }

        private void pictureBoxInterpolated1_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Show();
            Close();
        }
    }
}
