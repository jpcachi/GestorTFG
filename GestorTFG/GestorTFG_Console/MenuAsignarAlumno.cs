using GestorTFG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG_Console
{
    public class MenuAsignarAlumno
    {
        private CAlumno cAlumno;
        private int seleccion;
        private MProyecto[] opciones;

        public MenuAsignarAlumno()
        {
            cAlumno = new CAlumno();
            
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Clear();
                Console.WriteLine("┌────────────────────────┐\n│     ASIGNAR ALUMNO     │\n└────────────────────────┘");
                opciones = MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados.ToArray();
                seleccion = MenuUtilidades.CrearMenu(opciones);
                if (seleccion > 0)
                {
                    Console.Clear();
                    Console.WriteLine("┌──────────────────────" + MenuUtilidades.EscribirBordes(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[seleccion - 1].getMTFG.Titulo) + "┐\n│     ASIGNAR ALUMNO A " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[seleccion - 1].getMTFG.Titulo + "     │\n└──────────────────────" + MenuUtilidades.EscribirBordes(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[seleccion - 1].getMTFG.Titulo) + "┘");
                    string[] datos = MenuUtilidades.introducirDatos(new int[] { 4}, "Nombre", "Primer apellido", "Segundo apellido", "Matrícula", "Fecha de inicio (DD/MM/YYYY)");
                    cAlumno.AsignarAlumno(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[seleccion - 1]), datos);
                    string alumno = opciones[seleccion - 1].Alumno.Nombre + " " + opciones[seleccion - 1].Alumno.PrimerApellido + " " + opciones[seleccion - 1].Alumno.SegundoApellido;
                    Console.WriteLine("Alumno " + alumno + " asignado correctamente. Pulse una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (seleccion != 0);
        }
    }
}
