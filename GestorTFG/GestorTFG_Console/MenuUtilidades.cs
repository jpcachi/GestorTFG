using GestorTFG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GestorTFG_Console
{
    public static class MenuUtilidades
    {
        private static bool esSeleccionValida(out int seleccion, int length)
        {
            bool resul = int.TryParse(Console.ReadLine(), out seleccion);
            if (resul)
                if (seleccion >= length || seleccion < 0)
                    resul = false;
            return resul;
        }

        private static bool sonSeleccionesValidas(string entrada, ref List<int> opcionesSeleccionadas, int length)
        {
            opcionesSeleccionadas.Clear();
            if(entrada.ToUpperInvariant() == "TODOS")
            {
                for(int i = 1; i < length; i++)
                {
                    opcionesSeleccionadas.Add(i);
                }
                return true;
            }
            string[] selecciones = entrada.Split(' ');
            foreach(string seleccion in selecciones)
            {
                int numero;
                if(!int.TryParse(seleccion, out numero))
                {
                    return false;
                } else
                {
                    if(numero >= length || numero < 0)
                    {
                        return false;
                    }
                    opcionesSeleccionadas.Add(numero);
                }
            }
            return true;
        }

        public static int CrearMenu(params string[] opciones)
        {
            return CrearMenu(false, opciones);
        }

        public static int[] CrearMenuEliminar(params MProyecto[] opciones)
        {
            Console.WriteLine("Seleccione una o varias opciones (separadas por espacios):\n");
            for (int i = 0; i < opciones.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + opciones[i].getMTFG.Titulo + ";" + opciones[i].getMTFG.Descripcion);
            }
            Console.WriteLine("0. Atrás");
            List<int> selecciones = new List<int>();
            string entrada;
            do
            {
                entrada = Console.ReadLine();

            } while (!sonSeleccionesValidas(entrada, ref selecciones, opciones.Length + 1));
            selecciones.Sort();
            return selecciones.ToArray();
        }

        public static int CrearMenu(params MProyecto[] opciones)
        {
            Console.WriteLine("Seleccione una opción:\n");
            for (int i = 0; i < opciones.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + opciones[i].getMTFG.Titulo + ";" + opciones[i].getMTFG.Descripcion);
            }
            Console.WriteLine("0. Atrás");
            int seleccion = -1;
            while (!esSeleccionValida(out seleccion, opciones.Length + 1)) ;
            return seleccion;
        }

        public static int CrearMenu(bool menuPrincipal, params string[] opciones)
        {
            Console.WriteLine("Seleccione una opción:\n");
            for (int i = 1; i < opciones.Length; i++)
            {
                Console.WriteLine(i + ". " + opciones[i - 1]);
            }
            Console.WriteLine("0. " + (menuPrincipal ? "Salir" : "Atrás"));
            int seleccion = -1;
            while (!esSeleccionValida(out seleccion, opciones.Length)) ;
            return seleccion;
        }

        public static string[] introducirDatos(params string[] opciones)
        {
            string[] datos = new string[opciones.Length];
            Console.WriteLine("Introduzca los siguientes datos:\n");
            for (int i = 0; i < opciones.Length; i++)
            {
                do
                {
                    Console.WriteLine(opciones[i] + ": ");
                    datos[i] = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(datos[i]));
            }
            return datos;
        }

        public static string[] introducirDatos(int[] indiceFechas, params string[] opciones)
        {
            string[] datos = new string[opciones.Length];
            Console.WriteLine("Introduzca los siguientes datos:");
            for (int i = 0; i < opciones.Length; i++)
            {
                do
                {
                    Console.WriteLine(opciones[i] + ": ");
                    datos[i] = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(datos[i]) || (indiceFechas.Contains<int>(i) && !esFechaCorrecta(datos[i])));
            }
            return datos;
        }

        public static float IntroducirNota()
        {
            float resultado;
            bool correcto = false;
            do
            {
                correcto = float.TryParse(Console.ReadLine(), out resultado);
            } while (!correcto);
            return resultado;
        }

        public static bool esFechaCorrecta(string valor)
        {
            DateTime fecha;
            bool resul = DateTime.TryParse(valor, out fecha);
            if (!resul)
            {
                Console.WriteLine("La formato de fecha introducido no es correcto");
            }
            return resul;
        }

        public static void MostrarInformacion(int indice)
        {
            MProyecto mProyecto = MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[indice];
            Console.WriteLine("┌───────────────────────────────┐\n│     INFORMACIÓN DETALLADA     │\n└───────────────────────────────┘");
            Console.WriteLine("TÍTULO: " + mProyecto.getMTFG.Titulo +
                "\nDESCRIPCIÓN: " + mProyecto.getMTFG.Descripcion +
                "\nFECHA DE REGISTRO: " + mProyecto.getMTFG.Fecha + "\n\n┌──────────────────────────────┐\n│     INFORMACIÓN PROFESOR     │\n└──────────────────────────────┘\nNOMBRE: " + mProyecto.Profesor.Nombre +
                "\nPRIMER APELLIDO: " + mProyecto.Profesor.PrimerApellido + "\nSEGUNDO APELLIDO: " + mProyecto.Profesor.SegundoApellido + "\nCORREO ELECTRÓNICO: " + mProyecto.Profesor.Correo +
                "\nDESPACHO: " + mProyecto.Profesor.Despacho);
            if (mProyecto.Asignado)
            {
                Console.WriteLine("\n\n┌────────────────────────────┐\n│     INFORMACIÓN ALUMNO     │\n└────────────────────────────┘\nNOMBRE: " + mProyecto.Alumno.Nombre +
                "\nPRIMER APELLIDO: " + mProyecto.Alumno.PrimerApellido + "\nSEGUNDO APELLIDO: " + mProyecto.Alumno.SegundoApellido + "\nMATRÍCULA: " + mProyecto.Alumno.Matricula +
                "\nFECHA DE INICIO: " + mProyecto.Alumno.FechaInicio);
                if (mProyecto.getMTFG.Finalizado)
                {
                    Console.WriteLine("\n\n┌───────────────────────────────┐\n│     DATOS DE FINALIZACIÓN     │\n└───────────────────────────────┘\nFECHA DE LA DEFENSA: " + mProyecto.getMTFG.getMFinalizado.Defensa +
                    "\nCONVOCATORIA: " + mProyecto.getMTFG.getMFinalizado.Convocatoria + "\nCALIFICACIÓN: " + mProyecto.getMTFG.getMFinalizado.Nota);
                }
            }
            Console.WriteLine("\nPulse una tecla para continuar...");
            Console.ReadKey();
        }

        public static string EscribirBordes(string palabra)
        {
            return Regex.Replace(palabra, ".", "─") + "─────";
        }
    }
}
