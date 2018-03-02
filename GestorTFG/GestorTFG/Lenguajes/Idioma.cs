using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG.Lenguajes
{
    abstract class Idioma
    {
        protected string[] menuPrincipal;
        protected string[] archivoSubItem;
        protected string[] editarSubItem;
        protected string[] verSubItem;
        protected string[] proyectoSubItem;
        protected string[] herramientasSubItem;
        protected string[] ayudaSubItem;

        protected string[] barraHerramientas;

        protected string[] busquedaPanel;
        protected string[] TFGPanel;
        protected string[] datosPanel;
        protected string[] añadirTFG;
        protected string[] modificarTFG;

        protected string[] ventanaInformacion;
        protected string[] ventanaBusqueda;
        protected string[] ventanaAcerca;
        protected string[] ventanaPreferencias;
        protected string[] ventanaProfesor;
        protected string[] ventanaAlumno;

        protected void AplicarIdioma(Form1 principal, Form2 alumno, Form10 profesor, Form4 busqueda, Form6 acerca, Form12 informacion, Preferencias preferencias, Forms.Form_Idioma idioma)
        {

        }
    }
}
