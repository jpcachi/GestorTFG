using GestorTFG;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestorTFG2
{
    public enum Filtros
    {
        ninguno,
        campo,
        fecha,
        calificacion
    }

    class Buscador
    {
        private Filtros filtro;
        private List<MProyecto> ResultadoBusqueda;
        private Form1 ventanaPadre;

        public Filtros Filtro
        {
            get
            {
                return filtro;
            }
            set
            {
                filtro = value;
            }
        }

        public Buscador(Form1 owner)
        {
            filtro = Filtros.ninguno;
            ResultadoBusqueda = new List<MProyecto>();
            ventanaPadre = owner;
        }

        public void BuscarProyecto(string clave, TCampos campo, int index1, int index2, int index3, int index4, DateTime date1, DateTime date2, DateTime date3, decimal number, LeerEscribirArchivo fichero)
        {
            MListaProyectos.getMListaProyectos.getMProyectos.Buscar(campo, clave);
            bool filtro = FiltrarProyecto(index1, index2, index3, index4, date1, date2, date3, number);


            if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Count > 0)
                new Form4(ventanaPadre, clave, campo, index1, index2, index3, index4, date1, date2, date3, number, filtro, fichero).ShowDialog(ventanaPadre);
            else
                MessageBox.Show("No se han encontrado proyectos que coincidan con los parámetros de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        private bool FiltrarProyecto(int index1, int index2, int index3, int index4, DateTime date1, DateTime date2, DateTime date3, decimal number)
        {
            bool resul = true;
            int num = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Count;
            bool eliminado = false;
            try
            {
                for (int i = num - 1; i > -1; i--)
                {
                    eliminado = false;
                    switch (index1)
                    {
                        case 1: //fecha superior a
                            if (date1.Date >= /*DateTime.Parse(*/MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.Fecha.Date)
                            {
                                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                                eliminado = true;
                            }
                            break;
                        case 2: //fecha inferior a
                            if (date1.Date <= /*DateTime.Parse(*/MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.Fecha.Date)
                            {
                                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                                eliminado = true;
                            }
                            break;
                        case 3: // fecha igual a
                            if (date1 != MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.Fecha)
                            {
                                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                                eliminado = true;
                            }
                            break;
                    }

                    if (!eliminado)
                    {
                        if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].Asignado)
                        {
                            switch (index2)
                            {
                                case 1: //fecha superior a
                                    if (date2.Date >= /*DateTime.Parse(*/MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].Alumno.FechaInicio.Date)
                                    {
                                        MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                                        eliminado = true;
                                    }
                                    break;
                                case 2: //fecha inferior a
                                    if (date2.Date <= /*DateTime.Parse(*/MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].Alumno.FechaInicio.Date)
                                    {
                                        MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                                        eliminado = true;
                                    }
                                    break;
                                case 3: // fecha igual a
                                    if (date2 != MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].Alumno.FechaInicio)
                                    {
                                        MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                                        eliminado = true;
                                    }
                                    break;
                            }
                            if (!eliminado)
                            {
                                if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.Finalizado)
                                {
                                    switch (index3)
                                    {
                                        case 1: //fecha superior a
                                            if (date3.Date >= /*DateTime.Parse(*/MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.getMFinalizado.Defensa.Date)
                                            {
                                                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                                                eliminado = true;
                                            }
                                            break;
                                        case 2: //fecha inferior a
                                            if (date3.Date <= /*DateTime.Parse(*/MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.getMFinalizado.Defensa.Date)
                                            {
                                                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                                                eliminado = true;
                                            }
                                            break;
                                        case 3: // fecha igual a
                                            if (date3 != MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.getMFinalizado.Defensa)
                                            {
                                                MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                                                eliminado = true;
                                            }
                                            break;
                                    }
                                    if (!eliminado)
                                    {
                                        switch (index4)
                                        {
                                            case 1: //nota superior a
                                                if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.getMFinalizado.Nota <= (float)number)
                                                    MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                                                break;
                                            case 2: //nota superior o igual a
                                                if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.getMFinalizado.Nota < (float)number)
                                                    MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                                                break;
                                            case 3: //nota inferior a
                                                if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.getMFinalizado.Nota >= (float)number)
                                                    MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                                                break;
                                            case 4: //nota inferior o igual a
                                                if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.getMFinalizado.Nota > (float)number)
                                                    MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                                                break;
                                            case 5: //nota igual a
                                                if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.getMFinalizado.Nota != (float)number)
                                                    MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                                                break;
                                        }
                                    }
                                }
                                else if (index3 > 0) MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                            }
                        }
                        else if (index2 > 0) MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido aplicar el filtro.\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                resul = false;
            }
            return resul;
        }
    }
}