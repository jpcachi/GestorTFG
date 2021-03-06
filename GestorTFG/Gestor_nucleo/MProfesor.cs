﻿namespace GestorTFG
{
    public class MProfesor : MPersona
    {
        private string despacho;
        private string correo;
        private MProyecto mProyecto;
        
        public MProfesor(string nombre, string apellido1, string apellido2, string despacho, string correo, MProyecto mProyecto) : base (nombre, apellido1, apellido2)
        {
            this.despacho = despacho;
            this.correo = correo;
            this.mProyecto = mProyecto;
        }
        /// <summary>
        /// Obtiene o establece el Despacho de un profesor
        /// </summary>
        public string Despacho
        {
            get
            {
                return despacho;
            }

            set
            {
                despacho = value;
            }
        }
        /// <summary>
        /// Obtiene o establece el Correo Electrónico de un profesor
        /// </summary>
        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
            }
        }

    }
}
