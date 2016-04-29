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
        /// <summary>
        /// Patrón de fábrica para instanciar datos de finalización de un TFG
        /// </summary>
        public static NuevoMFinalizado NuevoFinalizado
        {
            get
            {
                return nuevoMFinalizado;
            }
        }
        /// <summary>
        /// Patrón de fábrica para instanciar una nueva persona
        /// </summary>
        public static NuevoMPersona NuevaPersona
        {
            get
            {
                return nuevoMPersona;
            }
        }
        /// <summary>
        /// Patrón de fábrica para instanciar un nuevo proyecto
        /// </summary>
        public static NuevoMProyecto NuevoProyecto
        {
            get
            {
                return nuevoMProyecto;
            }
        }
        /// <summary>
        /// Patrón de fábrica para instanciar un nuevo TFG
        /// </summary>
        public static NuevoMTFG NuevoTFG
        {
            get
            {
                return nuevoTFG;
            }
        }


    }
}
