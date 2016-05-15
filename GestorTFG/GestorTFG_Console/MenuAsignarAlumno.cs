﻿using GestorTFG;
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
                Console.WriteLine("ASIGNAR ALUMNO\n--------------");
                opciones = MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados.ToArray();
                seleccion = MenuUtilidades.CrearMenu(opciones);
                if (seleccion > 0)
                {
                    Console.Clear();
                    Console.WriteLine("ASIGNAR ALUMNO A " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[seleccion - 1].getMTFG.Titulo + "\n---------------------------------");
                    string[] datos = MenuUtilidades.introducirDatos("Nombre", "Primer apellido", "Segundo apellido", "Matrícula", "Fecha de inicio");
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
