using GestorTFG.Properties;
using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolStripVisualStyles;

namespace GestorTFG
{
    public partial class Form9 : Form
    {
        public Form9(int page)
        {
            var resources = new ComponentResourceManager(typeof(Form1));
            var currentResources = new ComponentResourceManager(typeof(Form9));
            InitializeComponent();

            ToolStrip pdfViewerToolStrip = pdfViewer1.Controls[1] as ToolStrip;
            pdfViewerToolStrip.Items[0].Image = ((Image)(resources.GetObject("saveToolStripButton1.Image")));
            pdfViewerToolStrip.Items[1].Image = ((Image)(resources.GetObject("printToolStripButton1.Image")));
            pdfViewerToolStrip.Renderer = new ToolStripAeroRenderer(ToolbarTheme.HelpBar);
            try
            {
                LoadPdf(Resources.GuíaGestorTFG);
                pdfViewer1.Renderer.Page = page;
            } catch (Exception e)
            {
                MessageBox.Show("El archivo de ayuda no se encuentra disponible", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void Form9_FormClosed(object sender, FormClosedEventArgs e)
        {
            //axAcroPDF1.Dispose();
        }

        public void LoadPdf(byte[] pdfBytes)
        {
            var stream = new MemoryStream(pdfBytes);
            LoadPdf(stream);
        }

        public void LoadPdf(Stream stream)
        {
            var pdfDocument = PdfDocument.Load(stream);
            //pdfRenderer1.Load(pdfDocument);
            pdfViewer1.Renderer.Load(pdfDocument);
            pdfViewer1.Document = pdfDocument;
        }
    }
}
