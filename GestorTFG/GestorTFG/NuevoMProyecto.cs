using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class NuevoMProyecto
    {
        public MProyecto Crear(string titulo, string descripcion, string fecha, string nombre, string apellido1, string apellido2, string despacho, string correo)
        {
            return new MProyecto(titulo, descripcion, fecha, nombre, apellido1, apellido2, despacho, correo);
        }
    }
}
