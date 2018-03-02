using System;

namespace GestorTFG
{
    public class NuevoMPersona
    {
        /// <summary>
        /// Método encargado de devolver una nueva instancia de tipo Alumno
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido1"></param>
        /// <param name="apellido2"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="matricula"></param>
        /// <param name="mProyecto"></param>
        /// <returns></returns>
        public MAlumno CrearAlumno(string nombre, string apellido1, string apellido2, string matricula, string fechaInicio, MProyecto mProyecto)
        {
            return new MAlumno(nombre, apellido1, apellido2, matricula, fechaInicio, mProyecto);
        }

        public MAlumno CrearAlumno(string nombre, string apellido1, string apellido2, string matricula, DateTime fechaInicio, MProyecto mProyecto)
        {
            return new MAlumno(nombre, apellido1, apellido2, matricula, fechaInicio, mProyecto);
        }
        /// <summary>
        /// Método encargado de devolver una nueva instancia del tipo Profesor
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido1"></param>
        /// <param name="apellido2"></param>
        /// <param name="despacho"></param>
        /// <param name="correo"></param>
        /// <param name="mProyecto"></param>
        /// <returns></returns>
        public MProfesor CrearProfesor(string nombre, string apellido1, string apellido2, string despacho, string correo, MProyecto mProyecto)
        {
            return new MProfesor(nombre, apellido1, apellido2, despacho, correo, mProyecto);
        }
    }
}
