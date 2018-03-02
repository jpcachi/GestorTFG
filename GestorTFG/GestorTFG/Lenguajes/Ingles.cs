using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestorTFG.Lenguajes
{
    class Ingles : Idioma
    {
        public Ingles()
        {
            menuPrincipal = new string[] { "&File", "&Edit", "&View", "&Projects", "&Tools", "&Help" };
            archivoSubItem = new string[] {"&New", "&Open", "&Save", "Save &as", "&Print", "Print preview", "Exit" };
            editarSubItem = new string[] { "Undo", "Redo", "Cut", "Copy", "Paste", "Select all"};
            verSubItem = new string[] { "Toolbar", "Search panel", "Data panel" };
            proyectoSubItem = new string[] { "Assign student", "Delete student", "Delete EDP" };
            herramientasSubItem = new string[] { "Change language", "Customize", "Classic theme", "Appearance", "Fullscreen"};
            ayudaSubItem = new string[] { "Content", "Index", "About..." };

            barraHerramientas = new string[] { "Field", "Search", "Filter by", "Passed", "Failed" };
            busquedaPanel = new string[] { "Search", "What are you looking for?", "Field:", "Filter", "Register date:", "Project start date:", "Project defense date:", "Calification" };
            TFGPanel = new string[] { "All", "Unassgined", "Ended", "Title", "Description", "Register date", "First name", "Second name", "Third name", "Code", "Start date", "Defense date", "Announcement", "Calification" };
            datosPanel = new string[] { "EDP info", "Teacher info", "Student", "Ended", "Yes", "No"};
            añadirTFG = new string[] { "Teacher", "First name:", "Second name:", "Third name:", "e-mail:", "office:", "EDP", "Title:", "Register date:", "Description:", "Add", "Clear"};
            modificarTFG = new string[] { "Field", "Value", "Change", "Cancel", "End EDP", "D. Date:", "Announcement:", "Calification", "End", "Project", "Edit teacher", "Assign student", "Delete student", "Delete EDP"};

            ventanaInformacion = new string[] {"Project information", "Project name", "Description", "Register date", "Status", "Directed by", "E-mail:", "Office:", "Student:", "Code", "Start date", "Defense date:", "Announcement", "Calification", "Copy to clipboard", "Copy all to clipboard", "OK" };
            ventanaBusqueda = new string[] { "Search results", "Showing matches of:"};
            ventanaAcerca = new string[] { "Version", "FIS Project. 2016 UPM" };


        }
    }
}
