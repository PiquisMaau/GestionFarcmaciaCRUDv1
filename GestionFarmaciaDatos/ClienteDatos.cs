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
    public class ClienteDatos
    {

        public static ClientesEntidades Nuevo(ClientesEntidades cliente)
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

                        // Consulta SQL adaptada a tu nueva tabla Clientes
                        cmd.CommandText = @"INSERT INTO [dbo].[Clientes] 
                                           ([CedulaRuc]
                                           ,[Nombre1]
                                           ,[Nombre2]
                                           ,[Apellido1]
                                           ,[Apellido2]
                                           ,[FechaNacimiento]
                                           ,[Telefono]
                                           ,[Direccion]
                                           ,[Correo]) 
                                     VALUES 
                                           (@CedulaRuc, @Nombre1, @Nombre2, @Apellido1, @Apellido2,
                                            @FechaNacimiento, @Telefono, @Direccion, @Correo);
                                     
                                     SELECT SCOPE_IDENTITY();";

                        cmd.Parameters.AddWithValue("@CedulaRuc", cliente.CedulaRuc);
                        cmd.Parameters.AddWithValue("@Nombre1", cliente.Nombre1);


                        cmd.Parameters.AddWithValue("@Nombre2", string.IsNullOrEmpty(cliente.Nombre2) ? DBNull.Value : (object)cliente.Nombre2);

                        cmd.Parameters.AddWithValue("@Apellido1", cliente.Apellido1);
                        cmd.Parameters.AddWithValue("@Apellido2", string.IsNullOrEmpty(cliente.Apellido2) ? DBNull.Value : (object)cliente.Apellido2);

                        if (cliente.FechaNacimiento == DateTime.MinValue)
                            cmd.Parameters.AddWithValue("@FechaNacimiento", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);

                        cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrEmpty(cliente.Telefono) ? DBNull.Value : (object)cliente.Telefono);
                        cmd.Parameters.AddWithValue("@Direccion", string.IsNullOrEmpty(cliente.Direccion) ? DBNull.Value : (object)cliente.Direccion);
                        cmd.Parameters.AddWithValue("@Correo", string.IsNullOrEmpty(cliente.Correo) ? DBNull.Value : (object)cliente.Correo);

                        var ID_Cliente = Convert.ToInt32(cmd.ExecuteScalar());

                        cliente.ClienteID = ID_Cliente;

                        return cliente;
                    }
                }
            }
            catch (Exception e)
            {
                var error = e.Message;
                return null;
            }
        }

        public bool Actualizar(ClientesEntidades cliente)
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
                        cmd.CommandText = @"UPDATE [dbo].[Clientes] 
                                    SET [CedulaRuc] = @CedulaRuc, [Nombre1] = @Nombre1, [Nombre2] = @Nombre2, 
                                        [Apellido1] = @Apellido1, [Apellido2] = @Apellido2, 
                                        [FechaNacimiento] = @FechaNacimiento, [Telefono] = @Telefono, 
                                        [Direccion] = @Direccion, [Correo] = @Correo 
                                    WHERE ClienteID = @ClienteID";

                        cmd.Parameters.AddWithValue("@ClienteID", cliente.ClienteID);
                        cmd.Parameters.AddWithValue("@CedulaRuc", cliente.CedulaRuc);
                        cmd.Parameters.AddWithValue("@Nombre1", cliente.Nombre1);
                        cmd.Parameters.AddWithValue("@Nombre2", (object)cliente.Nombre2 ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Apellido1", cliente.Apellido1);
                        cmd.Parameters.AddWithValue("@Apellido2", (object)cliente.Apellido2 ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Telefono", (object)cliente.Telefono ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Direccion", (object)cliente.Direccion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Correo", (object)cliente.Correo ?? DBNull.Value);

                        return cmd.ExecuteNonQuery() > 0; // Retorna true si se actualizó al menos una fila
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<ClientesEntidades> DevolverListaClientes()
        {
            List<ClientesEntidades> lista = new List<ClientesEntidades>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionFarmaciaBD))
                {
                    conexion.Open();
                    string query = "SELECT * FROM Clientes";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lista.Add(new ClientesEntidades
                                {
                                    ClienteID = Convert.ToInt32(dr["ClienteID"]),
                                    CedulaRuc = dr["CedulaRuc"].ToString(),
                                    Nombre1 = dr["Nombre1"].ToString(),
                                    Nombre2 = dr["Nombre2"].ToString(),
                                    Apellido1 = dr["Apellido1"].ToString(),
                                    Apellido2 = dr["Apellido2"].ToString(),
                                    FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                                    Telefono = dr["Telefono"].ToString(),
                                    Direccion = dr["Direccion"].ToString(),
                                    Correo = dr["Correo"].ToString()
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
        public ClientesEntidades CargarClientePorID(int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexionFarmaciaBD))
                {
                    conexion.Open();
                    string query = "SELECT * FROM Clientes WHERE ClienteID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                return new ClientesEntidades
                                {
                                    ClienteID = Convert.ToInt32(dr["ClienteID"]),
                                    CedulaRuc = dr["CedulaRuc"].ToString(),
                                    Nombre1 = dr["Nombre1"].ToString(),
                                    Nombre2 = dr["Nombre2"].ToString(),
                                    Apellido1 = dr["Apellido1"].ToString(),
                                    Apellido2 = dr["Apellido2"].ToString(),
                                    FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                                    Telefono = dr["Telefono"].ToString(),
                                    Direccion = dr["Direccion"].ToString(),
                                    Correo = dr["Correo"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch { }
            return null;
        }

        public static bool EliminarClientePorId(int id)
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

                        cmd.CommandText = @"DELETE FROM [dbo].[Clientes] WHERE ClienteID = @id";
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
