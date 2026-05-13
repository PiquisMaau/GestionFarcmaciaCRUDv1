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
    public partial class SeleccionProductos : Form
    {
            public PrductosEntidades ProductoSeleccionado { get; set; }

            public SeleccionProductos()
            {
                InitializeComponent();
            }

            private void Form_Venta_Load(object sender, EventArgs e)
            {
            }

            private void CargarDatosProductosEnDataGrid()
            {
                dgvProductos.DataSource = ProductosNegocio.DevolverListaProductos();

                if (dgvProductos.Columns.Contains("ProductoID"))
                    dgvProductos.Columns["ProductoID"].Visible = false;

                if (dgvProductos.Columns.Contains("FechaAdqusicion"))
                    dgvProductos.Columns["FechaAdqusicion"].Visible = false;

                if (dgvProductos.Columns.Contains("Precio"))
                    dgvProductos.Columns["Precio"].DefaultCellStyle.Format = "C2";
            }

            private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                
            }

            private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
            private void label1_Click(object sender, EventArgs e) { }
            private void panel1_Paint(object sender, PaintEventArgs e) { }
            private void groupBox1_Enter(object sender, EventArgs e) { }

        private void SeleccionProductos_Load(object sender, EventArgs e)
        {
            CargarDatosProductosEnDataGrid();

        }

        private void dgvProductos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvProductos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    PrductosEntidades tmpProducto = new PrductosEntidades();

                    tmpProducto.ProductoID = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["ProductoID"].Value);
                    tmpProducto.NombreComercial = dgvProductos.Rows[e.RowIndex].Cells["NombreComercial"].Value.ToString();
                    tmpProducto.NombreGenerico = dgvProductos.Rows[e.RowIndex].Cells["NombreGenerico"].Value.ToString();
                    tmpProducto.Presentacion = dgvProductos.Rows[e.RowIndex].Cells["Presentacion"].Value.ToString();

                    tmpProducto.Precio = Convert.ToDecimal(dgvProductos.Rows[e.RowIndex].Cells["Precio"].Value);
                    tmpProducto.Stock = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["Stock"].Value);

                    ProductoSeleccionado = tmpProducto;


                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }

