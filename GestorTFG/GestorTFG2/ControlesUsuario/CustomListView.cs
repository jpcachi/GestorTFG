﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace GestorTFG2.ControlesUsuario
{
    public class CustomListView : ListView
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
