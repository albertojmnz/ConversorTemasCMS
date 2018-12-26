using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorTemasCMS.Entidades
{
    public class DestinoDrupal_7: TipoDestino
    {
        #region Constantes

        private const String CLASE = "Conversor.Entidades.DestinoDrupal_7";

        #endregion

        #region Atributos

        private Log _log = Log.GetInstance();

        #endregion

        #region Constructores
        #endregion

        #region Métodos públicos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreHtml"></param>
        /// <param name="dsConfig"></param>
        public void CrearInfoDocument(String nombreHtml, DataSet dsConfig)
        {
            try
            {
                String texto = String.Empty;

                //Vaciamos el documento .info
                File.Delete(RutaArchivoDestino + @"\" + nombreHtml);

                StreamWriter documentoInfo = File.AppendText(RutaArchivoDestino + @"\" + nombreHtml);

                //Escribimos la cabecera del documento .Info
                documentoInfo.WriteLine("name = " + nombreHtml);
                documentoInfo.WriteLine("description = " + "descripcion del .info");
                documentoInfo.WriteLine("package = Core");
                documentoInfo.WriteLine("version = VERSION");
                documentoInfo.WriteLine("core = 7.x");
                documentoInfo.WriteLine("\n");

                foreach (DataRow row in dsConfig.Tables["regiones"].Rows)
                {
                    texto = row["content"].ToString();
                    documentoInfo.WriteLine(texto.Trim());
                }
                documentoInfo.Close();
            }
            catch (Exception ex)
            {
                String metodo = "public void CrearInfoDocument(String nombreHtml, DataSet dsConfig)";
                String error = String.Format("Error en el método {0} de la clase {1}| {2}", metodo, CLASE, ex.Message);
                _log.Add(Log.Modo.Error, error);
            }
        }

        #endregion
    }
}
