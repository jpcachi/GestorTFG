using System;

namespace GestorTFG
{
    public class MFinalizado
    {
        private string defensa;
        public DateTime Defensa { get; set; }
        private string convocatoria;
        private float nota;
        /// <summary>
        /// Obtiene o establece la fecha de la defensa de los datos de Finalización de un TFG
        /// </summary>
        /*public string Defensa
        {
            get
            {
                return defensa;
            }

            set
            {
                defensa = value;
            }
        }*/
        /// <summary>
        /// Obtiene o establece la Convocatoria de los datos de Finalización de un TFG
        /// </summary>
        public string Convocatoria
        {
            get
            {
                return convocatoria;
            }

            set
            {
                convocatoria = value;
            }
        }
        /// <summary>
        /// Obtiene o establece la Nota de los datos de Finalización de un TFG
        /// </summary>
        public float Nota
        {
            get
            {
                return nota;
            }

            set
            {
                nota = value;
            }
        }

        public MFinalizado(string defensa, string convocatoria, float nota)
        {
            this.defensa = defensa;
            this.convocatoria = convocatoria;
            this.nota = nota;
        }

        public MFinalizado(DateTime defensa, string convocatoria, float nota)
        {
            this.Defensa = defensa;
            this.convocatoria = convocatoria;
            this.nota = nota;
        }
    }
}
