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
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.WriteLine("ASIGNAR ALUMNO\n--------------");
            opciones = MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados.ToArray();
            do
            {
                seleccion = MenuUtilidades.CrearMenu(opciones);
                if (seleccion < opciones.Length)
                {
                    Console.Clear();
                    Console.WriteLine("ASIGNAR ALUMNO A " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[seleccion].getMTFG.Titulo + "\n---------------------------------");
                    string[] datos = MenuUtilidades.introducirDatos("Nombre", "Primer apellido", "Segundo apellido", "Matrícula", "Fecha de inicio");
                    cAlumno.AsignarAlumno(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[seleccion]), datos);
                    string alumno = opciones[seleccion].Alumno.Nombre + " " + opciones[seleccion].Alumno.PrimerApellido + " " + opciones[seleccion].Alumno.SegundoApellido;
                    Console.WriteLine("Alumno " + alumno + " asignado correctamente. Pulse una tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (seleccion != opciones.Length);
        }
    }
}
