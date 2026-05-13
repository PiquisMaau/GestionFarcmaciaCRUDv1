using GestionFarmaciaDatos;
using GestionFarmaciaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFarmaciaLogicaNegocio
{
    public static class VentasNegocio
    {
        public static bool ProcesarVenta(VentasEntidades venta, List<DetallesVentasEntidades> carrito)
        {
            PrductosEntidades productos;
            if (venta.ClienteID <= 0)
            {
                throw new Exception("Debe buscar y seleccionar un cliente válido antes de facturar.");
            }

            if (carrito == null || !carrito.Any())
            {
                throw new Exception("El carrito de compras está vacío. Agregue al menos un producto.");
            }

            foreach (var item in carrito)
            {
                if (item.Cantidad <= 0)
                    throw new Exception($"La cantidad para el producto '{item.ProductoID}' debe ser mayor a cero.");
            }

            // 2. Si todo está correcto, enviamos a la capa de datos
            return VentasDatos.RegistrarVentaCompleta(venta, carrito);
        }
    }
}
