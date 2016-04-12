using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class MFinalizado
    {
        private string defensa;
        private string convocatoria;
        private float nota;

        public string Defensa
        {
            get
            {
                return defensa;
            }

            set
            {
                defensa = value;
            }
        }

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
    }
}
