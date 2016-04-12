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

        public MFinalizado getMFinalizado
        {
            get
            {
                return mFinalizado;
            }
        }

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

        public bool Finalizado
        {
            get
            {
                return finalizado;
            }
        }

        public MTFG(string titulo, string descripcion, string fecha)
        {
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.fecha = fecha;
            finalizado = false;
        }

        public void Finalizar(string defensa, string convocatoria, float nota)
        {
            mFinalizado = Instanciar.NuevoFinalizado.Crear(defensa, convocatoria, nota);
            if(mFinalizado != null)
            {
                finalizado = true;
            }
        }
    }
}
