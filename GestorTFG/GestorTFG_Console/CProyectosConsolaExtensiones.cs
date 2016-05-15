using GestorTFG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG_Console
{
    public static class ExtensionesControlador
    {
        public static void AñadirProyecto(this CProyectos cProyectos, params string[] datos)
        {
            cProyectos.AñadirProyecto(datos[0], datos[1], datos[2], datos[3], datos[4], datos[5], datos[6], datos[7]);
        }

        public static void AsignarAlumno(this CAlumno cAlumno, int index, params string[] datos)
        {
            cAlumno.AsignarAlumno(datos[0], datos[1], datos[2], datos[3], datos[4], index);
        }
    }
}
