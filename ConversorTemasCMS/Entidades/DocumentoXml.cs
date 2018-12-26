using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorTemasCMS.Entidades
{
    public class DocumentoXml: TipoDocumentoEntrada
    {
        #region Constantes

        private const String CLASE = "Conversor.Entidades.DocumentoXml";

        #endregion

        #region Atributos

        private Log _log = Log.GetInstance();

        private DataSet _documentoXml = new DataSet();

        #endregion

        #region Propiedades

        public DataSet DocumentoConfiguracion
        {
            get { return _documentoXml; }
            set { _documentoXml = value; }
        }

        #endregion

        #region Constructores
        #endregion

        #region Métodos públicos

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void ObtenerDocumentoConfiguracion()
        {
            try
            {
                if (File.Exists(RutaArchivo))
                {
                    _documentoXml.ReadXml(RutaArchivo);
                }
            }
            catch (Exception ex)
            {
                String metodo = "public void ObtenerDocumentoConfiguracion()";
                String error = String.Format("Error en el método {0} de la clase {1}| {2}", metodo, CLASE, ex.Message);
                _log.Add(Log.Modo.Error, error);
            }
        }

        #endregion
    }
}
