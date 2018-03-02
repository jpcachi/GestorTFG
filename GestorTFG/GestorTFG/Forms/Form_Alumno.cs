using System;
using System.Windows.Forms;

namespace GestorTFG
{
    public partial class Form2 : Form
    {
        private Form1 ventanaPadre;
        private string[] datosAlumno;
        public DateTime fechaPropuesta
        {
            get; set;
        }
        public Form1 VentanaAnterior
        {
            set
            {
                ventanaPadre = value;
            }
        }
        public Form2(string[] datosAlumno)
        {
            InitializeComponent();
            this.datosAlumno = datosAlumno;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                if (fechaPropuesta > dateTimePicker1.Value)
                    MessageBox.Show("La fecha de inicio no puede ser anterior a la fecha de propuesta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    datosAlumno[0] = textBox1.Text.Trim();
                    datosAlumno[1] = textBox2.Text.Trim();
                    datosAlumno[2] = textBox3.Text.Trim();
                    datosAlumno[3] = textBox4.Text.Trim();
                    datosAlumno[4] = dateTimePicker1.Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            } else
            {
                MessageBox.Show("Rellene todos los campos antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
