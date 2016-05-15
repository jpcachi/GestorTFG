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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("ELIMINAR ALUMNO\n----------------");
            List<MProyecto> proyectosAsignados = new List<MProyecto>();
            foreach(MProyecto proyecto in MListaProyectos.getMListaProyectos.getMProyectos.getProyectos)
            {
                if (proyecto.Asignado)
                    proyectosAsignados.Add(proyecto);
            }
            opciones = proyectosAsignados.ToArray();
            do
            {
                seleccion = MenuUtilidades.CrearMenu(opciones);
                if (seleccion < opciones.Length)
                {
                    string alumno = opciones[seleccion].Alumno.Nombre + " " + opciones[seleccion].Alumno.PrimerApellido + " " + opciones[seleccion].Alumno.SegundoApellido;
                    Console.WriteLine("¿Está seguro de que quiere eliminar al alumno " + alumno + " del proyecto " + opciones[seleccion].getMTFG.Titulo + "? (S/N)");
                    string confirmacion;
                    do
                    {
                        confirmacion = Console.ReadLine();
                    } while (confirmacion.ToUpperInvariant().Trim() != "S" && confirmacion.ToUpperInvariant().Trim() != "N");
                    if (confirmacion.ToUpperInvariant().Trim() == "S")
                    {
                        cAlumno.EliminarAlumno(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(opciones[seleccion]));
                        Console.WriteLine("Alumno " + alumno + " eliminado correctamente. Pulse una tecla para continuar...");
                        Console.ReadKey();
                    }
                }
            } while (seleccion != opciones.Length);
        }
    }
}
