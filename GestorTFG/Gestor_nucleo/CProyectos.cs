namespace GestorTFG
{
    /// <summary>
    /// Clase encargada de gestionar las operaciones de lista de proyectos desde la interfaz gráfica
    /// </summary>
    public class CProyectos
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

        public void ModificarProyecto(int opcion, string valor, int index)
        {
            switch(opcion)
            {
                case 0: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[index].getMTFG.Titulo = valor; break;
                case 1: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[index].getMTFG.Descripcion = valor; break;
                case 2: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[index].getMTFG.Fecha = valor; break;
                case 3: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[index].Alumno.Nombre = valor; break;
                case 4: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[index].Alumno.PrimerApellido = valor; break;
                case 5: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[index].Alumno.SegundoApellido = valor; break;
                case 6: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[index].Alumno.Matricula = valor; break;
                case 7: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[index].Alumno.FechaInicio = valor; break;
                case 8: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[index].getMTFG.getMFinalizado.Defensa = valor; break;
                case 9: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[index].getMTFG.getMFinalizado.Convocatoria = valor; break;
                case 10: MListaProyectos.getMListaProyectos.getMProyectos.getProyectos[index].getMTFG.getMFinalizado.Nota = float.Parse(valor); break;
                default: break;
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
            MListaProyectos.getMListaProyectos.getMProyectos.getBusquedaProyecto.Clear();
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectosFinalizados.Clear();
            MListaProyectos.getMListaProyectos.getMProyectos.getProyectosNoAsignados.Clear();
            nuevaLista = true;
            cambios = false;
        }
    }
}
