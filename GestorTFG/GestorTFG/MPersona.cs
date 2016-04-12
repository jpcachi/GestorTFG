using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    abstract class MPersona
    {
        protected string nombre;
        protected string apellido1;
        protected string apellido2;

        //public virtual void Borrar();
        protected MPersona(string nombre, string apellido1, string apellido2)
        {
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
        }
        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string PrimerApellido
        {
            get
            {
                return apellido1;
            }

            set
            {
                apellido1 = value;
            }
        }

        public string SegundoApellido
        {
            get
            {
                return apellido2;
            }

            set
            {
                apellido2 = value;
            }
        }
    }
}
