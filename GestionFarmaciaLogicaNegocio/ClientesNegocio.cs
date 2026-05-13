using GestionFarmaciaDatos;
using GestionFarmaciaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFarmaciaLogicaNegocio
{
    public static class ClientesNegocio
    {
        public static bool GuardarCliente(ClientesEntidades cliente)
        {

            if (string.IsNullOrWhiteSpace(cliente.CedulaRuc))
            {
                throw new Exception("La Cédula o RUC es un campo obligatorio.");
            }
            if (string.IsNullOrWhiteSpace(cliente.Nombre1) || string.IsNullOrWhiteSpace(cliente.Apellido1))
            {
                throw new Exception("El primer nombre y el primer apellido son obligatorios.");
            }

            ClienteDatos datos = new ClienteDatos();

            if (cliente.ClienteID == 0)
            {
                var clienteInsertado = ClienteDatos.Nuevo(cliente);
                return clienteInsertado != null;
            }
            else
            {
                return datos.Actualizar(cliente);
            }
        }

        public static List<ClientesEntidades> DevolverListaClientes()
        {
            ClienteDatos datos = new ClienteDatos();
            return datos.DevolverListaClientes();
        }

        public static ClientesEntidades CargarClientePorID(int id)
        {
            ClienteDatos datos = new ClienteDatos();
            return datos.CargarClientePorID(id);
        }

        public static bool EliminarClientePorId(int id)
        {
            return ClienteDatos.EliminarClientePorId(id);
        }

        public static ClientesEntidades BuscarPorCedula(string cedula) 
        {
            return ClienteDatos.BuscarPorCedula(cedula);
        }
    }
}
