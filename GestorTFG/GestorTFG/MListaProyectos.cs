﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG
{
    class MListaProyectos
    {
        private static MListaProyectos mListaProyectos = new MListaProyectos();
        private MProyectos mProyectos = new MProyectos();

        /// <summary>
        /// Obtiene la instancia del gestor de proyectos
        /// </summary>
        public static MListaProyectos getMListaProyectos
        {
            get
            {
                return mListaProyectos;
            }
        }
        /// <summary>
        /// Obtiene todas las listas de proyectos
        /// </summary>
        public MProyectos getMProyectos
        {
            get
            {
                return mProyectos;
            }
        }
    }
}
