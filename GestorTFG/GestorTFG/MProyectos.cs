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

        private List<List<MProyecto>> proyectos;

        public List<List<MProyecto>> Proyectos
        {
            get
            {
                return proyectos;
            }
        }

        public List<MProyecto> getProyectos
        {
            get
            {
                return mProyectos;
            }
        }

        public List<MProyecto> getProyectosNoAsignados
        {
            get
            {
                return mProyectosNoAsignados;
            }
        }

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

            proyectos = new List<List<MProyecto>>(3);
            proyectos.Add(mProyectos);
            proyectos.Add(mProyectosNoAsignados);
            proyectos.Add(mProyectosFinalizados);
        }

        public void Añadir (MProyecto mProyecto)
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

        public void Borrar (MProyecto mProyecto)
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

        public void Borrar (int index)
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
    }
}
