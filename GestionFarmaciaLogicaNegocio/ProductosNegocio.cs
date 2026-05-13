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
    }
}

