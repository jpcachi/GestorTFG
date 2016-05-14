using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestorTFG
{
    public partial class Preferencias : Form
    {
        private Color cabecera, textoCabecera, fondoItem, textoItem;
        private Font fuenteCabecera, fuenteItem;
        public Preferencias()
        {
            InitializeComponent();
            Size = new Size(527, 425);
            cabecera = ListViewVisualStyles.ColorCabecera;
            textoCabecera = ListViewVisualStyles.ColorTextoCabecera;
            fondoItem = ListViewVisualStyles.ColorBackgroundItem;
            textoItem = ListViewVisualStyles.ColorTextoItem;
            fuenteCabecera = ListViewVisualStyles.FuenteCabecera;
            fuenteItem = ListViewVisualStyles.FuenteItem;

            button1.BackColor = ListViewVisualStyles.ColorCabecera;
            button1.FlatAppearance.MouseDownBackColor = ListViewVisualStyles.ColorCabecera;
            button1.FlatAppearance.MouseOverBackColor = ListViewVisualStyles.ColorCabecera;
            button2.BackColor = ListViewVisualStyles.ColorTextoCabecera;
            button2.FlatAppearance.MouseDownBackColor = ListViewVisualStyles.ColorTextoCabecera;
            button2.FlatAppearance.MouseOverBackColor = ListViewVisualStyles.ColorTextoCabecera;
            button3.BackColor = ListViewVisualStyles.ColorTextoItem;
            button3.FlatAppearance.MouseDownBackColor = ListViewVisualStyles.ColorTextoItem;
            button3.FlatAppearance.MouseOverBackColor = ListViewVisualStyles.ColorTextoItem;
            button4.BackColor = ListViewVisualStyles.ColorBackgroundItem;
            button4.FlatAppearance.MouseDownBackColor = ListViewVisualStyles.ColorBackgroundItem;
            button4.FlatAppearance.MouseOverBackColor = ListViewVisualStyles.ColorBackgroundItem;
            label10.Text = ObtenerNombreFuente(ListViewVisualStyles.FuenteCabecera);
            label10.Font = ListViewVisualStyles.FuenteCabecera;
            label11.Text = ObtenerNombreFuente(ListViewVisualStyles.FuenteItem);
            label11.Font = ListViewVisualStyles.FuenteItem;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Index == 0)
            {
                Temas.Hide();
                Colores.Show();

            } else if(e.Node.Index == 1)
            {
                Colores.Hide();
                Temas.Show();
            }
        }

        private Color SeleccionarColor(Button boton, Color actual)
        {
            colorDialog1.Color = actual;
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                boton.BackColor = colorDialog1.Color;
                boton.FlatAppearance.MouseDownBackColor = colorDialog1.Color;
                boton.FlatAppearance.MouseOverBackColor = colorDialog1.Color;
                return colorDialog1.Color;
            }
            return actual;
        }

        private Font SeleccionarFuente(Button boton, Label etiqueta, Font actual)
        {
            etiqueta.Text = ObtenerNombreFuente(actual);
            etiqueta.Font = actual;
            DialogResult result = fontDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                etiqueta.Text = ObtenerNombreFuente(fontDialog1.Font);
                etiqueta.Font = fontDialog1.Font;
                return fontDialog1.Font;
            }
            return actual;
        }

        private string ObtenerNombreFuente(Font fuente)
        {
            return fuente.Name + "; " + fuente.SizeInPoints + "pt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            cabecera = SeleccionarColor(button1, ListViewVisualStyles.ColorCabecera);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           textoCabecera = SeleccionarColor(button2, ListViewVisualStyles.ColorTextoCabecera);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            textoItem = SeleccionarColor(button3, ListViewVisualStyles.ColorTextoItem);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fondoItem = SeleccionarColor(button4, ListViewVisualStyles.ColorBackgroundItem);
        }

        private void button5_Click(object sender, EventArgs e)//cambiar fuente cabecera
        {
            fuenteCabecera = SeleccionarFuente(button5, label10, ListViewVisualStyles.FuenteCabecera);
        }

        private void button6_Click(object sender, EventArgs e)//cambiar fuente item
        {
            fuenteItem = SeleccionarFuente(button6, label11, ListViewVisualStyles.FuenteItem);
        }

        private void button10_Click(object sender, EventArgs e)//restablecer
        {
            fondoItem = Constantes.DEFAULT_ITEM_BACKGROUND_COLOR;
            cabecera = Constantes.DEFAULT_HEADER_BACKGROUND_COLOR;
            textoCabecera = Constantes.DEFAULT_COLOR_TEXT;
            textoItem = Constantes.DEFAULT_COLOR_TEXT;
            fuenteCabecera = Constantes.DEFAULT_FONT;
            fuenteItem = Constantes.DEFAULT_FONT;

            button1.BackColor = cabecera;
            button2.BackColor = textoCabecera;
            button3.BackColor = textoItem;
            button4.BackColor = fondoItem;
            label10.Text = ObtenerNombreFuente(fuenteCabecera);
            label10.Font = fuenteCabecera;
            label11.Text = ObtenerNombreFuente(fuenteItem);
            label11.Font = fuenteItem;
        }

        private void AplicarCambios()
        {
            ListViewVisualStyles.ColorBackgroundItem = fondoItem;
            ListViewVisualStyles.ColorCabecera = cabecera;
            ListViewVisualStyles.ColorTextoCabecera = textoCabecera;
            ListViewVisualStyles.ColorTextoItem = textoItem;
            ListViewVisualStyles.FuenteCabecera = fuenteCabecera;
            ListViewVisualStyles.FuenteItem = fuenteItem;
            ListViewVisualStyles.CambiarColorFondo();
        }
        private void button11_Click(object sender, EventArgs e)//aceptar
        {
            DialogResult = DialogResult.OK;
            AplicarCambios();
            Close();
        }

        private void button12_Click(object sender, EventArgs e)//cancelar
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button8_Click(object sender, EventArgs e)//aceptar tema       
        {
            DialogResult = DialogResult.OK;
            AplicarCambios();
            Close();
        }

        private void button7_Click(object sender, EventArgs e)//cancelar tema
        {
            Close();
        }
    }
}
