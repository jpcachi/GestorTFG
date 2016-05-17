using GestorTFG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG_Console
{
    public class MenuEliminarProyecto
    {
        private CProyectos cProyectos;
        private int[] selecciones;
        private MProyecto[] opciones;

        public MenuEliminarProyecto()
        {
            cProyectos = new CProyectos();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.WriteLine("┌───────────────────────────┐\n│     ELIMINAR PROYECTO     │\n└───────────────────────────┘");
            opciones = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.ToArray();
            selecciones = MenuUtilidades.CrearMenuEliminar(opciones);
            if (selecciones[0] > 0)
            {
                if(selecciones.Length == opciones.Length)
                {
                    Console.WriteLine("¿Está seguro de que desea eliminar todos los proyectos? (S/N)");
                } else
                {
                    Console.WriteLine("¿Está seguro de que desea eliminar el/los proyecto/s seleccionados? (S/N)");
                }
                
                string confirmacion;
                do
                {
                    confirmacion = Console.ReadLine();
                } while (confirmacion.ToUpperInvariant().Trim() != "S" && confirmacion.ToUpperInvariant().Trim() != "N");
                if (confirmacion.ToUpperInvariant().Trim() == "S")
                {
                    for (int i = selecciones.Length - 1; i > -1; i--)
                    {
                        cProyectos.EliminarProyecto(selecciones[i] - 1);
                    }
                    Console.WriteLine("Proyecto/s eliminado/s correctamente. Pulse una tecla para continuar...\n");
                    Console.ReadKey();
                }
            } 
        }
    }
}
