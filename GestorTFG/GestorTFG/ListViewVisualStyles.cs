using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GestorTFG
{
    public static class ListViewVisualStyles
    {
        private static List<VistaLista> listViews = new List<VistaLista>();
        public static List<VistaLista> Listas
        {
            get
            {
                return listViews;
            }
        }
        private static Color colorCabecera = Constantes.DEFAULT_HEADER_BACKGROUND_COLOR;
        private static Color colorBackgroundItem = Constantes.DEFAULT_ITEM_BACKGROUND_COLOR;

        private static Color colorTextoCabecera = Constantes.DEFAULT_COLOR_TEXT;
        private static Color colorTextoItem = Constantes.DEFAULT_COLOR_TEXT;

        private static Font fuenteCabecera = Constantes.DEFAULT_FONT;
        private static Font fuenteItem = Constantes.DEFAULT_FONT;

        public static Color ColorCabecera
        {
            get
            {
                return colorCabecera;
            }
            set
            {
                colorCabecera = value;
            }
        }

        public static Color ColorBackgroundItem
        {
            get
            {
                return colorBackgroundItem;
            }
            set
            {
                colorBackgroundItem = value;
            }
        }

        public static Color ColorTextoCabecera
        {
            get
            {
                return colorTextoCabecera;
            }
            set
            {
                colorTextoCabecera = value;
            }
        }

        public static Color ColorTextoItem
        {
            get
            {
                return colorTextoItem;
            }
            set
            {
                colorTextoItem = value;
            }
        }

        public static Font FuenteCabecera
        {
            get
            {
                return fuenteCabecera;
            }
            set
            {
                fuenteCabecera = value;
            }
        }

        public static Font FuenteItem
        {
            get
            {
                return fuenteItem;
            }
            set
            {
                fuenteItem = value;
            }
        }

        /// <summary>
        /// Método encargado de la renderización de los items de un listView en modo OwnerDraw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DibujarItemListView(object sender, DrawListViewItemEventArgs e)
        {
            int posX = e.Item.SubItems[e.Item.SubItems.Count - 1].Bounds.X + e.Item.SubItems[e.Item.SubItems.Count - 1].Bounds.Width;
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(209, 232, 255)), new Rectangle(posX, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            } else
            {
                e.Graphics.FillRectangle(new SolidBrush(colorBackgroundItem), new Rectangle(posX, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            }
            
        }
        /// <summary>
        /// Método encargado de la renderización de los subitems de un listView en modo OwnerDraw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DibujarSubItemListView(object sender, DrawListViewSubItemEventArgs e)
        {
            ListView listView = sender as ListView;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(209, 232, 255)), e.Bounds);
                //Usar:
                //TextRenderer.DrawText(e.Graphics, e.SubItem.Text, listView.Font, new Rectangle(new Point(e.Bounds.Location.X + 2, e.Bounds.Location.Y + 1), new Size(e.Bounds.Width - 2, e.Bounds.Height - 1)), SystemColors.HighlightText, TextFormatFlags.ExpandTabs);
                //si el color es muy oscuro y se necesita resaltar el texto en blanco
            }
            else
            {
                if (e.ColumnIndex != 0)
                    e.Graphics.FillRectangle(new SolidBrush(colorBackgroundItem), e.Bounds);
                else e.Graphics.FillRectangle(new SolidBrush(colorBackgroundItem), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height - Constantes.MARGEN_ABAJO));
            }

            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, fuenteItem, new Rectangle(new Point(e.Bounds.Location.X + Constantes.MARGEN_IZQUIERDO, e.Bounds.Location.Y + Constantes.MARGEN_ABAJO), new Size(e.Bounds.Width - Constantes.MARGEN_IZQUIERDO, e.Bounds.Height - Constantes.MARGEN_ABAJO)), colorTextoItem, TextFormatFlags.ExpandTabs);
        }
        /// <summary>
        /// Método encargado de la renderización de los titulos de cabecera de un listView en modo OwnerDraw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DibujarCabeceras(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (Application.VisualStyleState == VisualStyleState.NonClientAreaEnabled) e.DrawDefault = true;
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(colorCabecera), e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Header.Text, fuenteCabecera, new Rectangle(new Point(e.Bounds.Location.X + Constantes.MARGEN_IZQUIERDO_CABECERA, e.Bounds.Location.Y + Constantes.MARGEN_ABAJO_CABECERA), new Size(e.Bounds.Width - Constantes.MARGEN_IZQUIERDO_CABECERA, e.Bounds.Height - Constantes.MARGEN_ABAJO_CABECERA)), colorTextoCabecera, TextFormatFlags.ExpandTabs);
            }
        }

        public static void CambiarColorFondo()
        {
            foreach(VistaLista vista in listViews)
                vista.BackColor = colorBackgroundItem;
        }

        public static void DibujarSubItemListViewBusqueda(string clave, object sender, DrawListViewSubItemEventArgs e)
        {
            ListView listView = sender as ListView;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(209, 232, 255)), e.Bounds);
                //Usar:
                //TextRenderer.DrawText(e.Graphics, e.SubItem.Text, listView.Font, new Rectangle(new Point(e.Bounds.Location.X + 2, e.Bounds.Location.Y + 1), new Size(e.Bounds.Width - 2, e.Bounds.Height - 1)), SystemColors.HighlightText, TextFormatFlags.ExpandTabs);
                //si el color es muy oscuro y se necesita resaltar el texto en blanco
            }
            else
            {
                if (e.ColumnIndex != 0)
                {
                    e.Graphics.FillRectangle(new SolidBrush(colorBackgroundItem), e.Bounds);
                }
                else e.Graphics.FillRectangle(new SolidBrush(colorBackgroundItem), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height - Constantes.MARGEN_ABAJO));
            }
            if (e.SubItem.Text.ToUpperInvariant().Contains(clave.ToUpperInvariant()))
            {
                int indiceClave = e.SubItem.Text.ToUpperInvariant().IndexOf(clave.ToUpperInvariant());
                string textoClave = e.SubItem.Text.Substring(indiceClave, clave.Length);
                string textoDespuesDeClave = e.SubItem.Text.Substring(indiceClave + clave.Length);
                string textoAntesDeClave = e.SubItem.Text.Substring(0, e.SubItem.Text.Length - textoClave.Length - textoDespuesDeClave.Length);
                

                Size sz = TextRenderer.MeasureText(textoAntesDeClave, fuenteItem);
                Size sz2 = TextRenderer.MeasureText(textoClave, fuenteItem);
                Size sz3 = TextRenderer.MeasureText(textoDespuesDeClave, fuenteItem);

                if(textoAntesDeClave.Length > 0)
                    TextRenderer.DrawText(e.Graphics, textoAntesDeClave, fuenteItem, new Rectangle(new Point(e.Bounds.Location.X + Constantes.MARGEN_IZQUIERDO, e.Bounds.Location.Y + Constantes.MARGEN_ABAJO),sz), colorTextoItem, TextFormatFlags.ExpandTabs);
                TextRenderer.DrawText(e.Graphics, textoClave, fuenteItem, new Rectangle(new Point(e.Bounds.Location.X - Constantes.MARGEN_IZQUIERDO + ((textoAntesDeClave.Length > 0) ? - Constantes.MARGEN_TEXTO_RESALTADO_IZQUIERDO : + Constantes.MARGEN_IZQUIERDO) + sz.Width, e.Bounds.Location.Y + Constantes.MARGEN_ABAJO), new Size((textoDespuesDeClave.Length > 0) ? sz2.Width : (e.Bounds.Width - sz.Width + Constantes.MARGEN_IZQUIERDO + Constantes.MARGEN_TEXTO_RESALTADO_IZQUIERDO), sz2.Height)), colorTextoItem, Color.Yellow, TextFormatFlags.ExpandTabs);
                if(textoDespuesDeClave.Length > 0)
                    TextRenderer.DrawText(e.Graphics, textoDespuesDeClave, fuenteItem, new Rectangle(new Point(e.Bounds.Location.X - Constantes.MARGEN_IZQUIERDO - ((textoAntesDeClave.Length > 0) ? Constantes.MARGEN_TEXTO_RESALTADO_IZQUIERDO_AL_FINAL : Constantes.MARGEN_IZQUIERDO + Constantes.MARGEN_TEXTO_RESALTADO_IZQUIERDO) + sz.Width + sz2.Width, e.Bounds.Location.Y + Constantes.MARGEN_ABAJO), new Size(e.Bounds.Width - sz.Width - sz2.Width + Constantes.MARGEN_IZQUIERDO + Constantes.MARGEN_TEXTO_RESALTADO_IZQUIERDO_AL_FINAL, sz3.Height)), colorTextoItem, TextFormatFlags.ExpandTabs);

            }

            else TextRenderer.DrawText(e.Graphics, e.SubItem.Text, fuenteItem, new Rectangle(new Point(e.Bounds.Location.X + Constantes.MARGEN_IZQUIERDO, e.Bounds.Location.Y + Constantes.MARGEN_ABAJO), new Size(e.Bounds.Width - Constantes.MARGEN_IZQUIERDO, e.Bounds.Height - Constantes.MARGEN_ABAJO)), colorTextoItem, TextFormatFlags.ExpandTabs);
        }
    }
}
