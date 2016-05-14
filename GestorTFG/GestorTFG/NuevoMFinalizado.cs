namespace GestorTFG
{
    class NuevoMFinalizado
    {
        /// <summary>
        /// Método encargado de devolver una instancia del tipo MFinalizado
        /// </summary>
        /// <param name="defensa"></param>
        /// <param name="convocatoria"></param>
        /// <param name="nota"></param>
        /// <returns></returns>
        public MFinalizado Crear(string defensa, string convocatoria, float nota)
        {
            return new MFinalizado(defensa, convocatoria, nota);
        }
    }
}
