using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class Constantes
    {
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
        public const int ALTURA_TOOLSTRIP = 25;
        public const int TEMPORIZADOR_MENSAJE_GUARDADO = 2000;
        public const int TEMPORIZADOR_SELECCION_PROYECTO = 1;
        public const int ANCHURA_MAXIMA_SPLITTER_TABCONTROL1 = 42;
        public const int ANCHURA_MAXIMA_SPLITTER_TABCONTROL2 = 113;
        public const int MARGEN_ANCHURA_TOOLSTRIP_FLOTANTE = 7;
        public const int DECIMALES_DESPUES_DE_COMA = 2;
        public const decimal LIMITE_NOTA_SUSPENSA = 4.99m;
        public const decimal LIMITE_NOTA_APROBADA = 5m;
        public const float TAMAÑO_RELATIVO_RESOLUCION = 0.9f;
        
    }
}
