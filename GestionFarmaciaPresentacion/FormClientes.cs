using GestionFarmaciaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionFarmaciaLogicaNegocio;

namespace GestionFarmaciaPresentacion
{
    public partial class FormClientes : Form
    {
        ClientesEntidades cliente = new ClientesEntidades();

        public FormClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
        }

        private void CargarListadoClientesEnDataGridView()
        {
            dataGridView1.DataSource = ClientesNegocio.DevolverListaClientes();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
        }

        private void GuardarCliente()
        {
            cliente.CedulaRuc = textBoxCedulaa.Text.Trim();
            cliente.Nombre1 = textBoxNombre1.Text.Trim().ToUpper();
            cliente.Nombre2 = textBoxNombre2.Text.Trim().ToUpper();
            cliente.Apellido1 = textBoxApellido1.Text.Trim().ToUpper();
            cliente.Apellido2 = textBoxApellido2.Text.Trim().ToUpper();
            cliente.FechaNacimiento = dateTimePicker1.Value;
            cliente.Telefono = textBoxTelefono.Text.Trim();
            cliente.Direccion = textBoxDireccion.Text.Trim().ToUpper();
            cliente.Correo = textBoxCorreo.Text.Trim();

            bool exito = ClientesNegocio.GuardarCliente(cliente);

            if (exito)
            {
                MessageBox.Show("Los datos del cliente se almacenaron correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarListadoClientesEnDataGridView();
                EncerarCamposParaNuevoRegistro();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void CargarValoresClientePorId(int id)
        {
            // Buscamos el cliente en la BD usando la Capa de Negocio
            cliente = ClientesNegocio.CargarClientePorID(id);

            if (cliente != null)
            {
                // Llenamos el formulario con los datos recuperados
                textBoxId.Text = cliente.ClienteID.ToString();
                textBoxCedulaa.Text = cliente.CedulaRuc;
                textBoxNombre1.Text = cliente.Nombre1;
                textBoxNombre2.Text = cliente.Nombre2;
                textBoxApellido1.Text = cliente.Apellido1;
                textBoxApellido2.Text = cliente.Apellido2;
                dateTimePicker1.Value = cliente.FechaNacimiento;
                textBoxTelefono.Text = cliente.Telefono;
                textBoxDireccion.Text = cliente.Direccion;
                textBoxCorreo.Text = cliente.Correo;
            }
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
        }

        private void EncerarCamposParaNuevoRegistro()
        {
            cliente = new ClientesEntidades();

            textBoxId.Clear();
            textBoxCedulaa.Clear();
            textBoxNombre1.Clear();
            textBoxNombre2.Clear();
            textBoxApellido1.Clear();
            textBoxApellido2.Clear();
            dateTimePicker1.Value = DateTime.Now;
            textBoxTelefono.Clear();
            textBoxDireccion.Clear();
            textBoxCorreo.Clear();

            textBoxCedulaa.Focus(); 
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
        }

        private void EliminarCliente()
        {
            if (cliente.ClienteID <= 0)
            {
                MessageBox.Show("Por favor, seleccione un cliente de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar permanentemente este cliente?",
                                "Eliminar registro",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question) == DialogResult.OK)
            {
                // Llamar a Negocio
                if (ClientesNegocio.EliminarClientePorId(cliente.ClienteID))
                {
                    MessageBox.Show("El registro se eliminó correctamente.",
                                    "Eliminar cliente",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    EncerarCamposParaNuevoRegistro();
                    CargarListadoClientesEnDataGridView();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el cliente. Verifique que no tenga ventas asociadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            EliminarCliente();

        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            EncerarCamposParaNuevoRegistro();

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            GuardarCliente();

        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarListadoClientesEnDataGridView();

        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Salir de Clientes?",
               "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ClienteID"].Value.ToString());
                    CargarValoresClientePorId(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el cliente: " + ex.Message);
            }
        }
    }
}
