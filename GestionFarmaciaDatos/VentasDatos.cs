using GestionFarmaciaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFarmaciaDatos
{
    public class VentasDatos
    {
        public static bool RegistrarVentaCompleta(VentasEntidades venta, List<DetallesVentasEntidades> carrito)
        {
            using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionFarmaciaBD))
            {
                conexion.Open();
                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmdVenta = new SqlCommand())
                        {
                            cmdVenta.Connection = conexion;
                            cmdVenta.Transaction = transaccion;
                            cmdVenta.CommandType = CommandType.Text;
                            cmdVenta.CommandText = @"INSERT INTO [dbo].[Ventas] (FechaVenta, ClienteID, Total) 
                                                     VALUES (@FechaVenta, @ClienteID, @Total);
                                                     SELECT SCOPE_IDENTITY();";

                            cmdVenta.Parameters.AddWithValue("@FechaVenta", venta.FechaVenta == DateTime.MinValue ? DateTime.Now : venta.FechaVenta);
                            cmdVenta.Parameters.AddWithValue("@ClienteID", venta.ClienteID);
                            cmdVenta.Parameters.AddWithValue("@Total", venta.Total);

                            int numComprobanteGenerado = Convert.ToInt32(cmdVenta.ExecuteScalar());

                            foreach (var item in carrito)
                            {
                                using (SqlCommand cmdDetalle = new SqlCommand())
                                {
                                    cmdDetalle.Connection = conexion;
                                    cmdDetalle.Transaction = transaccion;
                                    cmdDetalle.CommandText = @"INSERT INTO [dbo].[DetallesVentas] 
                                                              (NumComprobante, ProductoID, Cantidad, PrecioUnitario, Subtotal) 
                                                              VALUES (@NumComprobante, @ProductoID, @Cantidad, @PrecioUnitario, @Subtotal)";

                                    cmdDetalle.Parameters.AddWithValue("@NumComprobante", numComprobanteGenerado);
                                    cmdDetalle.Parameters.AddWithValue("@ProductoID", item.ProductoID);
                                    cmdDetalle.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                                    cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario);
                                    cmdDetalle.Parameters.AddWithValue("@Subtotal", item.Subtotal);

                                    cmdDetalle.ExecuteNonQuery();
                                }

                                using (SqlCommand cmdStock = new SqlCommand())
                                {
                                    cmdStock.Connection = conexion;
                                    cmdStock.Transaction = transaccion;
                                    cmdStock.CommandText = @"UPDATE [dbo].[Productos] 
                                                             SET Stock = Stock - @CantidadVendida 
                                                             WHERE ProductoID = @ProductoID";

                                    cmdStock.Parameters.AddWithValue("@CantidadVendida", item.Cantidad);
                                    cmdStock.Parameters.AddWithValue("@ProductoID", item.ProductoID);

                                    cmdStock.ExecuteNonQuery();
                                }
                            }
                        }

                        transaccion.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}
