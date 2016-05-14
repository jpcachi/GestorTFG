using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GestorTFG
{
    public class PictureBoxInterpolated : PictureBox
    {
        public InterpolationMode InterpolationMode
        {
            get; set;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = InterpolationMode;
            base.OnPaint(pe);
        }
    }
}
