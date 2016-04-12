using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class NuevoMFinalizado
    {
        
        public MFinalizado Crear(string defensa, string convocatoria, float nota)
        {
            return new MFinalizado(defensa, convocatoria, nota);
        }
    }
}
