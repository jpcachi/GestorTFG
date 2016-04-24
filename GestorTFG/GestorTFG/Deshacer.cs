using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class Deshacer
    {
        private Stack<Operacion> deshacer;
        private Stack<Operacion> rehacer;
        public Stack<Operacion> Pila
        {
            get
            {
                return deshacer;
            }
        }
        public Deshacer()
        {
            deshacer = new Stack<Operacion>();
            rehacer = new Stack<Operacion>();
        }

        public int[] Atras()
        {
            int[] indices = null;
            if (deshacer.Count > 0)
            {
                Operacion op = deshacer.Pop();

                
                switch (op.TOperacion)
                {
                    case TOperacion.AsignarAlumno:
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.ListaProyectosDespues[0].Indice].EliminarAlumno();
                        break;
                    case TOperacion.Crear:
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.ListaProyectosDespues[0].Indice].Borrar();
                        break;
                    case TOperacion.EliminarAlumno:
                        //MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].AsignarAlumno(op.ProyectoEliminado.Alumno);
                        foreach(ProyectoIndice proyecto in op.ListaProyectosAntes) 
                        {
                            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[proyecto.Indice].AsignarAlumno(proyecto.Proyecto.Alumno);
                        }
                        break;
                    case TOperacion.EliminarTFG:
                        //MListaProyectos.getMListaProyectos.getMProyectos.AñadirEn(op.ProyectoEliminado, op.IndiceProyecto);
                        foreach(ProyectoIndice proyecto in op.ListaProyectosAntes) 
                        {
                            MListaProyectos.getMListaProyectos.getMProyectos.AñadirEn(proyecto.Proyecto, proyecto.Indice);
                        }
                        break;
                    case TOperacion.Modificar:
                        //foreach(ProyectoIndice proyecto in op.ListaProyectos) 
                        //{
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.ListaProyectosDespues[0].Indice] = op.ListaProyectosAntes[0].Proyecto;
                        //}
                        /*List<ProyectoIndice> aux = op.ListaProyectosAntes;
                        op.ListaProyectosAntes = op.ListaProyectosDespues;
                        op.ListaProyectosDespues = aux;*/
                        break;
                    case TOperacion.FinalizarTFG:
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.ListaProyectosAntes[0].Indice].getMTFG.QuitarFinalizado();
                        break;
                        /*
                        switch (op.IndiceModificar)
                        {
                            Título
                            Descripción
                            Fecha de registro
                            Nombre del Alumno
                            Primer Apellido
                            Segundo Apellido
                            Fecha de inicio
                            Fecha de defensa
                            Convocatoria
                            Calificación
                            
                            case 0: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].getMTFG.Titulo = op.ProyectoEliminado.getMTFG.Titulo; break;
                            case 1: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].getMTFG.Descripcion = op.ProyectoEliminado.getMTFG.Descripcion; break;
                            case 2: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].getMTFG.Fecha = op.ProyectoEliminado.getMTFG.Fecha; break;
                            case 3: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].Alumno.Nombre = op.ProyectoEliminado.Alumno.Nombre; break;
                            case 4: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].Alumno.PrimerApellido = op.ProyectoEliminado.Alumno.PrimerApellido; break;
                            case 5: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].Alumno.SegundoApellido = op.ProyectoEliminado.Alumno.SegundoApellido; break;
                            case 6: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].Alumno.FechaInicio = op.ProyectoEliminado.Alumno.FechaInicio; break;
                            case 7: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].getMTFG.getMFinalizado.Defensa = op.ProyectoEliminado.getMTFG.getMFinalizado.Defensa; break;
                            case 8: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].getMTFG.getMFinalizado.Convocatoria = op.ProyectoEliminado.getMTFG.getMFinalizado.Convocatoria; break;
                            case 9: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].getMTFG.getMFinalizado.Nota = op.ProyectoEliminado.getMTFG.getMFinalizado.Nota; break;
                        }
                        break;*/
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

        public int[] Adelante()
        {
            int[] indices = null;
            if (rehacer.Count > 0)
            {
                Operacion op = rehacer.Pop();
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
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.ListaProyectosAntes[0].Indice].Borrar();
                        break;
                    case TOperacion.Modificar:
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.ListaProyectosAntes[0].Indice] = op.ListaProyectosDespues[0].Proyecto;
                        //List<ProyectoIndice> aux = op.ListaProyectosAntes;
                        //op.ListaProyectosAntes = op.ListaProyectosDespues;
                        //op.ListaProyectosDespues = aux;
                        break;
                    case TOperacion.FinalizarTFG:
                        MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.ListaProyectosAntes[0].Indice].getMTFG.Finalizar(op.ListaProyectosAntes[0].Proyecto.getMTFG.getMFinalizado);
                        break;
                        /*switch (op.IndiceModificar)
                        {
                         
                        break;
                            Título
                            Descripción
                            Fecha de registro
                            Nombre del Alumno
                            Primer Apellido
                            Segundo Apellido
                            Fecha de inicio
                            Fecha de defensa
                            Convocatoria
                            Calificación
                            
                            case 0: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].getMTFG.Titulo = op.ProyectoEliminado.getMTFG.Titulo; break;
                            case 1: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].getMTFG.Descripcion = op.ProyectoEliminado.getMTFG.Descripcion; break;
                            case 2: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].getMTFG.Fecha = op.ProyectoEliminado.getMTFG.Fecha; break;
                            case 3: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].Alumno.Nombre = op.ProyectoEliminado.Alumno.Nombre; break;
                            case 4: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].Alumno.PrimerApellido = op.ProyectoEliminado.Alumno.PrimerApellido; break;
                            case 5: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].Alumno.SegundoApellido = op.ProyectoEliminado.Alumno.SegundoApellido; break;
                            case 6: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].Alumno.FechaInicio = op.ProyectoEliminado.Alumno.FechaInicio; break;
                            case 7: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].getMTFG.getMFinalizado.Defensa = op.ProyectoEliminado.getMTFG.getMFinalizado.Defensa; break;
                            case 8: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].getMTFG.getMFinalizado.Convocatoria = op.ProyectoEliminado.getMTFG.getMFinalizado.Convocatoria; break;
                            case 9: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[op.IndiceProyecto].getMTFG.getMFinalizado.Nota = op.ProyectoEliminado.getMTFG.getMFinalizado.Nota; break;
                        }
                        break;*/
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

        public bool PilaDeshacerVacia()
        {
            return deshacer.Count == 0;
        }

        public bool PilaRehacerVacia()
        {
            return rehacer.Count == 0;
        }

        public void VaciarPilas()
        {
            deshacer.Clear();
            rehacer.Clear();
        }

        public void VaciarRehacer()
        {
            rehacer.Clear();
        }
    }
}
