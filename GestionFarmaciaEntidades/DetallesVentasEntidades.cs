using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFarmaciaEntidades
{
    public class DetallesVentasEntidades
    {
        public int DetalleID { get; set; }
        public int NumComprobante { get; set; } 
        public int ProductoID { get; set; } 
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public string NombreProducto { get; set; }
        public string PresentacionProducto { get; set; }
    }
}
