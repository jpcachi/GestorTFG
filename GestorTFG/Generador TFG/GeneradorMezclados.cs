using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generador_TFG
{
    class GeneradorMezclados : Generador
    {
        public GeneradorMezclados(int tam)
        {
            GenerarDatos(tam);
            GuardarDatos("ListaTFG.txt");
        }

        public GeneradorMezclados(int tam, string path)
        {
            GenerarDatos(tam);
            GuardarDatos(path);
        }

        public override void GenerarDatos(int tamaño)
        {
            Random rand = new Random();
            int opcion;
            for (int i = 0; i < tamaño; i++)
            {
                opcion = rand.Next(3);
                GenerarDatosOpcion(opcion, rand);
            }
        }

        private void GenerarDatosOpcion(int opcion, Random rand)
        {
            //Random rand = new Random();
            string nombre;
            string apellido1;
            string apellido2;
            List<string> ary = new List<string>();
            // titulo
            ary.Add(titulo[rand.Next(titulo.Length)]);

            //descripcion
            ary.Add(descripcion[rand.Next(descripcion.Length)]);

            //fecharegistro
            ary.Add(GeneradorFechas.GenerarFecha());

            // profesor
            //nombre
            nombre = nombres[rand.Next(nombres.Length)];
            ary.Add(nombre);

            //apellido1
            apellido1 = apellido[rand.Next(apellido.Length)];
            ary.Add(apellido1);

            //apellido2
            apellido2 = apellido[rand.Next(apellido.Length)];
            ary.Add(apellido2);

            //correo
            ary.Add(nombre + apellido1 + apellido2 + "@upm.es");

            //despacho
            ary.Add(rand.Next(1, 10000).ToString());
   
            if (opcion == 2)
            {
                // alumno
                //nombre
                ary.Add(string.Empty);

                //apellido1
                ary.Add(string.Empty);

                //apellido2
                ary.Add(string.Empty);

                //matricula
                ary.Add(string.Empty);

                //fechadeinicio
                ary.Add(string.Empty);
            }
            else
            {
                //alumno
                //nombre
                ary.Add(nombres[rand.Next(nombres.Length)]);

                //apellido1
                ary.Add(apellido[rand.Next(apellido.Length)]);

                //apellido2
                ary.Add(apellido[rand.Next(apellido.Length)]);

                //matricula
                ary.Add(char.ConvertFromUtf32(rand.Next(0x0061, 0x007A)) + char.ConvertFromUtf32(rand.Next(0x0061, 0x007A)) + rand.Next(10000).ToString());

                //fechadeinicio
                ary.Add(GeneradorFechas.GenerarFecha());
            }

            if (opcion == 1 || opcion == 2)
            {

                //fechadefensa
                ary.Add(string.Empty);

                //convocatoria
                ary.Add(string.Empty);

                //calificacion
                ary.Add(string.Empty);
            } else
            {
                //fechadefensa
                ary.Add(GeneradorFechas.GenerarFecha());

                //convocatoria
                ary.Add(convocatoria[rand.Next(convocatoria.Length)]);

                //calificacion
                int notaSinDecimales = rand.Next(11);
                ary.Add(notaSinDecimales + "," + rand.Next(0, (notaSinDecimales == 10) ? 0 : 10) + rand.Next(0, (notaSinDecimales == 10) ? 0 : 10));
            }

            datos.Add(ary);
        }
    }
}
