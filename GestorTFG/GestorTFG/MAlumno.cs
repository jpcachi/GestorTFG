using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class MAlumno : MPersona
    {
        private string fechaInicio;
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

        public string FechaInicio
        {
            get
            {
                return fechaInicio;
            }

            set
            {
                fechaInicio = value;
            }
        }

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
