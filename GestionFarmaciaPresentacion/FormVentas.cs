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

            private void FrmVentas_Load(object sender, EventArgs e)
            {
                // Enlazamos la tabla gris al carrito
                dgvDetalleVenta.DataSource = carrito;
                dtpFechaVenta.Value = DateTime.Now;

                // Configuramos las columnas para que se vean bien
                ConfigurarGrilla();
            }

            private void ConfigurarGrilla()
            {
                // Ocultamos las llaves primarias que el usuario no necesita ver
                dgvDetalleVenta.Columns["DetalleID"].Visible = false;
                dgvDetalleVenta.Columns["NumComprobante"].Visible = false;
                dgvDetalleVenta.Columns["ProductoID"].Visible = false;

                // Damos formato de moneda a los precios
                dgvDetalleVenta.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
                dgvDetalleVenta.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
            }

            // ==========================================================
            // 1. LÓGICA DE AUTOCOMPLETADO POR CÉDULA
            // ==========================================================
            // Te sugiero programar esto en el evento 'KeyPress' o 'Leave' del txtCedula.
            // Aquí usaré un botón imaginario de la lupa (el cuadro de guiones de tu imagen)
            private void btnBuscarCliente_Click(object sender, EventArgs e)
            {
                string cedulaBuscar = txtCedulaRuc.Text.Trim();

                if (string.IsNullOrEmpty(cedulaBuscar))
                {
                    MessageBox.Show("Ingrese una cédula para buscar.");
                    return;
                }

                // Llamamos a la BLL (Asegúrate de crear este método en ClientesNegocio)
                clienteActual = ClientesNegocio.BuscarClientePorCedula(cedulaBuscar);

                if (clienteActual != null)
                {
                    // Autocompletamos los campos
                    txtNombres.Text = $"{clienteActual.Nombre1} {clienteActual.Nombre2}".Trim();
                    txtApellidos.Text = $"{clienteActual.Apellido1} {clienteActual.Apellido2}".Trim();
                    txtTelefono.Text = clienteActual.Telefono;
                    txtDireccion.Text = clienteActual.Direccion;
                    txtCorreo.Text = clienteActual.Correo;
                }
                else
                {
                    MessageBox.Show("Cliente no encontrado. Debe registrarlo primero en Mantenimiento de Clientes.");
                    // Opcional: Limpiar cajas
                }
            }

            // ==========================================================
            // 2. LÓGICA PARA AGREGAR AL CARRITO
            // ==========================================================
            private void btnAgregar_Click(object sender, EventArgs e)
            {
                try
                {
                    // Validamos que haya un producto seleccionado (simulado aquí)
                    // y que se haya ingresado una cantidad válida
                    if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
                    {
                        MessageBox.Show("Ingrese una cantidad válida mayor a cero.");
                        return;
                    }

                    // Asumimos que productoActual ya se llenó al usar el botón "Product"
                    decimal precio = Convert.ToDecimal(txtPrecio.Text);

                    DetallesVentasEntidades nuevoItem = new DetallesVentasEntidades
                    {
                        ProductoID = productoActual.ProductoID, // Reemplazar con el ID real
                        NombreProducto = txtNombreComercial.Text,
                        PresentacionProducto = txtPresentacion.Text,
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

            // ==========================================================
            // 3. CÁLCULO DE TOTALES (SUBTOTAL, IVA 15%, TOTAL)
            // ==========================================================
            private void CalcularTotales()
            {
                decimal subtotal = 0;

                // Sumamos todos los subtotales del carrito
                foreach (var item in carrito)
                {
                    subtotal += item.Subtotal;
                }

                // Ecuador actual: IVA 15%
                decimal iva = subtotal * 0.15m;
                decimal total = subtotal + iva;

                // Mostramos en las cajas de texto de abajo a la derecha
                txtSubTotal.Text = subtotal.ToString("0.00");
                txtIVA.Text = iva.ToString("0.00");
                txtTotal.Text = total.ToString("0.00");
            }

            private void LimpiarCajasProducto()
            {
                txtNombreComercial.Clear();
                txtNombreGenerico.Clear();
                txtPresentacion.Clear();
                txtPrecio.Clear();
                txtCantidad.Clear();
                productoActual = new PrductosEntidades(); // Reiniciamos
            }

            // ==========================================================
            // 4. PROCESAR VENTA (El botón que falta en tu diseño)
            // ==========================================================
            private void btnProcesarVenta_Click(object sender, EventArgs e)
            {
                try
                {
                    VentasEntidades cabeceraVenta = new VentasEntidades
                    {
                        ClienteID = clienteActual.ClienteID,
                        FechaVenta = dtpFechaVenta.Value,
                        Total = Convert.ToDecimal(txtTotal.Text)
                    };

                    // Convertimos el BindingList a un List normal para la capa de negocio
                    if (VentasNegocio.ProcesarVenta(cabeceraVenta, carrito.ToList()))
                    {
                        MessageBox.Show("¡Venta registrada con éxito!", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpiamos todo para la siguiente venta
                        carrito.Clear();
                        CalcularTotales();
                        clienteActual = new ClientesEntidades();
                        // Limpiar las cajas del cliente aquí...
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al facturar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        private void dgv_Venta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
    }
