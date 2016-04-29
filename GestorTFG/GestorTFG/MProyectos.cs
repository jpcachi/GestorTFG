using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class MProyectos
    {
        private List<MProyecto> mProyectos;
        private List<MProyecto> mProyectosNoAsignados;
        private List<MProyecto> mProyectosFinalizados;
        private List<MProyecto> mProyectosBusqueda;

        private List<List<MProyecto>> proyectos;
        /// <summary>
        /// Obtiene un acceso directo a una determinada lista de proyectos
        /// </summary>
        public List<List<MProyecto>> Proyectos
        {
            get
            {
                return proyectos;
            }
        }
        /// <summary>
        /// Obtiene la lista de proyectos principal, sobre la cual se debe trabajar
        /// </summary>
        public List<MProyecto> getProyectos
        {
            get
            {
                return mProyectos;
            }
        }
        /// <summary>
        /// Obtiene la lista de los proyectos sin un alumno Asignado
        /// </summary>
        public List<MProyecto> getProyectosNoAsignados
        {
            get
            {
                return mProyectosNoAsignados;
            }
        }
        /// <summary>
        /// Obtiene la lista de los proyectos finalizados
        /// </summary>
        public List<MProyecto> getProyectosFinalizados
        {
            get
            {
                return mProyectosFinalizados;
            }
        }

        public MProyectos()
        {
            mProyectos = new List<MProyecto>();
            mProyectosNoAsignados = new List<MProyecto>();
            mProyectosFinalizados = new List<MProyecto>();
            mProyectosBusqueda = new List<MProyecto>();

            proyectos = new List<List<MProyecto>>(3);
            proyectos.Add(mProyectos);
            proyectos.Add(mProyectosNoAsignados);
            proyectos.Add(mProyectosFinalizados);
            proyectos.Add(mProyectosBusqueda);
        }
        /// <summary>
        /// Añade un proyecto a las listas de proyectos correspondientes
        /// </summary>
        /// <param name="mProyecto"> Proyecto a añadir </param>
        public void Añadir(MProyecto mProyecto)
        {
            mProyectos.Add(mProyecto);
            if (!mProyecto.Asignado)
            {
                mProyectosNoAsignados.Add(mProyecto);
            }
            if (mProyecto.getMTFG.Finalizado)
            {
                mProyectosFinalizados.Add(mProyecto);
            }
        }

        /// <summary>
        /// Añade un proyecto a las listas de proyectos correspondientes en la posición indicada
        /// </summary>
        /// <param name="mProyecto"> Proyecto a añadir</param>
        /// <param name="posicion"> Posición donde se insertara el proyecto dentro de la lista de proyectos principal</param>
        public void AñadirEn(MProyecto mProyecto, int posicion)
        {
            mProyectos.Insert(posicion, mProyecto);
            ReorganizarListaNoAsignados();
            ReorganizarListaFinalizados();
        }

        private void ReorganizarListaNoAsignados()
        {
            mProyectosNoAsignados.Clear();
            foreach(MProyecto proyecto in mProyectos)
            {
                if (!proyecto.Asignado) mProyectosNoAsignados.Add(proyecto);
            }
        }

        private void ReorganizarListaFinalizados()
        {
            mProyectosFinalizados.Clear();
            foreach (MProyecto proyecto in mProyectos)
            {
                if (proyecto.getMTFG.Finalizado) mProyectosFinalizados.Add(proyecto);
            }
        }
        /// <summary>
        /// Elimina un proyecto de las listas
        /// </summary>
        /// <param name="mProyecto">Proyecto a eliminar</param>
        public void Borrar(MProyecto mProyecto)
        {
            mProyectos.Remove(mProyecto);
            if (!mProyecto.Asignado)
            {
                mProyectosNoAsignados.Remove(mProyecto);
            }
            if (mProyecto.getMTFG.Finalizado)
            {
                mProyectosFinalizados.Remove(mProyecto);
            }
        }

        /// <summary>
        /// Elimina un proyecto de las listas
        /// </summary>
        /// <param name="index">Índice del proyecto a eliminar</param>
        public void Borrar(int index)
        {
            if (!mProyectos[index].Asignado)
            {
                mProyectosNoAsignados.Remove(mProyectos[index]);
            }
            if (mProyectos[index].getMTFG.Finalizado)
            {
                mProyectosFinalizados.Remove(mProyectos[index]);
            }
            mProyectos.RemoveAt(index);
        }

        /// <summary>
        /// Realiza una búsqueda en la lista principal y añade a la lista búsqueda los proyectos coincidentes
        /// </summary>
        /// <param name="campo">Buscara los elementos que contengan la palabra clave en el campo seleccionado</param>
        /// <param name="clave">Palabra clave</param>
        public void Buscar(TCampos campo, string clave)
        {
            mProyectosBusqueda.Clear();
            string nombre = "";
            foreach (MProyecto proyecto in mProyectos)
            {
                switch (campo) {
                    case TCampos.Titulo:
                        nombre = proyecto.getMTFG.Titulo.ToUpperInvariant();
                        break;
                    case TCampos.Descripcion:
                        nombre = proyecto.getMTFG.Descripcion.ToUpperInvariant();
                        break;
                    case TCampos.Alumno:
                        if(proyecto.Asignado)
                            nombre = proyecto.Alumno.Nombre.ToUpperInvariant() + proyecto.Alumno.PrimerApellido.ToUpperInvariant() + proyecto.Alumno.SegundoApellido.ToUpperInvariant();
                        break;
                    case TCampos.Profesor:
                        nombre = proyecto.Profesor.Nombre.ToUpperInvariant() + proyecto.Profesor.PrimerApellido.ToUpperInvariant() + proyecto.Profesor.SegundoApellido.ToUpperInvariant() 
                            + proyecto.Profesor.Correo.ToUpperInvariant() + proyecto.Profesor.Despacho.ToUpperInvariant();
                        break;
                    default:
                        nombre = proyecto.getMTFG.Titulo.ToUpperInvariant() + proyecto.getMTFG.Descripcion.ToUpperInvariant();
                        if (proyecto.Asignado)
                            nombre += proyecto.Alumno.Nombre.ToUpperInvariant() + proyecto.Alumno.PrimerApellido.ToUpperInvariant() + proyecto.Alumno.SegundoApellido.ToUpperInvariant();
                        nombre += proyecto.Profesor.Nombre.ToUpperInvariant() + proyecto.Profesor.PrimerApellido.ToUpperInvariant() + proyecto.Profesor.SegundoApellido.ToUpperInvariant()
                            + proyecto.Profesor.Correo.ToUpperInvariant() + proyecto.Profesor.Despacho.ToUpperInvariant();
                        break;
                }

                if (nombre.Contains(clave.ToUpperInvariant()))
                {
                    mProyectosBusqueda.Add(proyecto);
                }
            }
        } 
    }
}
