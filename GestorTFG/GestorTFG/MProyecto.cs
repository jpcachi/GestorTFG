using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class MProyecto
    {
        private MTFG mTFG;
        private MPersona profesor, alumno;
        private bool asignado;

        public MTFG getMTFG
        {
            get
            {
                return mTFG;
            }
        }

        public MProfesor Profesor
        {
            get
            {
                return (MProfesor) profesor;
            }
        }

        public MAlumno Alumno
        {
            get
            {
                return (MAlumno) alumno;
            }
        }

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
            mTFG = Instanciar.NuevoTFG.Crear(titulo, descripcion, fecha);
            profesor = Instanciar.NuevaPersona.CrearProfesor(nombre, apellido1, apellido2, despacho, correo, this);
        }

        public void AsignarAlumno(string nombre, string apellido1, string apellido2, string fechaInicio, string matricula)
        {
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados.Remove(this);
            alumno = Instanciar.NuevaPersona.CrearAlumno(nombre, apellido1, apellido2, fechaInicio, matricula, this);
            if(alumno != null)
            {
                asignado = true;
            }
        }

        public void EliminarAlumno()
        {
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados.Add(this);
            asignado = false;
            alumno = null;
        }

        public void Borrar()
        {
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Remove(this);
            if(!asignado)
                MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados.Remove(this);
            else if (mTFG.Finalizado)
                MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados.Remove(this);
        }

    }
}
