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
    public partial class FormVentas : Form
    {
       
            private ClientesEntidades clienteActual = new ClientesEntidades();

            private PrductosEntidades productoActual = new PrductosEntidades();

            private BindingList<DetallesVentasEntidades> carrito = new BindingList<DetallesVentasEntidades>();

            public FormVentas()
            {
                InitializeComponent();
            }

          

            private void ConfigurarGrilla()
            {
                dgvDetalleVenta.Columns["DetalleID"].Visible = false;
                dgvDetalleVenta.Columns["NumComprobante"].Visible = false;
                dgvDetalleVenta.Columns["ProductoID"].Visible = false;

                dgvDetalleVenta.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
                dgvDetalleVenta.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
            }

         
            private void btnBuscarCliente_Click(object sender, EventArgs e)
            {
                
            }

           
            private void btnAgregar_Click(object sender, EventArgs e)
            {
                
            }

          
            private void CalcularTotales()
            {
                decimal subtotal = 0;

                foreach (var item in carrito)
                {
                    subtotal += item.Subtotal;
                }

                decimal iva = subtotal * 0.15m;
                decimal total = subtotal + iva;

                txtb_Subtotal.Text = subtotal.ToString("0.00");
                txtb_IVA.Text = iva.ToString("0.00");
                txtb_Total.Text = total.ToString("0.00");
            }

            private void LimpiarCajasProducto()
            {
                txtb_NombreComercial.Clear();
                txtb_NombreGenerico.Clear();
                txtb_Presentacion.Clear();
                txtb_Precio.Clear();
                txtb_Cantidad.Clear();
                productoActual = new PrductosEntidades(); // Reiniciamos
            }

          
            
            private void btnProcesarVenta_Click(object sender, EventArgs e)
            {
               
            }

        private void dgv_Venta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string cedulaBuscar = txtbCedulaRuc.Text.Trim();

            if (string.IsNullOrEmpty(cedulaBuscar))
            {
                MessageBox.Show("Ingrese una cédula para buscar.");
                return;
            }

            clienteActual = ClientesNegocio.BuscarPorCedula(cedulaBuscar);

            if (clienteActual != null)
            {
                txtbNombres.Text = $"{clienteActual.Nombre1} {clienteActual.Nombre2}".Trim();
                txtbApellidos.Text = $"{clienteActual.Apellido1} {clienteActual.Apellido2}".Trim();
                txtbTelefono.Text = clienteActual.Telefono;
                txtbDireccion.Text = clienteActual.Direccion;
                txtbCorreo.Text = clienteActual.Correo;
            }
            else
            {
                MessageBox.Show("Cliente no encontrado. Debe registrarlo primero en Mantenimiento de Clientes.");
            }
        }

        private void btn_Productos_Click(object sender, EventArgs e)
        {
            SeleccionProductos seleccion = new SeleccionProductos();
            seleccion.ShowDialog();
            productoActual = seleccion.ProductoSeleccionado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                VentasEntidades cabeceraVenta = new VentasEntidades
                {
                    ClienteID = clienteActual.ClienteID,
                    FechaVenta = dtpFechaVenta.Value,
                    Total = Convert.ToDecimal(txtb_Total.Text)
                };

                if (VentasNegocio.ProcesarVenta(cabeceraVenta, carrito.ToList()))
                {
                    MessageBox.Show("¡Venta registrada con éxito!", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    carrito.Clear();
                    CalcularTotales();
                    clienteActual = new ClientesEntidades();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al facturar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!int.TryParse(txtb_Cantidad.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida mayor a cero.");
                    return;
                }

                decimal precio = Convert.ToDecimal(txtb_Precio.Text);

                DetallesVentasEntidades nuevoItem = new DetallesVentasEntidades
                {
                    ProductoID = productoActual.ProductoID,
                    //NombreProducto = txtb_NombreComercial.Text,
                    //PresentacionProducto = txtb_Presentacion.Text,
                    Cantidad = cantidad,
                    PrecioUnitario = precio,
                    Subtotal = cantidad * precio
                };

                carrito.Add(nuevoItem);
                CalcularTotales();
                LimpiarCajasProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormVentas_Load_1(object sender, EventArgs e)
        {
            dgvDetalleVenta.DataSource = carrito;
            dtpFechaVenta.Value = DateTime.Now;

            ConfigurarGrilla();
        }

        private void labelNumeroComprobante_Click(object sender, EventArgs e)
        {
        }
    }
    }
