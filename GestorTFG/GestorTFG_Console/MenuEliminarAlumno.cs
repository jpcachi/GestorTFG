using GestorTFG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG_Console
{
    class MenuEliminarAlumno
    {
        private CAlumno cAlumno;
        private int seleccion;
        private MProyecto[] opciones;

        public MenuEliminarAlumno()
        {
            cAlumno = new CAlumno();                   
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                List<MProyecto> proyectosAsignados = new List<MProyecto>();
                Console.WriteLine("┌─────────────────────────┐\n│     ELIMINAR ALUMNO     │\n└─────────────────────────┘");
                foreach (MProyecto proyecto in MListaProyectos.getMListaProyectos.getMProyectos.getProyectos)
                {
                    if (proyecto.Asignado)
                        proyectosAsignados.Add(proyecto);
                }
                opciones = proyectosAsignados.ToArray();
                seleccion = MenuUtilidades.CrearMenu(opciones);
                if (seleccion > 0)
                {
                    string alumno = opciones[seleccion - 1].Alumno.Nombre + " " + opciones[seleccion - 1].Alumno.PrimerApellido + " " + opciones[seleccion - 1].Alumno.SegundoApellido;
                    Console.WriteLine("¿Está seguro de que quiere eliminar al alumno " + alumno + " del proyecto " + opciones[seleccion - 1].getMTFG.Titulo + "? (S/N)");
                    string confirmacion;
                    do
                    {
                        confirmacion = Console.ReadLine();
                    } while (confirmacion.ToUpperInvariant().Trim() != "S" && confirmacion.ToUpperInvariant().Trim() != "N");
                    if (confirmacion.ToUpperInvariant().Trim() == "S")
                    {
                        cAlumno.EliminarAlumno(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(opciones[seleccion - 1]));
                        Console.WriteLine("Alumno " + alumno + " eliminado correctamente. Pulse una tecla para continuar...");
                        Console.ReadKey();
                    }
                }
            } while (seleccion != 0);
        }
    }
}
