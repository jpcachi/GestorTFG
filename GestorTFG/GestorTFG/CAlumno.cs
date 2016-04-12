using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class CAlumno
    {

        public void EliminarAlumno(int index)
        {
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[index].EliminarAlumno();
        }

        public void AsignarAlumno(string nombre, string apellido1, string apellido2, string matricula, string fechaInicio, int index)
        {
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[index].AsignarAlumno(nombre, apellido1, apellido2, matricula, fechaInicio);
        }
    }
}
