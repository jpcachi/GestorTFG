using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GestorTFG
{
    class ListViewVisualStyles
    {
        /// <summary>
        /// Método encargado de la renderización de los items de un listView en modo OwnerDraw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DibujarItemListView(object sender, DrawListViewItemEventArgs e)
        {
            if (e.Item.Selected)
            {
                int posX = e.Item.SubItems[e.Item.SubItems.Count - 1].Bounds.X + e.Item.SubItems[e.Item.SubItems.Count - 1].Bounds.Width;
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(209, 232, 255)), new Rectangle(posX, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
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
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Window), e.Bounds);

            }
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, listView.Font, new Rectangle(new Point(e.Bounds.Location.X + Constantes.MARGEN_IZQUIERDO, e.Bounds.Location.Y + Constantes.MARGEN_ABAJO), new Size(e.Bounds.Width - Constantes.MARGEN_IZQUIERDO, e.Bounds.Height - Constantes.MARGEN_ABAJO)), SystemColors.WindowText, TextFormatFlags.ExpandTabs);
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
                e.Graphics.FillRectangle(SystemBrushes.ControlLight, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Header.Text, (sender as ListView).Font, new Rectangle(new Point(e.Bounds.Location.X + Constantes.MARGEN_IZQUIERDO_CABECERA, e.Bounds.Location.Y + Constantes.MARGEN_ABAJO_CABECERA), new Size(e.Bounds.Width - Constantes.MARGEN_IZQUIERDO_CABECERA, e.Bounds.Height - Constantes.MARGEN_ABAJO_CABECERA)), SystemColors.WindowText, TextFormatFlags.ExpandTabs);
            }
        }
    }
}
