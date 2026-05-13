using GestionFarmaciaDatos;
using GestionFarmaciaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFarmaciaLogicaNegocio
{
    public static class DashboardNegocio
    {
        public static List<DashboardEntidades> Top5Productos()
        {
            return DashboardDatos.ObtenerTop5ProductosMasVendidos();
        }

        public static List<DashboardEntidades> IngresosPorFecha()
        {
            return DashboardDatos.ObtenerIngresosPorFecha();
        }
    }
}
