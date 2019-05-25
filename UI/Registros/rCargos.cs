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

namespace Projecto_Aplicada1.UI.Registros
{
    public partial class rCargos : Form
    {
        public rCargos()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            CargoIdnumericUpDown1.Value = 0;
            DescripciontextBox.Text = string.Empty;
            MyerrorProvider.Clear();
        }

        private void LlenaCampo(Cargos cargo)
        {
            CargoIdnumericUpDown1.Value = cargo.CargosId;
            DescripciontextBox.Text = cargo.Descripcion;
           
        }
        private Cargos LlenaClase()
        {
            Cargos cargo = new Cargos();
            cargo.CargosId = Convert.ToInt32(CargoIdnumericUpDown1.Value);
            cargo.Descripcion = DescripciontextBox.Text;


            return cargo;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Cargos cargo = CargosBLL.Buscar((int)CargoIdnumericUpDown1.Value);
            return (cargo != null);
        }

        private bool validar()
        {
            bool paso = true;
            MyerrorProvider.Clear();

            if (DescripciontextBox.Text == String.Empty)
            {
                MyerrorProvider.SetError(DescripciontextBox, "El campo Descripcion no puede estar vacio");
                DescripciontextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            Cargos cargo = new Cargos();
            int.TryParse(CargoIdnumericUpDown1.Text, out id);

            Limpiar();

            cargo = CargosBLL.Buscar(id);

            if (cargo != null)
            {
                MessageBox.Show("Cargo Encontrada");
                LlenaCampo(cargo);
            }
            else
            {
                MessageBox.Show("Persona no encontrada");
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Cargos cargo;
            bool paso = false;

            if (!validar())
                return;

            cargo = LlenaClase();
            Limpiar();

            //determinar si es guardar o modificar
            if (CargoIdnumericUpDown1.Value == 0)
                paso = CargosBLL.Guardar(cargo);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se peude modificar un cargo que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = CargosBLL.Modificar(cargo);
            }
            //informar el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            MyerrorProvider.Clear();
            int id;
            int.TryParse(CargoIdnumericUpDown1.Text, out id);

            Limpiar();

            if (CargosBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MyerrorProvider.SetError(CargoIdnumericUpDown1, "No se puede eliminar un usuario que no existe");
        }
    }
}
