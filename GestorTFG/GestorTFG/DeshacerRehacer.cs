using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class DeshacerRehacer
    {
        private Stack<Operacion> deshacer;
        private Stack<Operacion> rehacer;
        /// <summary>
        /// Devuelve la pila de las Operaciones realizadas
        /// </summary>
        public Stack<Operacion> Pila
        {
            get
            {
                return deshacer;
            }
        }
        public DeshacerRehacer()
        {
            deshacer = new Stack<Operacion>();
            rehacer = new Stack<Operacion>();
        }
        /// <summary>
        /// Realiza la función undo y devuelve un array con las posiciones que ocupaban los elementos en el caso de haberse realizado una operación de eliminado
        /// </summary>
        /// <returns>Conjunto de índices que ocupaban los elementos antes de la operación</returns>
        public int[] Atras(out TOperacion operacion)
        {
            int[] indices = null;
            operacion = TOperacion.Crear;
            if (deshacer.Count > 0)
            {
                Operacion op = deshacer.Pop();
                operacion = op.TOperacion;
                
                switch (op.TOperacion)
                {
                    case TOperacion.AsignarAlumno:
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.ListaProyectosDespues[0].Indice].EliminarAlumno();
                        break;
                    case TOperacion.Crear:
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.ListaProyectosDespues[0].Indice].Borrar();
                        break;
                    case TOperacion.EliminarAlumno:
                        foreach (ProyectoIndice proyecto in op.ListaProyectosAntes) 
                        {
                            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[proyecto.Indice].AsignarAlumno(proyecto.Proyecto.Alumno);
                        }
                        break;
                    case TOperacion.EliminarTFG:
                        foreach (ProyectoIndice proyecto in op.ListaProyectosAntes) 
                        {
                            MListaProyectos.getMListaProyectos.getMProyectos.AñadirEn(proyecto.Proyecto, proyecto.Indice);
                        }
                        break;
                    case TOperacion.Modificar:
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.ListaProyectosDespues[0].Indice] = op.ListaProyectosAntes[0].Proyecto;
                        break;
                    case TOperacion.FinalizarTFG:
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.ListaProyectosAntes[0].Indice].getMTFG.QuitarFinalizado();
                        break;
                }
                indices = new int[op.ListaProyectosAntes.Count];
                for (int i = 0; i < indices.Length; i++)
                {
                    indices[i] = op.ListaProyectosAntes[i].Indice;
                }
                rehacer.Push(op);
            }
            return indices;
        }
        /// <summary>
        /// Realiza la función redo y devuelve un array con las posiciones que ocupaban los elementos en el caso de haberse realizado una operación de eliminado
        /// </summary>
        /// <returns>Conjunto de índices que ocupaban los elementos después de la operación</returns>
        public int[] Adelante(out TOperacion operacion)
        {
            int[] indices = null;
            operacion = TOperacion.Crear;
            if (rehacer.Count > 0)
            {
                Operacion op = rehacer.Pop();
                operacion = op.TOperacion;
                switch (op.TOperacion)
                {
                    case TOperacion.AsignarAlumno:
                        foreach(ProyectoIndice proyecto in op.ListaProyectosDespues) 
                        {
                            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[proyecto.Indice].AsignarAlumno(proyecto.Proyecto.Alumno);
                        }
                        break;
                    case TOperacion.Crear:
                        foreach(ProyectoIndice proyecto in op.ListaProyectosDespues) 
                        {
                            MListaProyectos.getMListaProyectos.getMProyectos.AñadirEn(proyecto.Proyecto, proyecto.Indice);
                        }
                        break;
                    case TOperacion.EliminarAlumno:
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.ListaProyectosAntes[0].Indice].EliminarAlumno();
                        break;
                    case TOperacion.EliminarTFG:
                        for(int i = op.ListaProyectosAntes.Count - 1; i > - 1; i--)  
                            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.ListaProyectosAntes[i].Indice].Borrar();
                        break;
                    case TOperacion.Modificar:
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.ListaProyectosAntes[0].Indice] = op.ListaProyectosDespues[0].Proyecto;
                        break;
                    case TOperacion.FinalizarTFG:
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.ListaProyectosAntes[0].Indice].getMTFG.Finalizar(op.ListaProyectosDespues[0].Proyecto.getMTFG.getMFinalizado);
                        break;
                }
                indices = new int[op.ListaProyectosDespues.Count];
                for(int i = 0; i < indices.Length; i++)
                {
                    indices[i] = op.ListaProyectosDespues[i].Indice;
                }
                deshacer.Push(op);
            }
            return indices;
        }

        /// <returns>Pila deshacer vacía</returns>
        public bool PilaDeshacerVacia()
        {
            return deshacer.Count == 0;
        }
        /// <returns>Pila rehacer vacía</returns>
        public bool PilaRehacerVacia()
        {
            return rehacer.Count == 0;
        }
        /// <summary>
        /// Vacía las pilas deshacer y rehacer
        /// </summary>
        public void VaciarPilas()
        {
            deshacer.Clear();
            rehacer.Clear();
        }
        /// <summary>
        /// Vacía la pila rehacer
        /// </summary>
        public void VaciarRehacer()
        {
            rehacer.Clear();
        }
    }
}
