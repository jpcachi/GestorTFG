using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GestorTFG
{
    /// <summary>
    /// Esta clase optimiza la función del re-draw de un listview estándar
    /// </summary>
    public class VistaLista : ListView
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct NMHDR
        {
            public IntPtr hwndFrom;
            public uint idFrom;
            public uint code;
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
    }
}
