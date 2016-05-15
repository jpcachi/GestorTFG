namespace GestorTFG
{
    public class NuevoMProyecto
    {
        /// <summary>
        /// Método encargado de devolver una instancia del tipo Proyecto
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="descripcion"></param>
        /// <param name="fecha"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido1"></param>
        /// <param name="apellido2"></param>
        /// <param name="despacho"></param>
        /// <param name="correo"></param>
        /// <returns></returns>
        public MProyecto Crear(string titulo, string descripcion, string fecha, string nombre, string apellido1, string apellido2, string despacho, string correo)
        {
            return new MProyecto(titulo, descripcion, fecha, nombre, apellido1, apellido2, despacho, correo);
        }
    }
}
