using Projecto_Aplicada1.BLL;
using Projecto_Aplicada1.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projecto_Aplicada1.UI.Consultas
{
    public partial class cCargos : Form
    {
        public cCargos()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Cargos>();

            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0: //todo
                        listado = CargosBLL.Getlist(u => true);
                        break;
                    case 1: // ID
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = CargosBLL.Getlist(u => u.CargosId == id);
                        break;
                    case 2: //Cargo
                        listado = CargosBLL.Getlist(u => u.Descripcion.Contains(CriteriotextBox.Text));
                        break;
                }
                
            }
            else
            {
                listado = CargosBLL.Getlist(u => true);
            }

            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = listado;
        }
    }
}
