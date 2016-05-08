namespace GestorTFG
{
    partial class Form7
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            this.pictureBoxInterpolated1 = new GestorTFG.PictureBoxInterpolated();
            this.pictureBox1 = new GestorTFG.PictureBoxInterpolated();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInterpolated1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxInterpolated1
            // 
            this.pictureBoxInterpolated1.BackColor = System.Drawing.Color.Navy;
            this.pictureBoxInterpolated1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxInterpolated1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxInterpolated1.Image")));
            this.pictureBoxInterpolated1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            this.pictureBoxInterpolated1.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxInterpolated1.Name = "pictureBoxInterpolated1";
            this.pictureBoxInterpolated1.Size = new System.Drawing.Size(720, 400);
            this.pictureBoxInterpolated1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxInterpolated1.TabIndex = 2;
            this.pictureBoxInterpolated1.TabStop = false;
            this.pictureBoxInterpolated1.Visible = false;
            this.pictureBoxInterpolated1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxInterpolated1_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Navy;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(720, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(720, 400);
            this.Controls.Add(this.pictureBoxInterpolated1);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form7";
            this.ShowInTaskbar = false;
            this.Text = "Form7";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form7_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInterpolated1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private PictureBoxInterpolated pictureBox1;
        private PictureBoxInterpolated pictureBoxInterpolated1;
    }
}