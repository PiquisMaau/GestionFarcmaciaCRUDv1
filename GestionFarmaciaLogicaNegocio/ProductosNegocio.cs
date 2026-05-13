using GestionFarmaciaDatos;
using GestionFarmaciaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFarmaciaLogicaNegocio
{
    public static class ProductosNegocio
    {
        public static List<PrductosEntidades> DevolverListaProductos()
        {
            ProductosDatos datos = new ProductosDatos();
            return datos.DevolverListaProductos();
        }
        public static bool GuardarProducto(PrductosEntidades producto)
        {
            if (string.IsNullOrWhiteSpace(producto.NombreComercial))
            {
                throw new Exception("El Nombre Comercial es obligatorio.");
            }
            if (producto.Precio <= 0)
            {
                throw new Exception("El precio debe ser mayor a cero.");
            }
            if (producto.Stock < 0)
            {
                throw new Exception("El stock no puede ser negativo.");
            }

            ProductosDatos datos = new ProductosDatos();

            if (producto.ProductoID == 0) // Es un nuevo producto
            {
                var productoInsertado = ProductosDatos.Nuevo(producto);
                return productoInsertado != null;
            }
            else // Es una actualización
            {
                return datos.Actualizar(producto);
            }
        }

      

        public static PrductosEntidades CargarProductoPorID(int id)
        {
            ProductosDatos datos = new ProductosDatos();
            return datos.CargarProductoPorID(id);
        }

        public static bool EliminarProductoPorId(int id)
        {
            return ProductosDatos.EliminarProductoPorId(id);
        }
    }
}



