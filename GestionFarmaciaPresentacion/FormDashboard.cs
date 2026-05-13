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
using System.Windows.Forms.DataVisualization.Charting;

namespace GestionFarmaciaPresentacion
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void CargarGraficoTopProductos()
        {
            List<DashboardEntidades> datos = DashboardNegocio.Top5Productos();

            chartProductos.Series.Clear();
            chartProductos.Titles.Clear();

            chartProductos.Titles.Add("Top 5 Medicamentos más Vendidos");

            Series serie = new Series("Productos");

            serie.ChartType = SeriesChartType.Doughnut;

            serie.IsValueShownAsLabel = true;

            foreach (var item in datos)
            {
                serie.Points.AddXY(item.Etiqueta, item.Valor);
            }

            chartProductos.Series.Add(serie);
        }

        private void CargarGraficoIngresos()
        {
            List<DashboardEntidades> datos = DashboardNegocio.IngresosPorFecha();

            chartIngresos.Series.Clear();
            chartIngresos.Titles.Clear();

            chartIngresos.Titles.Add("Evolución de Ingresos por Día");

            Series serie = new Series("Ingresos");

            serie.ChartType = SeriesChartType.Column;

            serie.Color = System.Drawing.Color.SteelBlue;
            serie.IsValueShownAsLabel = true;

            foreach (var item in datos)
            {
                serie.Points.AddXY(item.Etiqueta, item.Valor);
                serie.Points.Last().Label = "$" + item.Valor.ToString("0.00");
            }

            chartIngresos.Series.Add(serie);

            chartIngresos.Legends[0].Enabled = false;
        }

        private void chartProductos_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            CargarGraficoTopProductos();
            CargarGraficoIngresos();
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Salir de Dashboard?",
               "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
