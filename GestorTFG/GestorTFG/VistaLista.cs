using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GestorTFG
{
    /// <summary>
    /// Esta clase optimiza la función del re-draw de un listview estándar
    /// </summary>
    class VistaLista : ListView
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct NMHDR
        {
            public IntPtr hwndFrom;
            public uint idFrom;
            public uint code;
        }

        public VistaLista() :base()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constantes.WM_REFLECT_NOTIFY)
            {
                NMHDR hdr = (NMHDR)m.GetLParam(typeof(NMHDR));
                if (hdr.code == Constantes.NM_CUSTOMDRAW)
                {
                    m.Result = (IntPtr)0;
                    return;
                }
            }

            base.WndProc(ref m);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // VistaLista
            // 
            this.FullRowSelect = true;
            this.GridLines = true;
            this.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.OwnerDraw = true;
            this.View = System.Windows.Forms.View.Details;
            this.ResumeLayout(false);

        }
    }
}
