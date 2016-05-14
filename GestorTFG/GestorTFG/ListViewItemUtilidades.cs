﻿using System.Windows.Forms;

namespace GestorTFG
{
    static class ListViewItemUtilidades
    {
        public static ListViewItem ConvertirProyectoEnItemLista(MProyecto proyecto)
        {
            ListViewItem item = new ListViewItem(proyecto.getMTFG.Titulo);
            item.SubItems.Add(proyecto.getMTFG.Descripcion);
            item.SubItems.Add(proyecto.getMTFG.Fecha);
            if (proyecto.Asignado)
            {
                item.SubItems.Add(proyecto.Alumno.Nombre);
                item.SubItems.Add(proyecto.Alumno.PrimerApellido);
                item.SubItems.Add(proyecto.Alumno.SegundoApellido);
                item.SubItems.Add(proyecto.Alumno.Matricula);
                item.SubItems.Add(proyecto.Alumno.FechaInicio);
                if (proyecto.getMTFG.Finalizado)
                {
                    item.SubItems.Add(proyecto.getMTFG.getMFinalizado.Defensa);
                    item.SubItems.Add(proyecto.getMTFG.getMFinalizado.Convocatoria);
                    item.SubItems.Add(proyecto.getMTFG.getMFinalizado.Nota.ToString());
                }
                else
                {
                    item.SubItems.Add(string.Empty);
                    item.SubItems.Add(string.Empty);
                    item.SubItems.Add(string.Empty);
                }
            }
            else
            {
                item.SubItems.Add(string.Empty);
                item.SubItems.Add(string.Empty);
                item.SubItems.Add(string.Empty);
                item.SubItems.Add(string.Empty);
                item.SubItems.Add(string.Empty);
                item.SubItems.Add(string.Empty);
                item.SubItems.Add(string.Empty);
                item.SubItems.Add(string.Empty);
            }
            return item;
        }
    }
}
