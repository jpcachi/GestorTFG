using System;

namespace GestorTFG
{
    public class MAlumno : MPersona
    {
        private string fechaInicio;
        public DateTime FechaInicio { get; set; }
        private string matricula;
        private MProyecto mProyecto;

        public MProyecto getProyecto
        {
            get
            {
                return mProyecto;
            }
        }

        public MAlumno(string nombre, string apellido1, string apellido2, string matricula, string fechaInicio, MProyecto mProyecto) : base(nombre, apellido1, apellido2)
        {
            this.fechaInicio = fechaInicio;
            this.matricula = matricula;
            this.mProyecto = mProyecto;
        }

        public MAlumno(string nombre, string apellido1, string apellido2, string matricula, DateTime fechaInicio, MProyecto mProyecto) : base(nombre, apellido1, apellido2)
        {
            this.FechaInicio = fechaInicio;
            this.matricula = matricula;
            this.mProyecto = mProyecto;
        }
        /// <summary>
        /// Obtiene o establece la Fecha de Inicio de un TFG por parte de un alumno
        /// </summary>
        /*public string FechaInicio
        {
            get
            {
                return fechaInicio;
            }

            set
            {
                fechaInicio = value;
            }
        }*/
        /// <summary>
        /// Obtiene o establece la Matrícula de un alumno
        /// </summary>
        public string Matricula
        {
            get
            {
                return matricula;
            }
            set
            {
                matricula = value;
            }
        }
    }
}
