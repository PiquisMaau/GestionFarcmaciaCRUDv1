using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFarmaciaEntidades
{
    public class VentasEntidades
    {
        public int NumComprobante { get; set; }
        public DateTime FechaVenta { get; set; }
        public int ClienteID { get; set; } 
        public decimal Total { get; set; }
    }
}
