using GestorTFG.Properties;
using PdfiumViewer;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ToolStripVisualStyles;

namespace GestorTFG
{
    public partial class Form9 : Form
    {
        public Form9(int page)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            ComponentResourceManager currentResources = new ComponentResourceManager(typeof(Form9));
            InitializeComponent();

            ToolStrip pdfViewerToolStrip = pdfViewer1.Controls[1] as ToolStrip;
            pdfViewerToolStrip.GripStyle = ToolStripGripStyle.Visible;
            pdfViewerToolStrip.Items.Insert(0, new ToolStripButton((Image)(currentResources.GetObject("inicio"))));
            pdfViewerToolStrip.Items[0].ToolTipText = "Inicio";
            pdfViewerToolStrip.Items[0].Click += Inicio_Click;
            pdfViewerToolStrip.Items.RemoveAt(1);
            pdfViewerToolStrip.Items[1].Image = ((Image)(currentResources.GetObject("Print-icon")));
            pdfViewerToolStrip.Items[1].ToolTipText = "Imprimir";
            pdfViewerToolStrip.Items[3].Image = ((Image)(currentResources.GetObject("Zoom-In-icon")));
            pdfViewerToolStrip.Items[3].ToolTipText = "Ampliar zoom";
            pdfViewerToolStrip.Items[4].Image = ((Image)(currentResources.GetObject("Zoom-Out-icon")));
            pdfViewerToolStrip.Items[4].ToolTipText = "Reducir zoom";
            pdfViewerToolStrip.Renderer = new ToolStripAeroRenderer(ToolbarTheme.HelpBar);
            try
            {
                LoadPdf(Resources.GuíaGestorTFG);
                pdfViewer1.Renderer.Page = page;
            } catch (Exception e)
            {
                MessageBox.Show("El archivo de ayuda no se encuentra disponible", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            
        }

        private void Inicio_Click(object sender, EventArgs e)
        {
            pdfViewer1.Renderer.Page = 1;
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void Form9_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        public void LoadPdf(byte[] pdfBytes)
        {
            var stream = new MemoryStream(pdfBytes);
            LoadPdf(stream);
        }

        public void LoadPdf(Stream stream)
        {
            var pdfDocument = PdfDocument.Load(stream);
            pdfViewer1.Renderer.Load(pdfDocument);
            pdfViewer1.Document = pdfDocument;
        }
    }
}
