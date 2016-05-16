using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generador_TFG
{
    class GeneradorTFGSinAsignar : Generador
    {
        public GeneradorTFGSinAsignar(int tamaño)
        {
            GenerarDatos(tamaño);
            GuardarDatos("NoAsignados.txt");
        }

        public GeneradorTFGSinAsignar(int tam, string path)
        {
            GenerarDatos(tam);
            GuardarDatos(path);
        }

        public override void GenerarDatos(int tamaño)
        {
            Random rand = new Random();
            string nombre;
            string apellido1;
            string apellido2;
            for (int i = 0; i < tamaño; i++)
            {
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

                //fechadefensa
                ary.Add(string.Empty);

                //convocatoria
                ary.Add(string.Empty);

                //calificacion
                ary.Add(string.Empty);
                datos.Add(ary);
            }
        }
    }
}
