using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorTemasCMS.Entidades
{
    public class DocumentoHtml: TipoDocumentoEntrada
    {
        #region Constantes

        private const String CLASE = "Conversor.Entidades.DocumentoHtml";

        #endregion

        #region Atributos

        private Log _log = Log.GetInstance();

        private HtmlAgilityPack.HtmlDocument _documentoHtml = new HtmlAgilityPack.HtmlDocument();

        #endregion

        #region Propiedades

        public HtmlAgilityPack.HtmlDocument DocumentoTemaHtml
        {
            get { return _documentoHtml; }
            set { _documentoHtml = value; }
        }

        #endregion

        #region Constructores
        #endregion

        #region Métodos públicos

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void ObtenerDocumentoHtml()
        {
            try
            {
                if (File.Exists(RutaArchivo))
                {
                    _documentoHtml.Load(RutaArchivo);
                }
            }
            catch (Exception ex)
            {
                String metodo = "public void ObtenerHtml()";
                String error = String.Format("Error en el método {0} de la clase {1}| {2}", metodo, CLASE, ex.Message);
                _log.Add(Log.Modo.Error, error);
            }
        }

        #endregion
    }
}
