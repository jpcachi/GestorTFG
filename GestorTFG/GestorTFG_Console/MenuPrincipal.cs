using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorTFG;

namespace GestorTFG_Console
{
    public class MenuPrincipal
    {
        private LeerEscribirArchivo fichero;
        private CProyectos cProyectos;
        private CAlumno cAlumno;
        private int seleccion;
        private string[] opciones = { "Añadir proyecto", "Eliminar proyecto", "Asignar Alumno", "Eliminar Alumno", "Modificar Proyecto", "Visualizar Proyectos", "Guardar Proyectos", "Salir" };
        public MenuPrincipal()
        {
            fichero = new LeerEscribirArchivo();
            fichero.AbrirLectura("Proyectos/listaTFG.txt");
            try
            {
                fichero.ImportarArchivo();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            cProyectos = new CProyectos();
            cAlumno = new CAlumno();
            do
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("GESTOR TFG\n-----------");
                seleccion = MenuUtilidades.CrearMenu(opciones);
                switch (seleccion)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Clear();
                        Console.WriteLine("AÑADIR TFG\n-----------");
                        string[] datos = MenuUtilidades.introducirDatos("Título", "Descripción", "Fecha", "Nombre del profesor", "Primer apellido del profesor", "Segundo apellido del profesor", "Correo del profesor", "Despacho del profesor");
                        cProyectos.AñadirProyecto(datos);
                        Console.WriteLine("Proyecto \"" + datos[0] + "\" añadido correctamente\n¿Desea añadir un alumno al proyecto? (S/N)");
                        string confirmacion;
                        do
                        {
                            confirmacion = Console.ReadLine();
                        } while (confirmacion.ToUpperInvariant().Trim() != "S" && confirmacion.ToUpperInvariant().Trim() != "N");
                        if (confirmacion.ToUpperInvariant().Trim() == "S")
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("ASIGNAR ALUMNO A " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Count - 1].getMTFG.Titulo + "\n---------------------------------");
                            datos = MenuUtilidades.introducirDatos("Nombre", "Primer apellido", "Segundo apellido", "Matrícula", "Fecha de inicio");
                            cAlumno.AsignarAlumno(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Count - 1, datos);
                            Console.WriteLine("Alumno \"" + datos[0] + "\" asignado correctamente. Pulse una tecla para continuar...\n");
                            Console.ReadKey();
                        }
                        break;
                    case 1:
                        new MenuEliminarProyecto();
                        break;
                    case 2:
                        new MenuAsignarAlumno();
                        break;
                    case 3:
                        new MenuEliminarAlumno();
                        break;
                    case 4:
                        new MenuModificar();
                        break;
                    case 5:
                        new MenuVisualizar();
                        break;
                    case 6:
                        fichero.CerrarLectura();
                        fichero.AbrirEscritura("Proyectos/listaTFG.txt");
                        Console.WriteLine("Espere mientras se guardan los datos de proyecto...");
                        fichero.ExportarArchivo();
                        Console.WriteLine("Lista de proyectos guardada con éxito. Pulse una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 7:
                        fichero.CerrarFichero();
                        Console.WriteLine("Cerrando...");
                        break;
                }
            } while (seleccion != opciones.Length - 1);
        }
    }
}
