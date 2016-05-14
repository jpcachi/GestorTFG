using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace GestorTFG
{

    public partial class Form5 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private Form1 ventanaPadre;
        private bool mousedown = false;
        private Point ultimaPosicion;
        private const int CP_NOCLOSE_BUTTON = 0x200;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public bool _MouseDown
        {
            get
            {
                return mousedown;
            }

            set
            {
                mousedown = value;
            }
        }

        public Point UltimaPosicion
        {
            get
            {
                return ultimaPosicion;
            }
            set
            {
                ultimaPosicion = value;
            }
        }

        public Form5(Form1 parent)
        {
            InitializeComponent();
            ventanaPadre = parent;
        }

        public void MouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ClientSize = new Size(ClientSize.Width, 27);
        }
    }
}
