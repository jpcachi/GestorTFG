using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Generador_TFG
{
    abstract class Generador
    {
        protected List<List<string>> datos = new List<List<string>>();
        protected string[] titulo = {"Ordenador cuantico",
            "Investigación de la Maltodetrina", "Robot asesino",
            "Evasión regularizada de clases presenciales"};
        protected string[] descripcion = {"Datos de prueba", "trfvhyuok,",
            "Esto es una pruebita", "This is Sparta", "Llevadme ante vuestro lider",
            "Pa'cerme el chulo"};
        protected string[] nombres = {"Alvaro", "Alberto", "Pepe", "Juan", "Jose",
            "Luis", "Pedro", "Guillermo", "David", "Daniel", "Maria", "Antonia", "Daniela",
            "Carmen", "Angeles", "Ana", "Nuria", "Lucia", "Arnold"};
        protected string[] apellido = {"Narvaez", "Franco", "Ubeda", "Haro",
            "Schwarzenegger", "Newton", "Urkerl", "Garcia", "Montalvo", "Martinez",
            "Rodriguez", "Valenzuela", "de la Hoz"};
        protected string[] convocatoria = { "Junio", "Septiembre" };
        abstract public void GenerarDatos(int tamaño);

        protected void GuardarDatos(string nombre)
        {
            using (StreamWriter fichero = new StreamWriter(nombre))
            {
                foreach(List<string> dato in datos)
                {
                    string s = "";
                    for (int i = 0; i < dato.Count; i++)
                    {
                        s += dato[i];
                        if (i < (dato.Count - 1)) s += ";";
                    }
                    fichero.WriteLine(s);
                }
                //fichero.Close();
            }
        }
    }   
}
