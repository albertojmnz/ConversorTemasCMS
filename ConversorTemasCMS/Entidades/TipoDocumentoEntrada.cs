using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorTemasCMS.Entidades
{
    public class TipoDocumentoEntrada
    {
        #region Constantes

        private const String CLASE = "Conversor.Entidades.TipoDocumentoEntrada";

        #endregion

        #region Atributos

        private Log _log = Log.GetInstance();

        private String _nombreArchivo = String.Empty;
        private String _rutaArchivo = String.Empty;

        #endregion

        #region Propiedades

        public String NombreArchivo
        {
            get { return _nombreArchivo; }
            set { _nombreArchivo = value; }
        }

        public String RutaArchivo
        {
            get { return _rutaArchivo; }
            set { _rutaArchivo = value; }
        }

        #endregion

        #region Constructores
        #endregion

        #region Métodos públicos

        /// <summary>
        /// Carga los datos del archivo de entrada
        /// </summary>
        /// <returns></returns>
        public void CargarDatosArchivo(String ruta)
        {
            try
            {
                // Obtenemos el nombre del archivo
                _nombreArchivo = ruta.Substring(ruta.LastIndexOf(@"\") + 1);
                String rutaDestino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\temp");

                if (!Directory.Exists(rutaDestino))
                {
                    Directory.CreateDirectory(rutaDestino);
                }

                File.Copy(ruta, Path.Combine(rutaDestino, _nombreArchivo), true);

                _rutaArchivo =  Path.Combine(rutaDestino, _nombreArchivo);
            }
            catch (Exception ex)
            {
                String metodo = "public String CargarDatosArchivo(String ruta)";
                String error = String.Format("Error en el método {0} de la clase {1}| {2}", metodo, CLASE, ex.Message);
                _log.Add(Log.Modo.Error, error);
            }
        }

        #endregion
    }
}
