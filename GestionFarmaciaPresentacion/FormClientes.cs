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

namespace GestionFarmaciaPresentacion
{
    public partial class FormClientes : Form
    {
        // Crear Objeto tipo cliente
        ClientesEntidades cliente = new ClientesEntidades();

        public FormClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarListadoClientesEnDataGridView();
        }

        private void CargarListadoClientesEnDataGridView()
        {
            // Vinculamos el DataGridView (el área gris de tu imagen) con la lista de la BD
            dataGridView1.DataSource = ClientesNegocio.DevolverListaClientes();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            GuardarCliente();
        }

        private void GuardarCliente()
        {
            // Asignamos los valores de las cajas de texto a las propiedades de la entidad
            cliente.CedulaRuc = textBoxCedulaa.Text.Trim();
            cliente.Nombre1 = textBoxNombre1.Text.Trim().ToUpper();
            cliente.Nombre2 = textBoxNombre2.Text.Trim().ToUpper();
            cliente.Apellido1 = textBoxApellido1.Text.Trim().ToUpper();
            cliente.Apellido2 = textBoxApellido2.Text.Trim().ToUpper();
            cliente.FechaNacimiento = dateTimePicker1.Value;
            cliente.Telefono = textBoxTelefono.Text.Trim();
            cliente.Direccion = textBoxDireccion.Text.Trim().ToUpper();
            cliente.Correo = textBoxCorreo.Text.Trim();

            // Enviamos el objeto a la Capa de Negocio para guardar o actualizar
            bool exito = ClientesNegocio.GuardarCliente(cliente); // Asumiendo que tu BLL maneja si es Nuevo o Actualización

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
            try
            {
                // Verificamos que no se haya hecho clic en los encabezados
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

        private void CargarValoresClientePorId(int id)
        {
            // Buscamos el cliente en la BD usando la Capa de Negocio
            cliente = ClientesNegocio.CargarClientePorID(id);

            if (cliente != null)
            {
                // Llenamos el formulario con los datos recuperados
                txtID.Text = cliente.ClienteID.ToString();
                txtCedula.Text = cliente.CedulaRuc;
                txtNombre1.Text = cliente.Nombre1;
                txtNombre2.Text = cliente.Nombre2;
                txtApellido1.Text = cliente.Apellido1;
                txtApellido2.Text = cliente.Apellido2;
                dtpFechaNacimiento.Value = cliente.FechaNacimiento;
                txtTelefono.Text = cliente.Telefono;
                txtDireccion.Text = cliente.Direccion;
                txtCorreo.Text = cliente.Correo;
            }
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            EncerarCamposParaNuevoRegistro();
        }

        private void EncerarCamposParaNuevoRegistro()
        {
            // Al instanciar de nuevo, se limpia el objeto en memoria
            cliente = new ClientesEntidades();

            // Limpiamos visualmente las cajas de texto
            txtID.Clear();
            txtCedula.Clear();
            txtNombre1.Clear();
            txtNombre2.Clear();
            txtApellido1.Clear();
            txtApellido2.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCorreo.Clear();

            txtCedula.Focus(); // Ponemos el cursor en la primera caja
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            EliminarCliente();
        }

        private void EliminarCliente()
        {
            // Validamos que haya un cliente seleccionado (que tenga un ID válido)
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
    }
}
