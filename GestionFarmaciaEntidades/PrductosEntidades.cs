using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFarmaciaEntidades
{
    public class PrductosEntidades
    {
        public int ProductoID { get; set; }
        public string NombreComercial { get; set; }
        public string NombreGenerico { get; set; }
        public DateTime FechaAdqusicion { get; set; }

        public string Presentacion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
