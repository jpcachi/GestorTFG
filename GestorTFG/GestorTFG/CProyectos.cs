using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class CProyectos
    {
        private bool cambios;
        private bool nuevaLista;
        public bool Cambios
        {
            get
            {
                return cambios;
            }
        }
        public bool NuevaLista
        {
            get
            {
                return nuevaLista;
            }
        }

        public CProyectos()
        {
            cambios = false;
            nuevaLista = true;
        }
        public void AñadirProyecto(string Titulo, string Descripcion, string Fecha, string ProfesorNombre, string ProfesorApellido1, string ProfesorApellido2, string ProfesorCorreo, string ProfesorDespacho)
        {
            MListaProyectos.getMListaProyectos.getMProyectos.Añadir(Instanciar.NuevoProyecto.Crear(Titulo, Descripcion, Fecha, ProfesorNombre, ProfesorApellido1, ProfesorApellido2, ProfesorDespacho, ProfesorCorreo));
            cambios = true;
        }

        public void EliminarProyecto(int index)
        {
            MListaProyectos.getMListaProyectos.getMProyectos.Borrar(MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[index]);
            cambios = true;
        }

        public void FinalizarProyecto(string defensa, string convocatoria, float nota, int index)
        {
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[index].getMTFG.Finalizar(defensa, convocatoria, nota);
            cambios = true;
        }

        public void ModificarProyecto(string opcion, int index)
        {
            switch(opcion)
            {
                
            }
            cambios = true;
        }

        public void GuardarProyectos()
        {
            cambios = false;
            nuevaLista = false;
        }

        public void CrearNuevaLista()
        {
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectos.Clear();
            nuevaLista = true;
            cambios = false;
        }
    }
}
