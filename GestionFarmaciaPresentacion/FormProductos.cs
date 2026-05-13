using GestionFarmaciaEntidades;
using GestionFarmaciaLogicaNegocio;
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
    public partial class FormProductos : Form
    {
        PrductosEntidades producto = new PrductosEntidades();

        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            CargarListadoProductosEnDataGridView();
        }

        private void CargarListadoProductosEnDataGridView()
        {
            dataGridView1.DataSource = ProductosNegocio.DevolverListaProductos();

            if (dataGridView1.Columns.Contains("Precio"))
            {
                dataGridView1.Columns["Precio"].DefaultCellStyle.Format = "C2";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void CargarValoresProductoPorId(int id)
        {
            producto = ProductosNegocio.CargarProductoPorID(id);

            if (producto != null)
            {
                textBoxIdProducto.Text = producto.ProductoID.ToString();
                textBoxNombreComercial.Text = producto.NombreComercial;
                textBoxNombreGenerico.Text = producto.NombreGenerico;
                dateTimePicker1.Value = producto.FechaAdqusicion;
                textBoxPresentacion.Text = producto.Presentacion;
                textBoxPrecio.Text = producto.Precio.ToString("0.00"); 
                textBoxStock.Text = producto.Stock.ToString();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
        }

        private void EncerarCampos()
        {
            producto = new PrductosEntidades();

            textBoxIdProducto.Clear();
            textBoxNombreComercial.Clear();
            textBoxNombreGenerico.Clear();
            dateTimePicker1.Value = DateTime.Now;
            textBoxPresentacion.Clear();
            textBoxPrecio.Clear();
            textBoxStock.Clear();

            textBoxNombreComercial.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación para asegurar que el usuario ingrese números en Precio y Stock
                if (!decimal.TryParse(textBoxPrecio.Text, out decimal precioIngresado))
                {
                    MessageBox.Show("Por favor, ingrese un precio válido (solo números y comas/puntos decimales).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBoxStock.Text, out int stockIngresado))
                {
                    MessageBox.Show("Por favor, ingrese un número entero válido para el stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Llenamos la entidad con los datos del formulario
                producto.NombreComercial = textBoxNombreComercial.Text.Trim();
                producto.NombreGenerico = textBoxNombreGenerico.Text.Trim();
                producto.FechaAdqusicion = dateTimePicker1.Value;
                producto.Presentacion = textBoxPresentacion.Text.Trim();
                producto.Precio = precioIngresado;
                producto.Stock = stockIngresado;

                // Enviamos a guardar o actualizar
                if (ProductosNegocio.GuardarProducto(producto))
                {
                    MessageBox.Show("El producto se guardó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListadoProductosEnDataGridView();
                    EncerarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {

            if (producto.ProductoID <= 0)
            {
                MessageBox.Show("Seleccione un producto del listado para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"¿Está seguro de eliminar el producto '{producto.NombreComercial}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ProductosNegocio.EliminarProductoPorId(producto.ProductoID))
                {
                    MessageBox.Show("Producto eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EncerarCampos();
                    CargarListadoProductosEnDataGridView();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el producto. Es posible que ya tenga ventas registradas asociadas a él.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ProductoID"].Value.ToString());
                    CargarValoresProductoPorId(id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el producto: " + ex.Message);
            }
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            EncerarCampos();

        }
    }
}
