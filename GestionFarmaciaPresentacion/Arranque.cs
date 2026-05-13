using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;

namespace GestionFarmaciaPresentacion
{
    internal static class Arranque
    {
        
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ¡AQUÍ ESTÁ LA MAGIA! 
            // Cambia el nombre que estaba aquí por "Preentacion"
            Application.Run(new Preentacion());
        }
    }
}
