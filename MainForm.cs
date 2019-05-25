using Projecto_Aplicada1.UI.Registros;
using Projecto_Aplicada1.UI.Consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projecto_Aplicada1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuario ver = new rUsuario();
            ver.MdiParent = this;
            ver.Show();
        }

        private void CargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rCargos ver = new rCargos();
            ver.MdiParent = this;
            ver.Show();
        }

        private void UsuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cUsuario ver = new cUsuario();
            ver.MdiParent = this;
            ver.Show();
        }

        private void CargosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cCargos ver = new cCargos();
            ver.MdiParent = this;
            ver.Show();
        }
    }
}
