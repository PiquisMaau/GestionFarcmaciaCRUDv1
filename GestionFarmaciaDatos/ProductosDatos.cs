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
    public class ProductosDatos
    {
        public static PrductosEntidades Nuevo(PrductosEntidades producto)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionFarmaciaBD))
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conexion;
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = @"INSERT INTO [dbo].[Productos] 
                                                   ([NombreComercial]
                                                   ,[NombreGenerico]
                                                   ,[FechaAdqusicion]
                                                   ,[Presentacion]
                                                   ,[Precio]
                                                   ,[Stock]) 
                                             VALUES 
                                                   (@NombreComercial, @NombreGenerico, @FechaAdqusicion, 
                                                    @Presentacion, @Precio, @Stock);
                                             
                                             SELECT SCOPE_IDENTITY();";

                        cmd.Parameters.AddWithValue("@NombreComercial", producto.NombreComercial);
                        cmd.Parameters.AddWithValue("@NombreGenerico", producto.NombreGenerico);

                        if (producto.FechaAdqusicion == DateTime.MinValue)
                            cmd.Parameters.AddWithValue("@FechaAdqusicion", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@FechaAdqusicion", producto.FechaAdqusicion);

                        cmd.Parameters.AddWithValue("@Presentacion", producto.Presentacion);
                        cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                        cmd.Parameters.AddWithValue("@Stock", producto.Stock);

                        var ID_Producto = Convert.ToInt32(cmd.ExecuteScalar());
                        producto.ProductoID = ID_Producto;

                        return producto;
                    }
                }
            }
            catch (Exception e)
            {
                var error = e.Message;
                return null;
            }
        }

        public bool Actualizar(PrductosEntidades producto)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionFarmaciaBD))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conexion;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"UPDATE [dbo].[Productos] 
                                            SET [NombreComercial] = @NombreComercial, 
                                                [NombreGenerico] = @NombreGenerico, 
                                                [FechaAdqusicion] = @FechaAdqusicion, 
                                                [Presentacion] = @Presentacion, 
                                                [Precio] = @Precio, 
                                                [Stock] = @Stock 
                                            WHERE ProductoID = @ProductoID";

                        cmd.Parameters.AddWithValue("@ProductoID", producto.ProductoID);
                        cmd.Parameters.AddWithValue("@NombreComercial", producto.NombreComercial);
                        cmd.Parameters.AddWithValue("@NombreGenerico", producto.NombreGenerico);

                        if (producto.FechaAdqusicion == DateTime.MinValue)
                            cmd.Parameters.AddWithValue("@FechaAdqusicion", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@FechaAdqusicion", producto.FechaAdqusicion);

                        cmd.Parameters.AddWithValue("@Presentacion", producto.Presentacion);
                        cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                        cmd.Parameters.AddWithValue("@Stock", producto.Stock);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<PrductosEntidades> DevolverListaProductos()
        {
            List<PrductosEntidades> lista = new List<PrductosEntidades>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionFarmaciaBD))
                {
                    conexion.Open();
                    string query = "SELECT * FROM Productos";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new PrductosEntidades
                                {
                                    ProductoID = Convert.ToInt32(dr["ProductoID"]),
                                    NombreComercial = dr["NombreComercial"].ToString(),
                                    NombreGenerico = dr["NombreGenerico"].ToString(),
                                    FechaAdqusicion = dr["FechaAdqusicion"] != DBNull.Value ? Convert.ToDateTime(dr["FechaAdqusicion"]) : DateTime.MinValue,
                                    Presentacion = dr["Presentacion"].ToString(),
                                    Precio = Convert.ToDecimal(dr["Precio"]),
                                    Stock = Convert.ToInt32(dr["Stock"])
                                });
                            }
                        }
                    }
                }
                return lista;
            }
            catch
            {
                return null;
            }
        }

        public PrductosEntidades CargarProductoPorID(int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionFarmaciaBD))
                {
                    conexion.Open();
                    string query = "SELECT * FROM Productos WHERE ProductoID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                return new PrductosEntidades
                                {
                                    ProductoID = Convert.ToInt32(dr["ProductoID"]),
                                    NombreComercial = dr["NombreComercial"].ToString(),
                                    NombreGenerico = dr["NombreGenerico"].ToString(),
                                    FechaAdqusicion = dr["FechaAdqusicion"] != DBNull.Value ? Convert.ToDateTime(dr["FechaAdqusicion"]) : DateTime.MinValue,
                                    Presentacion = dr["Presentacion"].ToString(),
                                    Precio = Convert.ToDecimal(dr["Precio"]),
                                    Stock = Convert.ToInt32(dr["Stock"])
                                };
                            }
                        }
                    }
                }
            }
            catch { }
            return null;
        }

        public static bool EliminarProductoPorId(int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionFarmaciaBD))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conexion;
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = @"DELETE FROM [dbo].[Productos] WHERE ProductoID = @id";
                        cmd.Parameters.AddWithValue("@id", id);

                        int numeroFilasAfectadas = cmd.ExecuteNonQuery();
                        return numeroFilasAfectadas > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
