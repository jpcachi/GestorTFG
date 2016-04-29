using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class CAlumno
    {
        /// <summary>
        /// Elimina un alumno de un proyecto desde la interfaz gráfica
        /// </summary>
        /// <param name="index"></param>
        public void EliminarAlumno(int index)
        {
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[index].EliminarAlumno();
        }
        /// <summary>
        /// Asigna un alumno de un proyecto desde la interfaz gráfica
        /// </summary>
        /// <param name="index"></param>
        public void AsignarAlumno(string nombre, string apellido1, string apellido2, string matricula, string fechaInicio, int index)
        {
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[index].AsignarAlumno(nombre, apellido1, apellido2, matricula, fechaInicio);
        }
    }
}
