namespace GestorTFG
{
    public class NuevoMTFG
    {
        /// <summary>
        /// Método encargado de devolver una nueva instancia del tipo TFG
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="descripcion"></param>
        /// <param name="fecha"></param>
        /// <param name="mProyecto"></param>
        /// <returns></returns>
        public MTFG Crear(string titulo, string descripcion, string fecha, MProyecto mProyecto)
        {
            return new MTFG(titulo, descripcion, fecha, mProyecto);
        }
    }
}
