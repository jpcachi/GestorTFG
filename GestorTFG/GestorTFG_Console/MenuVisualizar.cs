using GestorTFG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG_Console
{
    public class MenuVisualizar
    {
        private int seleccion;
        private string[] opciones = { "Todos", "No asignados", "Salir" };

        public MenuVisualizar()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine("VISUALIZAR PROYECTOS\n--------------------------------------------------------------------------------");
                seleccion = MenuUtilidades.CrearMenu(opciones);
                switch (seleccion - 1)
                {
                    case 0:
                        new MenuVisualizarTodos();
                        break;
                    case 1:
                        new MenuVisualizarNoAsignados();
                        break;
                }

            } while(seleccion != 0);
        }



        private class MenuVisualizarTodos
        {
            private int seleccion;
            private MProyecto[] opciones;

            public MenuVisualizarTodos()
            {
                Console.Clear();
                Console.WriteLine("VISUALIZAR TODOS\n--------------------------------------------------------------------------------");
                opciones = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.ToArray();
                do
                {
                    seleccion = MenuUtilidades.CrearMenu(opciones);
                    if (seleccion > 0)
                    {
                        string[] _opciones = { "Mostrar información detallada", "Salir" };
                        int _seleccion;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine(opciones[seleccion - 1].getMTFG.Titulo + "\n--------------------------------------------------------------------------------");
                            _seleccion = MenuUtilidades.CrearMenu(_opciones);
                            if (_seleccion == 1)
                            {
                                Console.Clear();
                                MenuUtilidades.MostrarInformacion(seleccion - 1);
                            }
                        } while (_seleccion != _opciones.Length - 1);
                    }
                } while (seleccion != 0);
            }
        }

        private class MenuVisualizarNoAsignados
        {
            private CAlumno cAlumno;
            private int seleccion;
            private MProyecto[] opciones;

            public MenuVisualizarNoAsignados()
            {
                cAlumno = new CAlumno();
                
                do
                {
                    Console.Clear();
                    Console.WriteLine("VISUALIZAR NO ASIGNADOS\n--------------------------------------------------------------------------------");
                    opciones = MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados.ToArray();
                    seleccion = MenuUtilidades.CrearMenu(opciones);
                    if (seleccion > 0)
                    {
                        string[] _opciones = { "Mostrar información detallada", "Asignar alumno", "Salir" };
                        int _seleccion;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[seleccion - 1].getMTFG.Titulo + "\n--------------------------------------------------------------------------------");
                            _seleccion = MenuUtilidades.CrearMenu(_opciones);
                            if (_seleccion == 1)
                            {
                                MenuUtilidades.MostrarInformacion(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(opciones[seleccion - 1]));
                            } else if(_seleccion == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Clear();
                                Console.WriteLine("ASIGNAR ALUMNO A " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[seleccion - 1].getMTFG.Titulo + "\n--------------------------------------------------------------------------------");
                                string[] datos = MenuUtilidades.introducirDatos("Nombre", "Primer apellido", "Segundo apellido", "Matrícula", "Fecha de inicio");
                                cAlumno.AsignarAlumno(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.IndexOf(MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados[seleccion - 1]), datos);
                                string alumno = opciones[seleccion - 1].Alumno.Nombre + " " + opciones[seleccion - 1].Alumno.PrimerApellido + " " + opciones[seleccion - 1].Alumno.SegundoApellido;
                                Console.WriteLine("Alumno " + alumno + " asignado correctamente. Pulse una tecla para continuar...");
                                Console.ReadKey();
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            }
                        } while (_seleccion != 0);
                        if (_seleccion == 2)
                            break;
                    }
                } while (seleccion != 0);
            }
        }
    }
}
