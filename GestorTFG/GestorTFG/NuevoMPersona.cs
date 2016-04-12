using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class NuevoMPersona
    {
        public MAlumno CrearAlumno(string nombre, string apellido1, string apellido2, string fechaInicio, string matricula, MProyecto mProyecto)
        {
            return new MAlumno(nombre, apellido1, apellido2, fechaInicio, matricula, mProyecto);
        }

        public MProfesor CrearProfesor(string nombre, string apellido1, string apellido2, string despacho, string correo, MProyecto mProyecto)
        {
            return new MProfesor(nombre, apellido1, apellido2, despacho, correo, mProyecto);
        }
    }
}
