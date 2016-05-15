namespace GestorTFG
{
    public abstract class MPersona
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
        /// <summary>
        /// Obtiene o establece el nombre de una persona
        /// </summary>
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
        /// <summary>
        /// Obtiene o establece el primer apellido de una persona
        /// </summary>
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
        /// <summary>
        /// Obtiene o establece el segundo apellido de una persona
        /// </summary>
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
