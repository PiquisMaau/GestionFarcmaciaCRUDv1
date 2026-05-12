using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFarmaciaEntidades
{
    public class ClientesEntidades
    {

        public int ClienteID { get; set; }
        public string CedulaRuc { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }

        public string NombreCompleto => $"{Nombre1} {Nombre2} {Apellido1} {Apellido2}".Trim();
    }
}
