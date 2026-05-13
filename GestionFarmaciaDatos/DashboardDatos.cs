using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionFarmaciaEntidades;

namespace GestionFarmaciaDatos
{
    public class DashboardDatos
    {
        public static List<DashboardEntidades> ObtenerTop5ProductosMasVendidos()
        {
            List<DashboardEntidades> lista = new List<DashboardEntidades>();
            using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionFarmaciaBD))
            {
                conexion.Open();
                // Cruzamos DetallesVentas con Productos para tener los nombres, y sumamos las cantidades
                string query = @"SELECT TOP 5 P.NombreComercial AS Etiqueta, SUM(DV.Cantidad) AS Valor 
                                 FROM DetallesVentas DV 
                                 INNER JOIN Productos P ON DV.ProductoID = P.ProductoID 
                                 GROUP BY P.NombreComercial 
                                 ORDER BY Valor DESC";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DashboardEntidades
                            {
                                Etiqueta = dr["Etiqueta"].ToString(),
                                Valor = Convert.ToDecimal(dr["Valor"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public static List<DashboardEntidades> ObtenerIngresosPorFecha()
        {
            List<DashboardEntidades> lista = new List<DashboardEntidades>();
            using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionFarmaciaBD))
            {
                conexion.Open();
                string query = @"SELECT CAST(FechaVenta AS DATE) AS Etiqueta, SUM(Total) AS Valor 
                                 FROM Ventas 
                                 GROUP BY CAST(FechaVenta AS DATE) 
                                 ORDER BY Etiqueta ASC";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new DashboardEntidades
                            {
                                Etiqueta = Convert.ToDateTime(dr["Etiqueta"]).ToString("dd/MM/yyyy"),
                                Valor = Convert.ToDecimal(dr["Valor"])
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}

