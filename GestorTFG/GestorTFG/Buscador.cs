﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorTFG
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

        public Buscador()
        {
            filtro = Filtros.ninguno;
            ResultadoBusqueda = new List<MProyecto>();
        }

        public void BuscarProyecto(string clave, TCampos campo, int index1, int index2, DateTimePicker date, NumericUpDown number)
        {
            MListaProyectos.getMListaProyectos.getMProyectos.Buscar(campo, clave);
            FiltrarProyecto(index1, index2, date, number);
            if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Count > 0)
                new Form4(clave).ShowDialog();
            else
                MessageBox.Show("No se han encontrado proyectos que coincidan con los parámetros de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void FiltrarProyecto(int index1, int index2, DateTimePicker date, NumericUpDown number)
        {
            int num = MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Count;
            bool eliminado = false;
            for (int i = num - 1; i > -1; i--)
            {
                eliminado = false;
                switch(index1)
                {
                    case 1: //fecha superior a
                        if (date.Value >= DateTime.Parse(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.Fecha))
                        {
                            MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                            eliminado = true;
                        }
                        break;
                    case 2: //fecha inferior a
                        if (date.Value <= DateTime.Parse(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.Fecha))
                        {
                            MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                            eliminado = true;
                        }
                        break;
                    case 3: // fecha igual a
                        if (date.Text != MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.Fecha)
                        {
                            MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                            eliminado = true;
                        }
                        break;
                }

                if(!eliminado)
                {
                    if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.Finalizado)
                    {
                        switch (index2)
                        {
                            case 1: //nota superior a
                                if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.getMFinalizado.Nota <= (float)number.Value)
                                    MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                                break;
                            case 2: //nota inferior a
                                if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.getMFinalizado.Nota >= (float)number.Value)
                                    MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                                break;
                            case 3: //nota igual a
                                if (MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i].getMTFG.getMFinalizado.Nota != (float)number.Value)
                                    MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3].Remove(MListaProyectos.getMListaProyectos.getMProyectos.Proyectos[3][i]);
                                break;
                        }
                    }
                }
            }
        }
    }
}
