using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConversorTemasCMS
{
    static class LanzadorAplicacion
    {
        public static VistaPrincipal Formulario
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public static VistaPrincipal VistaPrincipal
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VistaPrincipal());
        }
    }
}
