using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class Instanciar
    {
        private static NuevoMFinalizado nuevoMFinalizado = new NuevoMFinalizado();
        private static NuevoMPersona nuevoMPersona = new NuevoMPersona();
        private static NuevoMProyecto nuevoMProyecto = new NuevoMProyecto();
        private static NuevoMTFG nuevoTFG = new NuevoMTFG();

        public static NuevoMFinalizado NuevoFinalizado
        {
            get
            {
                return nuevoMFinalizado;
            }
        }

        public static NuevoMPersona NuevaPersona
        {
            get
            {
                return nuevoMPersona;
            }
        }

        public static NuevoMProyecto NuevoProyecto
        {
            get
            {
                return nuevoMProyecto;
            }
        }

        public static NuevoMTFG NuevoTFG
        {
            get
            {
                return nuevoTFG;
            }
        }


    }
}
