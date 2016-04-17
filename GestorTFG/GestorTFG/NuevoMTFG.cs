using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class NuevoMTFG
    {
        public MTFG Crear(string titulo, string descripcion, string fecha, MProyecto mProyecto)
        {
            return new MTFG(titulo, descripcion, fecha, mProyecto);
        }
    }
}
