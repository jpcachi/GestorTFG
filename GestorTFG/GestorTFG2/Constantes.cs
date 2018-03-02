using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace GestorTFG2
{
    public static class Constantes
    {
        [DllImport("user32.dll")]
        public static extern int MsgBox(int hWnd, string text, string caption, uint type);
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);
        public static readonly Color DEFAULT_HEADER_BACKGROUND_COLOR = SystemColors.Control;
        public static readonly Color DEFAULT_COLOR_TEXT = SystemColors.WindowText;
        public static readonly Color DEFAULT_ITEM_BACKGROUND_COLOR = SystemColors.Window;
        public static readonly Font DEFAULT_FONT = SystemFonts.DefaultFont;
        public const uint LVM_SETTEXTBKCOLOR = 0x1026;
        public const uint MB_TOPMOST = (uint)0x00040000L;
        public const uint NM_CUSTOMDRAW = unchecked((uint)-12);
        public const int WM_REFLECT_NOTIFY = 0x204E;
        public const int MARGEN_IZQUIERDO = 2;
        public const int MARGEN_ABAJO = 1;
        public const int MARGEN_EXTERIOR_IZQUIERDO_ARRASTRAR = -50;
        public const int MARGEN_EXTERIOR_BAJO_ARRASTRAR = -12;
        public const int MARGEN_EXTERIOR_BAJO_COMENZAR_ARRASTRAR = 0;
        public const int MARGEN_IZQUIERDO_CABECERA = 3;
        public const int MARGEN_ABAJO_CABECERA = 5;
        public const int MARGEN_TEXTO_RESALTADO_IZQUIERDO = 3;
        public const int MARGEN_TEXTO_RESALTADO_IZQUIERDO_AL_FINAL = 10;
        public const int ALTURA_TOOLSTRIP = 25;
        public const int TEMPORIZADOR_MENSAJE_GUARDADO = 2000;
        public const int TEMPORIZADOR_SELECCION_PROYECTO = 1;
        public const int ANCHURA_MAXIMA_SPLITTER_TABCONTROL1 = 42;
        public const int ANCHURA_MAXIMA_SPLITTER_TABCONTROL2 = 113;
        public const int MARGEN_ANCHURA_TOOLSTRIP_FLOTANTE = 7;
        public const int DECIMALES_DESPUES_DE_COMA = 2;
        public const decimal LIMITE_NOTA_SUSPENSA = 4.99m;
        public const decimal LIMITE_NOTA_APROBADA = 5m;
        public const float TAMAÑO_RELATIVO_RESOLUCION = 0.75f;
        public const int COLUMNA_TITULO = 0;
        public const int COLUMNA_DESCRIPCION = 1;
        public const int COLUMNA_FECHA_REGISTRO = 2;
        public const int COLUMNA_ALUMNO_NOMBRE = 3;
        public const int COLUMNA_ALUMNO_PRIMER_APELLIDO = 4;
        public const int COLUMNA_ALUMNO_SEGUNDO_APELLIDO = 5;
        public const int COLUMNA_ALUMNO_MATRICULA = 6;
        public const int COLUMNA_ALUMNO_FECHA_INICIO = 7;
        public const int COLUMNA_FECHA_DEFENSA = 8;
        public const int COLUMNA_CONVOCATORIA = 9;
        public const int COLUMNA_CALIFICACION = 10;
    }
}
