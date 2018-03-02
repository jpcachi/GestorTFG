using GestorTFG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG_Console
{
    public class MenuModificar
    {
        private CProyectos cProyectos;
        private int seleccion;
        private MProyecto[] opciones;

        public MenuModificar()
        {
            cProyectos = new CProyectos();
            Console.ForegroundColor = ConsoleColor.Cyan;
            opciones = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.ToArray();
            do
            {
                Console.Clear();
                Console.WriteLine("┌────────────────────────────┐\n│     MODIFICAR PROYECTO     │\n└────────────────────────────┘");
                seleccion = MenuUtilidades.CrearMenu(opciones);
                if (seleccion > 0)
                {
                    new MenuModificarProyecto(seleccion - 1, cProyectos);   
                }
            } while (seleccion != 0);
        }

        private class MenuModificarAlumno
        {
            private int seleccion;
            private int indiceProyecto;
            private CProyectos cProyectos;
            string[] opciones = { "Nombre", "Primer apellido", "Segundo apellido", "Matrícula", "Fecha de inicio", "Salir" };
            public MenuModificarAlumno(int indice, CProyectos cProyectos)
            {
                this.cProyectos = cProyectos;
                indiceProyecto = indice;
                do
                {
                    Console.Clear();
                    Console.WriteLine("┌──────────────────────────┐\n│     MODIFICAR ALUMNO     │\n└──────────────────────────┘");
                    seleccion = MenuUtilidades.CrearMenu(opciones);
                    switch (seleccion - 1)
                    {
                        case 0:
                            Console.WriteLine("Nombre actual: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].Alumno.Nombre);
                            string[] nombre = MenuUtilidades.introducirDatos("Nuevo nombre");
                            cProyectos.ModificarProyecto(3, nombre[0], indiceProyecto);
                            Console.WriteLine("Nombre modificado correctamente. Pulse una tecla para continuar...\n");
                            Console.ReadKey();
                            break;
                        case 1:
                            Console.WriteLine("Primer apellido actual: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].Alumno.PrimerApellido);
                            string[] primerApellido = MenuUtilidades.introducirDatos("Nuevo primer apellido");
                            cProyectos.ModificarProyecto(4, primerApellido[0], indiceProyecto);
                            Console.WriteLine("Primer apellido modificado correctamente. Pulse una tecla para continuar...\n");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine("Segundo apellido actual: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].Alumno.SegundoApellido);
                            string[] segundoApellido = MenuUtilidades.introducirDatos("Nuevo segundo apellido");
                            cProyectos.ModificarProyecto(5, segundoApellido[0], indiceProyecto);
                            Console.WriteLine("Segundo apellido modificado correctamente. Pulse una tecla para continuar...\n");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.WriteLine("Matrícula actual: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].Alumno.Matricula);
                            string[] matricula = MenuUtilidades.introducirDatos("Nueva matrícula");
                            cProyectos.ModificarProyecto(6, matricula[0], indiceProyecto);
                            Console.WriteLine("Matrícula modificada correctamente. Pulse una tecla para continuar...\n");
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.WriteLine("Fecha de inicio actual: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].Alumno.FechaInicio.Date.ToShortDateString());
                            string[] fecha = MenuUtilidades.introducirDatos(new int[] { 0 }, "Nueva fecha de inicio");
                            cProyectos.ModificarProyecto(6, fecha[0], indiceProyecto);
                            Console.WriteLine("Fecha de inicio modificada correctamente. Pulse una tecla para continuar...\n");
                            Console.ReadKey();
                            break;
                    }
                } while (seleccion != 0);
            }
        }

        private class MenuModificarProfesor
        {
            private int seleccion;
            private int indiceProyecto;
            private CProyectos cProyectos;
            string[] opciones = { "Nombre", "Primer apellido", "Segundo apellido", "Correo electrónico", "Despacho", "Salir" };
            public MenuModificarProfesor(int indice, CProyectos cProyectos)
            {
                this.cProyectos = cProyectos;
                indiceProyecto = indice;
                do
                {
                    Console.Clear();
                    Console.WriteLine("┌────────────────────────────┐\n│     MODIFICAR PROFESOR     │\n└────────────────────────────┘");
                    seleccion = MenuUtilidades.CrearMenu(opciones);
                    switch (seleccion - 1)
                    {
                        case 0:
                            Console.WriteLine("Nombre actual: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].Profesor.Nombre);
                            string[] nombre = MenuUtilidades.introducirDatos("Nuevo nombre");
                            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].Profesor.Nombre = nombre[0];
                            Console.WriteLine("Nombre modificado correctamente. Pulse una tecla para continuar...\n");
                            Console.ReadKey();
                            break;
                        case 1:
                            Console.WriteLine("Primer apellido actual: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].Profesor.PrimerApellido);
                            string[] primerApellido = MenuUtilidades.introducirDatos("Nuevo primer apellido");
                            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].Profesor.PrimerApellido = primerApellido[0];
                            Console.WriteLine("Primer apellido modificado correctamente. Pulse una tecla para continuar...\n");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine("Segundo apellido actual: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].Profesor.SegundoApellido);
                            string[] segundoApellido = MenuUtilidades.introducirDatos("Nuevo segundo apellido");
                            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].Profesor.SegundoApellido = segundoApellido[0];
                            Console.WriteLine("Segundo apellido modificado correctamente. Pulse una tecla para continuar...\n");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.WriteLine("Correo electrónico actual: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].Profesor.Correo);
                            string[] correo = MenuUtilidades.introducirDatos("Nuevo correo electrónico");
                            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].Profesor.Correo = correo[0];
                            Console.WriteLine("Correo electrónico modificado correctamente. Pulse una tecla para continuar...\n");
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.WriteLine("Despacho actual: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].Profesor.Despacho);
                            string[] despacho = MenuUtilidades.introducirDatos("Nuevo despacho");
                            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].Profesor.Despacho = despacho[0];
                            Console.WriteLine("Desacho modificado correctamente. Pulse una tecla para continuar...\n");
                            Console.ReadKey();
                            break;
                    }
                } while (seleccion != 0);
            }
        }

        public class MenuModificarProyecto
        {
            private int seleccion;
            private int indiceProyecto;
            private CProyectos cProyectos;
            string[] opciones;
            public MenuModificarProyecto(int indice, CProyectos cProyectos)
            {
                this.cProyectos = cProyectos;
                indiceProyecto = indice;
                if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].Asignado)
                {
                    if (MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice].getMTFG.Finalizado)
                    {
                        opciones = new string[] { "Descripción", "Fecha de registro", "Profesor", "Alumno", "Fecha de defensa", "Convocatoria", "Nota", "Salir" };
                    } else
                    {
                        opciones = new string[] { "Título", "Descripción", "Fecha de registro", "Profesor", "Alumno", "Salir" };
                    }
                } else
                {
                    opciones = new string[] { "Título", "Descripción", "Fecha de registro", "Profesor", "Salir" };
                }
                do
                {
                    Console.Clear();
                    Console.WriteLine("┌───────────────" + MenuUtilidades.EscribirBordes(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].getMTFG.Titulo) + "┐\n│     MODIFICAR " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].getMTFG.Titulo + "     │\n└───────────────" + MenuUtilidades.EscribirBordes(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].getMTFG.Titulo) + "┘");
                    seleccion = MenuUtilidades.CrearMenu(opciones);
                    switch (seleccion - 1)
                    {
                        case 0:
                            Console.WriteLine("Título actual: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].getMTFG.Titulo);
                            string[] titulo = MenuUtilidades.introducirDatos("Nuevo título");
                            cProyectos.ModificarProyecto(0, titulo[0], indiceProyecto);
                            Console.WriteLine("Título modificado correctamente. Pulse una tecla para continuar...\n");
                            Console.ReadKey();
                            break;
                        case 1:
                            Console.WriteLine("Descripción actual: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].getMTFG.Descripcion);
                            string[] desc = MenuUtilidades.introducirDatos("Nueva descripción");
                            cProyectos.ModificarProyecto(1, desc[0], indiceProyecto);
                            Console.WriteLine("Descripción modificada correctamente. Pulse una tecla para continuar...\n");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine("Fecha de registro actual: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].getMTFG.Fecha.Date.ToShortDateString());
                            string[] fecha = MenuUtilidades.introducirDatos(new int[] { 0 }, "Nueva fecha de registro");
                            cProyectos.ModificarProyecto(2, fecha[0], indiceProyecto);
                            Console.WriteLine("Fecha de registro modificada correctamente. Pulse una tecla para continuar...\n");
                            Console.ReadKey();
                            break;
                        case 3:
                            new MenuModificarProfesor(indiceProyecto, cProyectos);
                            break;
                        case 4:
                            //if (seleccion != opciones.Length - 1)
                            //{
                                new MenuModificarAlumno(indiceProyecto, cProyectos);
                            //}
                            break;
                        case 5:
                            //if (seleccion != opciones.Length - 1)
                            //{
                                Console.WriteLine("Fecha de defensa actual: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].getMTFG.getMFinalizado.Defensa.Date.ToShortDateString());
                                string[] defensa = MenuUtilidades.introducirDatos(new int[] { 0 }, "Nueva fecha de defensa");
                                cProyectos.ModificarProyecto(8, defensa[0], indiceProyecto);
                                Console.WriteLine("Fecha de defensa modificada correctamente. Pulse una tecla para continuar...\n");
                                Console.ReadKey();
                            //}
                            break;
                        case 6:
                            Console.WriteLine("Convocatoria actual: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].getMTFG.getMFinalizado.Convocatoria);
                            string[] conv = MenuUtilidades.introducirDatos("Nueva convocatoria");
                            cProyectos.ModificarProyecto(9, conv[0], indiceProyecto);
                            Console.WriteLine("Convocatoria modificada correctamente. Pulse una tecla para continuar...\n");
                            Console.ReadKey();
                            break;
                        case 7:
                            Console.WriteLine("Calificación actual: " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indiceProyecto].getMTFG.getMFinalizado.Nota);
                            Console.WriteLine("Introduzca los siguientes datos:\nNueva calificación");
                            float nota = MenuUtilidades.IntroducirNota();
                            cProyectos.ModificarProyecto(10, nota.ToString(), indiceProyecto);
                            Console.WriteLine("Calificación modificada correctamente. Pulse una tecla para continuar...\n");
                            Console.ReadKey();
                            break;
                    }
                } while (seleccion != 0);
            }
        }
    }
}
