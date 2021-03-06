﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generador_TFG
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 1000;
            int dim;
            if (int.TryParse(args[1], out dim))
            {
                num = dim;
            }

            switch (args[0].ToUpperInvariant())
            {
                case "NO_FINALIZADOS":
                    new GeneradorTFGSinFinalizar(num);
                    break;
                case "FINALIZADOS":
                    new GeneradorTFGFinalizados(num);
                    break;
                case "NO_ASIGNADOS":
                    new GeneradorTFGSinAsignar(num);
                    break;
                case "TODOS":
                    new GeneradorMezclados(num);
                    break;
                default:
                    new GeneradorMezclados(num);
                    break;
            }
        }
    }
}
