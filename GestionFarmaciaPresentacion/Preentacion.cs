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
using GestionFarmaciaEntidades;

namespace GestionFarmaciaPresentacion
{
    public partial class Preentacion : Form
    {
        public Preentacion()
        {
            InitializeComponent();
        }

        private void Preentacion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormVentas venta = new FormVentas();
            venta.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormProductos productos = new FormProductos();
            productos.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormClientes clientes = new FormClientes();
            clientes.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormDashboard dashboard = new FormDashboard();
            dashboard.ShowDialog();
        }
    }
}
