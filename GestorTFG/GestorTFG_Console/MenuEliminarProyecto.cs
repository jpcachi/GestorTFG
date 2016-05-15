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
        private int seleccion;
        private MProyecto[] opciones;

        public MenuEliminarProyecto()
        {
            cProyectos = new CProyectos();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.WriteLine("ELIMINAR PROYECTO\n------------------");
            opciones = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.ToArray();
            seleccion = MenuUtilidades.CrearMenu(opciones);
            if (seleccion < opciones.Length)
            {
                
                Console.WriteLine("¿Está seguro de que quiere eliminar el proyecto " + opciones[seleccion].getMTFG.Titulo + "? (S/N)");
                string confirmacion;
                do
                {
                    confirmacion = Console.ReadLine();
                } while (confirmacion.ToUpperInvariant().Trim() != "S" && confirmacion.ToUpperInvariant().Trim() != "N");
                if (confirmacion.ToUpperInvariant().Trim() == "S")
                {
                    cProyectos.EliminarProyecto(seleccion);
                    Console.WriteLine("Proyecto " + opciones[seleccion].getMTFG.Titulo + " eliminado correctamente. Pulse una tecla para continuar...\n");
                    Console.ReadKey();
                }
            } 
        }
    }
}
