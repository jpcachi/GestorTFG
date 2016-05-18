using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorTFG
{
    public class Temas
    {
        public Color Form1_background, Form1_Foreground;
        public Color Panel2_background, Panel2_Foreground;
        public Color StatusStrip_background, StatusStrip_foreground;
        public Color ToolStrip_background, ToolStrip_foreground;
        public Color MenuStrip_background, MenuStrip_foreground;

        public Temas(Color color1, Color color2)
        {
            Form1_background = color1;
            Form1_Foreground = color2;
        }
    }

    public static class FormThemeApplier
    {
        public static void AplicarTema(this Form1 form1, Temas tema)
        {
            form1.BackColor = tema.Form1_background;
            form1.ForeColor = tema.Form1_Foreground;
            var controles = GetAllControls(form1);
            foreach (Control control in controles)
            {
                if (!(control is TextBox) && !(control is VistaLista) && !(control is NumericUpDown) && !(control is Button) && !(control is ComboBox))
                {
                    if(control.BackColor == SystemColors.ControlLightLight || control.BackColor == Color.Transparent)
                    {
                        control.BackColor = SystemColors.ControlDark;
                    }
                    else
                        control.BackColor = tema.Form1_background;
                    control.ForeColor = tema.Form1_Foreground;
                }
            }
        }

        public static IEnumerable<Control> GetAllControls(Control root)
        {
            var stack = new Stack<Control>();
            stack.Push(root);

            while (stack.Any())
            {
                var next = stack.Pop();
                foreach (Control child in next.Controls)
                    stack.Push(child);

                yield return next;
            }
        }
    }
}
