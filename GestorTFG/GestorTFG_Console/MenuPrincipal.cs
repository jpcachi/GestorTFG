using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorTFG;
using System.IO;

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
            Directory.CreateDirectory("Proyectos");
            FileStream aux = new FileStream("Proyectos/listaTFG.txt", FileMode.OpenOrCreate);
            aux.Close();
            fichero = new LeerEscribirArchivo();
            fichero.AbrirLectura("Proyectos/listaTFG.txt");
            try
            {
                fichero.ImportarArchivo();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            finally
            {
                fichero.CerrarLectura();
            }
            cProyectos = new CProyectos();
            cAlumno = new CAlumno();
            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.WriteLine("┌────────────────────┐\n│     GESTOR TFG     │\n└────────────────────┘");
                seleccion = MenuUtilidades.CrearMenu(true, opciones);
                switch (seleccion - 1)
                {
                    case -1:
                        fichero.CerrarFichero();
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Clear();
                        Console.WriteLine("┌─────────────────────────┐\n│     AÑADIR PROYECTO     │\n└─────────────────────────┘");
                        string[] datos = MenuUtilidades.introducirDatos(new int[] { 2},"Título", "Descripción", "Fecha de registro (DD/MM/YYYY)", "Nombre del profesor", "Primer apellido del profesor", "Segundo apellido del profesor", "Correo del profesor", "Despacho del profesor");
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
                            Console.WriteLine("┌──────────────────────" + MenuUtilidades.EscribirBordes(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Count - 1].getMTFG.Titulo) + "┐\n│     ASIGNAR ALUMNO A " + MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Count - 1].getMTFG.Titulo + "     │\n└──────────────────────" + MenuUtilidades.EscribirBordes(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Count - 1].getMTFG.Titulo) + "┘");
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
                        fichero.AbrirEscritura("Proyectos/listaTFG.txt");
                        Console.WriteLine("Espere mientras se guardan los datos de proyecto...");
                        fichero.ExportarArchivo();
                        fichero.CerrarEscritura();
                        Console.WriteLine("Lista de proyectos guardada con éxito. Pulse una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            } while (seleccion != 0);
        }
    }
}
