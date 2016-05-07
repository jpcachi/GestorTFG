namespace GestorTFG
{
    partial class Form4
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.abrirToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.guardarToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.imprimirToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.cortarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copiarToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.pegarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new GestorTFG.VistaLista();
            this.Titulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Descripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FechaPropuesta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NombreAlumno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Apellido1Alumno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Apellido2Alumno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Matricula = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FechaInicio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FechaDefensa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Convocatoria = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Calificación = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 498);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(754, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(141, 17);
            this.toolStripStatusLabel1.Text = "Mostrando resultados de:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(43, 17);
            this.toolStripStatusLabel2.Text = "\"texto\"";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(754, 120);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(746, 94);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos TFG";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(740, 88);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(746, 94);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Datos Profesor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(3, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(740, 88);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1MinSize = 250;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(754, 498);
            this.splitContainer1.SplitterDistance = 374;
            this.splitContainer1.TabIndex = 7;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripButton,
            this.guardarToolStripButton1,
            this.imprimirToolStripButton1,
            this.toolStripSeparator,
            this.cortarToolStripButton,
            this.copiarToolStripButton1,
            this.pegarToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(754, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // abrirToolStripButton
            // 
            this.abrirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.abrirToolStripButton.Enabled = false;
            this.abrirToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("abrirToolStripButton.Image")));
            this.abrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.abrirToolStripButton.Name = "abrirToolStripButton";
            this.abrirToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.abrirToolStripButton.Text = "&Abrir";
            // 
            // guardarToolStripButton1
            // 
            this.guardarToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.guardarToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("guardarToolStripButton1.Image")));
            this.guardarToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.guardarToolStripButton1.Name = "guardarToolStripButton1";
            this.guardarToolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.guardarToolStripButton1.Text = "&Guardar";
            // 
            // imprimirToolStripButton1
            // 
            this.imprimirToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imprimirToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("imprimirToolStripButton1.Image")));
            this.imprimirToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imprimirToolStripButton1.Name = "imprimirToolStripButton1";
            this.imprimirToolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.imprimirToolStripButton1.Text = "&Imprimir";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // cortarToolStripButton
            // 
            this.cortarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cortarToolStripButton.Enabled = false;
            this.cortarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cortarToolStripButton.Image")));
            this.cortarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cortarToolStripButton.Name = "cortarToolStripButton";
            this.cortarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.cortarToolStripButton.Text = "Cort&ar";
            // 
            // copiarToolStripButton1
            // 
            this.copiarToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copiarToolStripButton1.Enabled = false;
            this.copiarToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("copiarToolStripButton1.Image")));
            this.copiarToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copiarToolStripButton1.Name = "copiarToolStripButton1";
            this.copiarToolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.copiarToolStripButton1.Text = "&Copiar";
            // 
            // pegarToolStripButton
            // 
            this.pegarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pegarToolStripButton.Enabled = false;
            this.pegarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pegarToolStripButton.Image")));
            this.pegarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pegarToolStripButton.Name = "pegarToolStripButton";
            this.pegarToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.pegarToolStripButton.Text = "&Pegar";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(179, 70);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem1.Text = "Copiar";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem2.Text = "Copiar con formato";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItem3.Text = "Copiar campo";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Titulo,
            this.Descripcion,
            this.FechaPropuesta,
            this.NombreAlumno,
            this.Apellido1Alumno,
            this.Apellido2Alumno,
            this.Matricula,
            this.FechaInicio,
            this.FechaDefensa,
            this.Convocatoria,
            this.Calificación});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(754, 374);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.VirtualMode = true;
            this.listView1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView1_DrawColumnHeader);
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
            this.listView1.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView1_DrawSubItem);
            this.listView1.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listView1_RetrieveVirtualItem);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // Titulo
            // 
            this.Titulo.Text = "Titulo";
            this.Titulo.Width = 158;
            // 
            // Descripcion
            // 
            this.Descripcion.Text = "Descripción";
            this.Descripcion.Width = 304;
            // 
            // FechaPropuesta
            // 
            this.FechaPropuesta.Text = "Fecha de registro";
            this.FechaPropuesta.Width = 97;
            // 
            // NombreAlumno
            // 
            this.NombreAlumno.Text = "Nombre del Alumno";
            this.NombreAlumno.Width = 116;
            // 
            // Apellido1Alumno
            // 
            this.Apellido1Alumno.Text = "Primer Apellido";
            this.Apellido1Alumno.Width = 121;
            // 
            // Apellido2Alumno
            // 
            this.Apellido2Alumno.Text = "Segundo Apellido";
            this.Apellido2Alumno.Width = 112;
            // 
            // Matricula
            // 
            this.Matricula.Text = "Matrícula";
            // 
            // FechaInicio
            // 
            this.FechaInicio.Text = "Fecha de inicio";
            this.FechaInicio.Width = 87;
            // 
            // FechaDefensa
            // 
            this.FechaDefensa.Text = "Fecha de la defensa";
            this.FechaDefensa.Width = 111;
            // 
            // Convocatoria
            // 
            this.Convocatoria.Text = "Convocatoria";
            this.Convocatoria.Width = 85;
            // 
            // Calificación
            // 
            this.Calificación.Text = "Calificación";
            this.Calificación.Width = 86;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 520);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(240, 120);
            this.Name = "Form4";
            this.ShowInTaskbar = false;
            this.Text = "Resultados de la búsqueda";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private GestorTFG.VistaLista listView1;
        private System.Windows.Forms.ColumnHeader Titulo;
        private System.Windows.Forms.ColumnHeader Descripcion;
        private System.Windows.Forms.ColumnHeader FechaPropuesta;
        private System.Windows.Forms.ColumnHeader NombreAlumno;
        private System.Windows.Forms.ColumnHeader Apellido1Alumno;
        private System.Windows.Forms.ColumnHeader Apellido2Alumno;
        private System.Windows.Forms.ColumnHeader Matricula;
        private System.Windows.Forms.ColumnHeader FechaInicio;
        private System.Windows.Forms.ColumnHeader FechaDefensa;
        private System.Windows.Forms.ColumnHeader Convocatoria;
        private System.Windows.Forms.ColumnHeader Calificación;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton abrirToolStripButton;
        private System.Windows.Forms.ToolStripButton guardarToolStripButton1;
        private System.Windows.Forms.ToolStripButton imprimirToolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cortarToolStripButton;
        private System.Windows.Forms.ToolStripButton copiarToolStripButton1;
        private System.Windows.Forms.ToolStripButton pegarToolStripButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}