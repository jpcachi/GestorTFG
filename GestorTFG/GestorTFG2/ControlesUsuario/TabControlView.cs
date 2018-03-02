using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestorTFG2.ControlesUsuario
{

    public partial class TabControlView : UserControl
    {
        private int selectedTab;
        private CustomListView[] listasProyectos;
        public event EventHandler SelectedTabChanged;
        public event EventHandler ProjectListSizeChanged;

        public TabView Tab1
        {
            get
            {
                return panel_1;
            }
        }

        public TabView Tab2
        {
            get
            {
                return panel_2;
            }
        }

        public TabView Tab3
        {
            get
            {
                return panel_3;
            }
        }

        public CustomListView ListaTodosProyectos
        {
            get
            {
                return customListView1;
            }
        }

        public CustomListView ListaProyectosSinAsignar
        {
            get
            {
                return customListView3;
            }
        }

        public CustomListView ListaProyectosFinalizados
        {
            get
            {
                return customListView2;
            }
        }

        public CustomListView[] ListaProyectos
        {
            get
            {
                return listasProyectos;
            }
        }

        public int SelectedTab
        {
            get
            {
                return selectedTab;
            }

            set
            {
                if (selectedTab != value)
                { 
                    selectedTab = value;
                    OnSelectedTabChanged(new EventArgs());
                    LimpiarBackgroundTabs();
                    ColorearBackgroundTabs(selectedTab);
                    MostrarTab(selectedTab);
                }
            }
        }

        protected virtual void OnSelectedTabChanged(EventArgs e)
        {
            SelectedTabChanged?.Invoke(this, e);
        }

        protected virtual void OnProjectListSizeChanged(EventArgs e)
        {
            ProjectListSizeChanged?.Invoke(this, e);
        }

        public TabControlView()
        {
            InitializeComponent();
            selectedTab = 0;
            listasProyectos = new CustomListView[3] { customListView1, customListView3, customListView2 };
        }

        private void LimpiarBackgroundTabs()
        {
            panel3.BackColor = SystemColors.ControlLight;
            panel4.BackColor = SystemColors.ControlLight;
            panel5.BackColor = SystemColors.ControlLight;
        }

        private void ColorearBackgroundTabs(int tab)
        {
            switch(tab)
            {
                case 0:
                    panel3.BackColor = SystemColors.ControlDark;
                    break;
                case 1:
                    panel4.BackColor = SystemColors.ControlDark;
                    break;
                case 2:
                    panel5.BackColor = SystemColors.ControlDark;
                    break;
            }
        }

        private void MostrarTab(int tab)
        {
            panel_1.Visible = false;
            panel_2.Visible = false;
            panel_3.Visible = false;

            switch (tab)
            {
                case 0:
                    panel_1.Visible = true;
                    break;
                case 1:
                    panel_2.Visible = true;
                    break;
                case 2:
                    panel_3.Visible = true;
                    break;
            }
        }

        private void tab1_Click(object sender, EventArgs e)
        {
            SelectedTab = 0;
        }

        private void tab2_Click(object sender, EventArgs e)
        {
            SelectedTab = 1;
            customListView3.Columns[1].Width = -2;
        }

        private void tab3_Click(object sender, EventArgs e)
        {
            SelectedTab = 2;
        }

        private void customListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            ListViewVisualStyles.DibujarItemListView(sender, e);
        }

        private void customListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            ListViewVisualStyles.DibujarCabeceras(sender, e);
        }

        private void customListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            ListViewVisualStyles.DibujarSubItemListView(sender, e);
        }

        private void TabControlView_Resize(object sender, EventArgs e)
        {
            customListView1.Columns[10].Width = -2;
            customListView3.Columns[1].Width = -2;
        }
    }
}
