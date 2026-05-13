using GestionFarmaciaEntidades;
using GestionFarmaciaLogicaNegocio;
using System;
using System.ComponentModel;
using System.Linq;
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

        private void FormVentas_Load_1(object sender, EventArgs e)
        {
            dgvDetalleVenta.DataSource = carrito;
            dtpFechaVenta.Value = DateTime.Now;

            ConfigurarGrilla();
            InicializarValoresDeVenta();
        }

      
        private void ConfigurarGrilla()
        {
            if (dgvDetalleVenta.Columns.Contains("DetalleID")) dgvDetalleVenta.Columns["DetalleID"].Visible = false;
            if (dgvDetalleVenta.Columns.Contains("NumComprobante")) dgvDetalleVenta.Columns["NumComprobante"].Visible = false;
            if (dgvDetalleVenta.Columns.Contains("ProductoID")) dgvDetalleVenta.Columns["ProductoID"].Visible = false;

            if (dgvDetalleVenta.Columns.Contains("PrecioUnitario")) dgvDetalleVenta.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
            if (dgvDetalleVenta.Columns.Contains("Subtotal")) dgvDetalleVenta.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
        }

        private void InicializarValoresDeVenta()
        {
            Random random = new Random();
            var numero = random.Next(1, 1000);
            string numeroComprobante = dtpFechaVenta.Value.Year.ToString() + "-UTA-" + numero.ToString("D4"); 

            labelNumeroComprobante.Text = numeroComprobante;
        }

        private void LimpiarCajasProducto()
        {
            txtb_NombreComercial.Clear();
            txtb_NombreGenerico.Clear();
            txtb_Presentacion.Clear();
            txtb_Precio.Clear();
            txtb_Cantidad.Clear();
            productoActual = new PrductosEntidades(); 
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

       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string cedulaBuscar = txtbCedulaRuc.Text.Trim();

            if (string.IsNullOrEmpty(cedulaBuscar))
            {
                MessageBox.Show("Ingrese una cédula para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Cliente no encontrado. Debe registrarlo primero en Mantenimiento de Clientes.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Productos_Click(object sender, EventArgs e)
        {
            SeleccionProductos seleccion = new SeleccionProductos();

            if (seleccion.ShowDialog() == DialogResult.OK)
            {
                productoActual = seleccion.ProductoSeleccionado;

                if (productoActual != null)
                {
                    txtb_NombreComercial.Text = productoActual.NombreComercial;
                    txtb_NombreGenerico.Text = productoActual.NombreGenerico;
                    txtb_Presentacion.Text = productoActual.Presentacion;
                    txtb_Precio.Text = productoActual.Precio.ToString("0.00");

                    txtb_Cantidad.Focus(); 
                }
            }
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (productoActual == null || productoActual.ProductoID == 0)
                {
                    MessageBox.Show("Primero debe buscar y seleccionar un producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtb_Cantidad.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida mayor a cero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal precio = Convert.ToDecimal(txtb_Precio.Text);

                DetallesVentasEntidades nuevoItem = new DetallesVentasEntidades
                {
                    ProductoID = productoActual.ProductoID,
                    NombreProducto = txtb_NombreComercial.Text,      
                    PresentacionProducto = txtb_Presentacion.Text,   
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
                MessageBox.Show(ex.Message, "Error al agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Botón de Procesar Venta
        {
            try
            {
                if (clienteActual == null || clienteActual.ClienteID == 0)
                {
                    MessageBox.Show("Debe buscar un cliente válido antes de facturar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (carrito.Count == 0)
                {
                    MessageBox.Show("El carrito de compras está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                    InicializarValoresDeVenta(); 

                    txtbCedulaRuc.Clear();
                    txtbNombres.Clear();
                    txtbApellidos.Clear();
                    txtbTelefono.Clear();
                    txtbDireccion.Clear();
                    txtbCorreo.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al facturar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgv_Venta_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void labelNumeroComprobante_Click(object sender, EventArgs e) { }
        private void btnBuscarCliente_Click(object sender, EventArgs e) { }
        private void btnAgregar_Click(object sender, EventArgs e) { }
        private void btnProcesarVenta_Click(object sender, EventArgs e) { }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Salir del registro de una Venta?",
               "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}