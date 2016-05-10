using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generador_TFG
{
    public static class GeneradorFechas
    {
        private static Random generador = new Random();
        private static int numero, mes, año;

        private static int GenerarAño()
        {
            return generador.Next(2005, 2017);
        }

        private static int GenerarMes()
        {
            return generador.Next(1, 12);
        }

        private static int GenerarDia(int mes, int año)
        {
            int resul = 1;
            switch (mes)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    resul = generador.Next(1, 32);
                    break;
                case 2:
                    if((año % 100) + (año % 400) == 0)
                    {
                        resul = generador.Next(1, 30);
                    } else
                    {
                        resul = generador.Next(1, 29);
                    }
                    break;
                case 4: case 6: case 9: case 11:
                    resul = generador.Next(1, 31);
                    break;
            }
            return resul;
        }

        public static string GenerarFecha()
        {
            int año = GenerarAño();
            int mes = GenerarMes();
            int dia = GenerarDia(mes, año);

            string mes_formato = mes.ToString();
            string dia_formato = dia.ToString();
            if(mes_formato.Length == 1)
            {
                mes_formato = "0" + mes_formato;
            }

            if(dia_formato.Length == 1)
            {
                dia_formato = "0" + dia_formato;
            }

            return dia_formato + "/" + mes_formato + "/" + año.ToString();
        }
    }
}
