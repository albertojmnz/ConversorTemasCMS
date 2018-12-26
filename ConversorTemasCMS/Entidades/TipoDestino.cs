using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorTemasCMS.Entidades
{
    public class TipoDestino
    {
        #region Constantes

        private const String CLASE = "Conversor.Entidades.TipoDestino";

        #endregion

        #region Atributos

        private Log _log = Log.GetInstance();

        private String _rutaArchivoDestino = String.Empty;

        #endregion

        #region Propiedades

        public String RutaArchivoDestino
        {
            get { return _rutaArchivoDestino; }
            set { _rutaArchivoDestino = value; }
        }

        #endregion

        #region Constructores
        #endregion

        #region Métodos públicos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="documentoHtml"></param>
        /// <param name="dsConfig"></param>
        public HtmlAgilityPack.HtmlDocument ModificarFichero(HtmlAgilityPack.HtmlDocument documentoHtml, DataSet dsConfig)
        {
            try
            {
                HtmlNode nodo;

                String nodoDocConfig = String.Empty;
                String valorNodo = String.Empty;
                String nombreAtributo = String.Empty;
                String valorAtributo = String.Empty;

                // Modificamos los atributos de los nodos
                if (dsConfig.Tables["atributo"] != null)
                {
                    for (int i = 0; i < dsConfig.Tables["atributo"].Rows.Count; i++)
                    {
                        nodoDocConfig = dsConfig.Tables["atributo"].Rows[i]["nodo"].ToString();

                        nombreAtributo = dsConfig.Tables["atributo"].Rows[i]["nombre"].ToString();
                        valorAtributo = dsConfig.Tables["atributo"].Rows[i]["valor"].ToString();

                        // Seleccionamos el nodo a modificar del documento
                        nodo = documentoHtml.DocumentNode.SelectSingleNode(nodoDocConfig);

                        // Modificamos el texto dentro del NODO
                        nodo.Attributes.Remove(nombreAtributo);
                        nodo.Attributes.Add(nombreAtributo, valorAtributo);
                    }
                }

                String saltoLineaTexto = "\n\n  ";
                if (dsConfig.Tables["reemplazoTexto"] != null)
                {
                    for (int i = 0; i < dsConfig.Tables["reemplazoTexto"].Rows.Count; i++)
                    {
                        nodoDocConfig = dsConfig.Tables["reemplazoTexto"].Rows[i]["nodo"].ToString();

                        valorNodo = dsConfig.Tables["reemplazoTexto"].Rows[i]["texto"].ToString();

                        // Seleccionamos el nodo a modificar del documento
                        nodo = documentoHtml.DocumentNode.SelectSingleNode(nodoDocConfig);

                        // Modificamos el texto dentro del NODO
                        nodo.InnerHtml = saltoLineaTexto + valorNodo + saltoLineaTexto;
                    }
                }

                String saltoLineaCodigo = "\n  ";
                if (dsConfig.Tables["reemplazoCodigo"] != null)
                {
                    for (int i = 0; i < dsConfig.Tables["reemplazoCodigo"].Rows.Count; i++)
                    {
                        nodoDocConfig = dsConfig.Tables["reemplazoCodigo"].Rows[i]["nodo"].ToString();

                        valorNodo = dsConfig.Tables["reemplazoCodigo"].Rows[i]["texto"].ToString();

                        // Seleccionamos el nodo a modificar del documento
                        nodo = documentoHtml.DocumentNode.SelectSingleNode(nodoDocConfig);

                        // Modificamos el texto dentro del NODO
                        nodo.InnerHtml = saltoLineaCodigo + valorNodo + saltoLineaCodigo;
                    }
                }

                if (dsConfig.Tables["eliminacionNodo"] != null)
                {
                    for (int i = 0; i < dsConfig.Tables["eliminacionNodo"].Rows.Count; i++)
                    {
                        nodoDocConfig = dsConfig.Tables["eliminacionNodo"].Rows[i]["nodo"].ToString();

                        // Seleccionamos el nodo a modificar del documento
                        nodo = documentoHtml.DocumentNode.SelectSingleNode(nodoDocConfig);

                        HtmlNode newNode = HtmlNode.CreateNode(String.Empty);
                        nodo.ParentNode.ReplaceChild(newNode, nodo);
                    }
                }

                return documentoHtml;
            }
            catch (Exception ex)
            {
                String metodo = "public void ModificarFichero(HtmlAgilityPack.HtmlDocument documentoHtml, DataSet dsConfig)";
                String error = String.Format("Error en el método {0} de la clase {1}| {2}", metodo, CLASE, ex.Message);
                _log.Add(Log.Modo.Error, error);
                return null;
            }
        }

        #endregion
    }
}
