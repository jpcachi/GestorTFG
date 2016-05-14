namespace GestorTFG
{
    class MProyecto
    {
        private MTFG mTFG;
        private MPersona profesor, alumno;
        private bool asignado;
        /// <summary>
        /// Obtiene los datos referentes al TFG
        /// </summary>
        public MTFG getMTFG
        {
            get
            {
                return mTFG;
            }
        }
        /// <summary>
        /// Obtiene los datos referentes al Profesor encargado del proyecto
        /// </summary>
        public MProfesor Profesor
        {
            get
            {
                return profesor as MProfesor;
            }
        }
        /// <summary>
        /// Obtiene los datos del alumno asignado
        /// </summary>
        public MAlumno Alumno
        {
            get
            {
                return alumno as MAlumno;
            }
        }
        /// <summary>
        /// Indica si el proyecto tiene un alumno asignado o no
        /// </summary>
        public bool Asignado
        {
            get
            {
                return asignado;
            }
        }

        public MProyecto(string titulo, string descripcion, string fecha, string nombre, string apellido1, string apellido2, string despacho, string correo)
        {
            asignado = false;
            mTFG = Instanciar.NuevoTFG.Crear(titulo, descripcion, fecha, this);
            profesor = Instanciar.NuevaPersona.CrearProfesor(nombre, apellido1, apellido2, despacho, correo, this);
        }

        /// <summary>
        /// Asigna un alumno al proyecto con los siguientes datos
        /// </summary>
        public void AsignarAlumno(string nombre, string apellido1, string apellido2, string matricula, string fechaInicio)
        {
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados.Remove(this);
            alumno = Instanciar.NuevaPersona.CrearAlumno(nombre, apellido1, apellido2, matricula, fechaInicio, this);
            if(alumno != null)
            {
                asignado = true;
            }
        }

        /// <summary>
        /// Asigna un alumno con los siguientes datos
        /// </summary>
        /// <param name="mAlumno">Alumno a asignar</param>
        public void AsignarAlumno(MAlumno mAlumno)
        {
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados.Remove(this);
            alumno = mAlumno;
            if (alumno != null)
            {
                asignado = true;
            }
        }
        /// <summary>
        /// Elimina al alumno y deja el proyecto sin asignar
        /// </summary>
        public void EliminarAlumno()
        {
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados.Add(this);
            asignado = false;
            alumno = null;
        }
        /// <summary>
        /// Borra el proyecto de las listas de proyectos correspondientes
        /// </summary>
        public void Borrar()
        {
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Remove(this);
            if(!asignado)
                MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados.Remove(this);
            else if (mTFG.Finalizado)
                MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados.Remove(this);
        }
        /// <summary>
        /// Devuelve una copia del proyecto para evitar conflictos de referencia
        /// </summary>
        /// <returns>Devuelve un elemento MProyecto de las mismas características que el proyecto actual</returns>
        public MProyecto Copiar()
        {
            MProfesor profesor = this.profesor as MProfesor;
            MAlumno alumno = this.alumno as MAlumno;
            MProyecto resul = new MProyecto(mTFG.Titulo, mTFG.Descripcion, mTFG.Fecha, profesor.Nombre, profesor.PrimerApellido, profesor.SegundoApellido, profesor.Despacho, profesor.Correo);
            if (asignado)
            {
                resul.AsignarAlumno(alumno.Nombre, alumno.PrimerApellido, alumno.SegundoApellido, alumno.Matricula, alumno.FechaInicio);
                if(mTFG.Finalizado)
                {
                    resul.mTFG.Finalizar(mTFG.getMFinalizado.Defensa, mTFG.getMFinalizado.Convocatoria, mTFG.getMFinalizado.Nota);
                }
            }
            return resul;
        }
    }
}
