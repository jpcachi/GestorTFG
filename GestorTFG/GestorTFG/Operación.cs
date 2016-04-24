using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class Operacion
    {
        private TOperacion tipoOperacion;
        private List<ProyectoIndice> listaProyectosDespuesdeOperacion;
        private List<ProyectoIndice> listaProyectosAntesdeOperacion;

        public List<ProyectoIndice> ListaProyectosAntes
        {
            get
            {
                return listaProyectosAntesdeOperacion;
            }
            set
            {
                listaProyectosAntesdeOperacion = value;
            }
        }

        public List<ProyectoIndice> ListaProyectosDespues
        {
            get
            {
                return listaProyectosDespuesdeOperacion;
            }
            set
            {
                listaProyectosDespuesdeOperacion = value;
            }
        }

        public TOperacion TOperacion
        {
            get
            {
                return tipoOperacion;
            }
        }

        public Operacion(TOperacion tipoOperacion, params ProyectoIndice[] proyectosModificados)
        {

            this.tipoOperacion = tipoOperacion;
            listaProyectosAntesdeOperacion = new List<ProyectoIndice>(proyectosModificados);
            listaProyectosDespuesdeOperacion = new List<ProyectoIndice>();
        }

    }
}
