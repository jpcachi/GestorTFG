using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class MTFG
    {
        private string titulo;
        private string descripcion;
        private string fecha;
        private bool finalizado;
        private MFinalizado mFinalizado;
        private MProyecto mProyecto;
        /// <summary>
        /// Obtiene la información sobre el estado finalizado del TFG. Usar primero la propiedad Finalizado para comprobar el estado del TFG
        /// </summary>
        public MFinalizado getMFinalizado
        {
            get
            {
                return mFinalizado;
            }
        }
        /// <summary>
        /// Obtiene el titulo del TFG
        /// </summary>
        public string Titulo
        {
            get
            {
                return titulo;
            }

            set
            {
                titulo = value;
            }
        }
        /// <summary>
        /// Obtiene la descripción del TFG
        /// </summary>
        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }
        /// <summary>
        /// Obtiene la fecha en el que el TFG fue propuesto
        /// </summary>
        public string Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }
        /// <summary>
        /// Propiedad que indica si el TFG está finalizado o no
        /// </summary>
        public bool Finalizado
        {
            get
            {
                return finalizado;
            }
        }

        public MTFG(string titulo, string descripcion, string fecha, MProyecto mProyecto)
        {
            this.mProyecto = mProyecto;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.fecha = fecha;
            finalizado = false;
        }
        /// <summary>
        /// Finaliza un TFG con los siguientes datos
        /// </summary>
        /// <param name="defensa">Fecha de defensa del TFG</param>
        /// <param name="convocatoria">Mes de la convocatoria del TFG</param>
        /// <param name="nota">Calificación final del TFG</param>
        public void Finalizar(string defensa, string convocatoria, float nota)
        {
            mFinalizado = Instanciar.NuevoFinalizado.Crear(defensa, convocatoria, nota);
            //if(mFinalizado != null)
            //{
            finalizado = true;
            MListaProyectos.getMListaProyectos.getMProyectos.ReorganizarListaFinalizados();
                
            //}
        }
        /// <summary>
        /// Finaliza un TFG con los siguientes datos
        /// </summary>
        /// <param name="mFinalizado">Datos de finalización del TFG</param>
        public void Finalizar(MFinalizado mFinalizado)
        {
            this.mFinalizado = mFinalizado;
            if (mFinalizado != null)
            {
                MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados.Add(mProyecto);
                finalizado = true;
            }
        }
        /// <summary>
        /// Quita la condición de finalizado a un TFG
        /// </summary>
        public void QuitarFinalizado()
        {
            mFinalizado = null;
            finalizado = false;
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados.Remove(mProyecto);
        }
    }
}
