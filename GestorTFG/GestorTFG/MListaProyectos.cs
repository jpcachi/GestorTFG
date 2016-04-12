using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class MListaProyectos
    {
        private static MListaProyectos mListaProyectos = new MListaProyectos();
        private MProyectos mProyectos = new MProyectos();
        public static MListaProyectos getMListaProyectos
        {
            get
            {
                return mListaProyectos;
            }
        }

        public MProyectos getMProyectos
        {
            get
            {
                return mProyectos;
            }
        }
    }
}
