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
        /// <summary>
        /// Lista de Proyectos e indices antes de realizar algun tipo de modificación
        /// </summary>
        public List<ProyectoIndice> ListaProyectosAntes
        {
            get
            {
                return listaProyectosAntesdeOperacion;
            }
        }
        /// <summary>
        /// Lista de Proyectos e indices después de realizar algun tipo de modificación
        /// </summary>
        public List<ProyectoIndice> ListaProyectosDespues
        {
            get
            {
                return listaProyectosDespuesdeOperacion;
            }
        }
        /// <summary>
        /// Obtiene el tipo de modificación realizada sobre la lista de proyectos
        /// </summary>
        public TOperacion TOperacion
        {
            get
            {
                return tipoOperacion;
            }
        }
        /// <summary>
        /// Crea una nueva operación
        /// </summary>
        /// <param name="tipoOperacion">Tipo de operación</param>
        /// <param name="proyectosModificados">Proyectos antes de modificar</param>
        public Operacion(TOperacion tipoOperacion, params ProyectoIndice[] proyectosModificados)
        {
            this.tipoOperacion = tipoOperacion;
            listaProyectosAntesdeOperacion = new List<ProyectoIndice>(proyectosModificados);
            listaProyectosDespuesdeOperacion = new List<ProyectoIndice>();
        }

    }
}
