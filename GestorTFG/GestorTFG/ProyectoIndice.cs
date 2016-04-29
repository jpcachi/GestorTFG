using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    struct ProyectoIndice
    {
        private MProyecto proyecto;
        private int indice;

        public MProyecto Proyecto
        {
            get
            {
                return proyecto;
            }
            set
            {
                proyecto = value;
            }
        }

        public int Indice
        {
            get
            {
                return indice;

            }
            set
            {
                indice = value;
            }
        }
        /// <summary>
        /// Crea una estructura del tipo ProyectoIndice.
        /// Dicha estructura encapsula un Proyecto y su índice correspondiente en la lista
        /// </summary>
        /// <param name="proyecto"></param>
        /// <param name="indice"></param>
        public ProyectoIndice(MProyecto proyecto, int indice)
        {
            this.proyecto = proyecto;
            this.indice = indice;
        }
    }
}
