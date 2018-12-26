using ConversorTemasCMS.Entidades;
using ConversorTemasCMS.Recursos;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ConversorTemasCMS
{
    public partial class VistaPrincipal : Form
    {
        #region Constantes

        private const String CLASE = "Conversor.Entidades.Formulario";
        private const String FORMATO_FICH_HTML = "Archivos .html (*.html)|*.html";
        private const String FORMATO_FICH_XML = "Archivos .xml (*.xml)|*.xml";

        #endregion

        #region Atributos

        private Log _log = Log.GetInstance();
        private int _ultimoMensaje;

        DocumentoHtml _documentoHtml = new DocumentoHtml();
        DocumentoXml _documentoXml = new DocumentoXml();
        DestinoDrupal_7 _destinoDrupal = new DestinoDrupal_7();

        CultureInfo _culture = CultureInfo.CreateSpecificCulture("ES-CO");

        #endregion

        #region Enumerados

        private enum UltimoMensaje
        {
            cargaHtmlExito = 1,
            cargaXmlExito = 2,
            cargaDestinoExito = 3,
            convertidoExito = 4,
            cargaHtmlError = 5,
            cargaXmlError = 6,
            cargaDestinoError =7,
            convertidoError = 8,
            convertidoHtmlInfo = 9,
            convertidoXmlInfo = 10,
            convertidoDestinoInfo = 11
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de la clase Formulario
        /// </summary>
        public VistaPrincipal()
        {
            InitializeComponent();
            //CargarControles();
        }

        #endregion


        public ConversorTemasCMS.Entidades.DocumentoXml DocumentoXml
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public ConversorTemasCMS.Entidades.DocumentoHtml DocumentoHtml
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public ConversorTemasCMS.Entidades.Idioma Idioma
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public ConversorTemasCMS.Entidades.DestinoDrupal_7 DestinoDrupal_7
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        #region Eventos de la página

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Formulario_Load(object sender, EventArgs e)
        {
            try
            {
                CargarIdiomas();
                AplicarIdioma();

                // Primeramente eliminamos los archivos temporales
                String[] archivos = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\temp"));
                foreach (String archivoActual in archivos)
                {
                    File.Delete(archivoActual);
                }
            }
            catch (Exception ex)
            {
                String metodo = "private void Formulario_Load(object sender, EventArgs e)";
                String error = String.Format("Error en el método {0} de la clase {1}| {2}", metodo, CLASE, ex.Message);
                _log.Add(Log.Modo.Error, error);
            }
        }

        #endregion

        #region Eventos del formulario

        /// <summary>
        /// Método encargado de cargar el archivo Html
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnFicheroHtml_Click(object sender, EventArgs e)
        {
            try
            {
                if (CargarRutaFicheroEntrada(ofdCargarFicheroHtml))
                {
                    if (!String.IsNullOrEmpty(txtFicheroHtml.Text))
                    {
                        _documentoHtml.CargarDatosArchivo(txtFicheroHtml.Text);
                    }
                    if (!String.IsNullOrEmpty(_documentoHtml.RutaArchivo))
                    {
                        MostrarExito("BtnFicheroHtmlExito");
                        _ultimoMensaje = (int)UltimoMensaje.cargaHtmlExito;
                    }
                    else
                    {
                        MostrarError("BtnFicheroHtmlError");
                        _ultimoMensaje = (int)UltimoMensaje.cargaHtmlError;
                    }
                }
            }
            catch(Exception ex)
            {
                String metodo = "public void btnFicheroHtml_Click(object sender, EventArgs e)";
                String error = String.Format("Error en el método {0} de la clase {1}| {2}", metodo, CLASE, ex.Message);
                _log.Add(Log.Modo.Error, error);
            }
        }

        /// <summary>
        /// Método encargado de cargar el archivo Xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnFicheroXml_Click(object sender, EventArgs e)
        {
            try
            {
                if (CargarRutaFicheroEntrada(ofdCargarFicheroXml))
                {
                    if (!String.IsNullOrEmpty(txtFicheroXml.Text))
                    {
                        _documentoXml.CargarDatosArchivo(txtFicheroXml.Text);
                    }
                    if (!String.IsNullOrEmpty(_documentoXml.RutaArchivo))
                    {
                        MostrarExito("BtnFicheroXmlExito");
                        _ultimoMensaje = (int)UltimoMensaje.cargaXmlExito;
                    }
                    else
                    {
                        MostrarError("BtnFicheroXmlError");
                        _ultimoMensaje = (int)UltimoMensaje.cargaXmlError;
                    }
                }
            }
            catch(Exception ex)
            {
                String metodo = "public void btnFicheroXml_Click(object sender, EventArgs e)";
                String error = String.Format("Error en el método {0} de la clase {1}| {2}", metodo, CLASE, ex.Message);
                _log.Add(Log.Modo.Error, error);
            }
        }

        /// <summary>
        /// Método que obtiene la ruta de destino del archivo resultante de la conversión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CargarRutaDestino())
                {
                    if (!String.IsNullOrEmpty(txtDestino.Text))
                    {
                        _destinoDrupal.RutaArchivoDestino = txtDestino.Text;
                        MostrarExito("BtnExaminarExito");
                        _ultimoMensaje = (int)UltimoMensaje.cargaDestinoExito;
                        lblMensajes.Text += _destinoDrupal.RutaArchivoDestino;
                        
                    }
                    else
                    {
                        MostrarError("BtnExaminarError");
                        _ultimoMensaje = (int)UltimoMensaje.cargaDestinoExito;
                    }
                }
            }
            catch(Exception ex)
            {
                String metodo = "public void btnExaminar_Click(object sender, EventArgs e)";
                String error = String.Format("Error en el método {0} de la clase {1}| {2}", metodo, CLASE, ex.Message);
                _log.Add(Log.Modo.Error, error);
            }
        }

        /// <summary>
        /// Método encargado de generar el tema para Drupal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnGenerarTema_Click(object sender, EventArgs e)
        {
            try
            {
                if(!String.IsNullOrEmpty(txtFicheroHtml.Text) && !String.IsNullOrEmpty(txtFicheroXml.Text) &&
                    !String.IsNullOrEmpty(txtDestino.Text))
                {
                    _documentoHtml.ObtenerDocumentoHtml();
                    _documentoXml.ObtenerDocumentoConfiguracion();

                    if (_documentoHtml != null && _documentoXml != null)
                    {
                        _documentoHtml.DocumentoTemaHtml = _destinoDrupal.ModificarFichero(_documentoHtml.DocumentoTemaHtml, _documentoXml.DocumentoConfiguracion);
                        _documentoHtml.DocumentoTemaHtml.Save(_destinoDrupal.RutaArchivoDestino);
                    }

                    String nombreArchivoInfo = _documentoHtml.NombreArchivo;
                    nombreArchivoInfo = nombreArchivoInfo.Replace(".html", ".info");

                    _destinoDrupal.CrearInfoDocument(nombreArchivoInfo, _documentoXml.DocumentoConfiguracion);

                    MostrarExito("BtnGenerarTemaExito");
                    _ultimoMensaje = (int)UltimoMensaje.convertidoExito;
                }
                else
                {
                    if (String.IsNullOrEmpty(txtFicheroHtml.Text))
                    {
                        MostrarInfo("BtnGenerarHtmlInfo");
                        _ultimoMensaje = (int)UltimoMensaje.convertidoHtmlInfo;
                    }
                    else if (String.IsNullOrEmpty(txtFicheroHtml.Text))
                    {
                        MostrarInfo("BtnGenerarXmlInfo");
                        _ultimoMensaje = (int)UltimoMensaje.convertidoXmlInfo;
                    }
                    else if(String.IsNullOrEmpty(txtDestino.Text))
                    {
                        MostrarInfo("BtnGenerarDestinolInfo");
                        _ultimoMensaje = (int)UltimoMensaje.convertidoDestinoInfo;
                    }
                }
            }
            catch(Exception ex)
            {
                String metodo = "public void btnGenerarTema_Click(object sender, EventArgs e)";
                String error = String.Format("Error en el método {0} de la clase {1}| {2}", metodo, CLASE, ex.Message);
                _log.Add(Log.Modo.Error, error);
            }
        }

        /// <summary>
        /// Método cuando se produce el evento de cambiar 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ddlIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _culture = CultureInfo.CreateSpecificCulture((String)ddlIdioma.SelectedValue);
                Thread.CurrentThread.CurrentCulture = _culture;
                Thread.CurrentThread.CurrentUICulture = _culture;

                switch(_ultimoMensaje)
                {
                    case (int)UltimoMensaje.cargaHtmlExito:
                        MostrarExito("BtnFicheroHtmlExito");
                        break;
                    case (int)UltimoMensaje.cargaXmlExito:
                        MostrarExito("BtnFicheroXmlExito");
                        break;
                    case (int)UltimoMensaje.cargaDestinoExito:
                        MostrarExito("BtnExaminarExito");
                        lblMensajes.Text += _destinoDrupal.RutaArchivoDestino;
                        break;
                    case (int)UltimoMensaje.cargaHtmlError:
                        MostrarError("BtnFicheroHtmlError");
                        break;
                    case (int)UltimoMensaje.cargaXmlError:
                        MostrarError("BtnFicheroXmlError");
                        break;
                    case (int)UltimoMensaje.cargaDestinoError:
                        MostrarError("BtnExaminarError");
                        break;
                    case (int)UltimoMensaje.convertidoExito:
                        MostrarExito("BtnGenerarTemaExito");
                        break;
                    case (int)UltimoMensaje.convertidoHtmlInfo:
                        MostrarInfo("BtnGenerarHtmlInfo");
                        break;
                    case (int)UltimoMensaje.convertidoXmlInfo:
                        MostrarInfo("BtnGenerarXmlInfo");
                        break;
                    case (int)UltimoMensaje.convertidoDestinoInfo:
                        MostrarInfo("BtnGenerarDestinoInfo");
                        break;
                }

                AplicarIdioma();
            }
            catch (Exception ex)
            {
                String metodo = "public void ddlIdioma_SelectedIndexChanged(object sender, EventArgs e)";
                String error = String.Format("Error en el método {0} de la clase {1}| {2}", metodo, CLASE, ex.Message);
                _log.Add(Log.Modo.Error, error);
            }
        }

        #endregion

        #region Métodos de carga

        /// <summary>
        /// Método encargado de cargar la ruta en la componente pasada como parámetro
        /// </summary>
        /// <returns></returns>
        private bool CargarRutaFicheroEntrada(OpenFileDialog componente)
        {
            try
            {
                String ruta = String.Empty;

                if (componente == ofdCargarFicheroHtml)
                {
                    ofdCargarFicheroHtml.Filter = FORMATO_FICH_HTML;
                    ofdCargarFicheroHtml.InitialDirectory = Application.StartupPath;
                    ofdCargarFicheroHtml.Title = "Seleccionar un archivo HTML";

                    if (ofdCargarFicheroHtml.ShowDialog() == DialogResult.OK)
                    {
                        ruta = ofdCargarFicheroHtml.FileName;
                        txtFicheroHtml.Text = ruta;
                    }

                    return (ruta != String.Empty);
                }
                else 
                {
                    ofdCargarFicheroXml.Filter = FORMATO_FICH_XML;
                    ofdCargarFicheroXml.InitialDirectory = Application.StartupPath;
                    ofdCargarFicheroXml.Title = "Seleccionar un archivo XML";

                    if (ofdCargarFicheroXml.ShowDialog() == DialogResult.OK)
                    {
                        ruta = ofdCargarFicheroXml.FileName;
                        txtFicheroXml.Text = ruta;
                    }
                    else
                    {
                        ruta = String.Empty;
                    }

                    return (ruta != String.Empty);
                }
            }
            catch(Exception ex)
            {
                String metodo = "private bool CargarRutaHtml()";
                String error = String.Format("Error en el método {0} de la clase {1}| {2}", metodo, CLASE, ex.Message);
                _log.Add(Log.Modo.Error, error);
                return false;
            }
        }

        /// <summary>
        /// Método encargado de cargar la ruta de destino
        /// </summary>
        /// <returns></returns>
        private bool CargarRutaDestino()
        {
            try
            {
                String ruta = String.Empty;

                if (sfdExaminar.ShowDialog() == DialogResult.OK)
                {
                    ruta = sfdExaminar.FileName;
                    txtDestino.Text = ruta;
                }
                else
                {
                    ruta = String.Empty;
                }

                return (ruta != String.Empty);
            }
            catch (Exception ex)
            {
                String metodo = "private bool CargarRutaDestino()";
                String error = String.Format("Error en el método {0} de la clase {1}| {2}", metodo, CLASE, ex.Message);
                _log.Add(Log.Modo.Error, error);
                return false;
            }
        }

        /// <summary>
        /// Método encargado de cargar la componente de idiomas
        /// </summary>
        /// <returns></returns>
        private void CargarIdiomas()
        {
            try
            {
                List<Idioma> lista = new List<Idioma>();
                lista.Add(new Idioma("Español", "ES-CO"));
                lista.Add(new Idioma("Inglés", "EN-US"));
                lista.Add(new Idioma("Francés", "fr-FR"));

                ddlIdioma.DisplayMember = "NombreIdioma";
                ddlIdioma.ValueMember = "CultureIdioma";
                ddlIdioma.DataSource = lista;
            }
            catch (Exception ex)
            {
                String metodo = "private void CargarIdiomas()";
                String error = String.Format("Error en el método {0} de la clase {1}| {2}", metodo, CLASE, ex.Message);
                _log.Add(Log.Modo.Error, error);
            }
        }

        #endregion

        #region Métodos privados

        /// <summary>
        /// 
        /// </summary>
        private void AplicarIdioma()
        {
            try
            {
                btnFicheroHtml.Text = ConversorResource.BtnFicheroHtml;
                btnFicheroXml.Text = ConversorResource.BtnFicheroXml;
                btnGenerarTema.Text = ConversorResource.BtnGenerarTema;
                btnExaminar.Text = ConversorResource.BtnExaminar;
                lblIdioma.Text = ConversorResource.LblIdioma;
                this.Text = ConversorResource.WindowTitle;
            }
            catch (Exception ex)
            {
                String metodo = "private void AplicarIdioma()";
                String error = String.Format("Error en el método {0} de la clase {1}| {2}", metodo, CLASE, ex.Message);
                _log.Add(Log.Modo.Error, error);
            }
        }

        #endregion

        #region Mensajes

        /// <summary>
        /// 
        /// </summary>
        private void LimpiarMensajes()
        {
            lblMensajes.Text = String.Empty;
            pnlMensajes.BackColor = System.Drawing.SystemColors.ControlDark;
        }

        /// <summary>
        /// 
        /// </summary>
        private void MostrarExito(String keyRecurso)
        {
            lblMensajes.Text = ConversorResource.ResourceManager.GetString(keyRecurso);
            lblMensajes.ForeColor = Color.White;
            pnlMensajes.BackColor = System.Drawing.Color.LimeGreen;
        }

        /// <summary>
        /// 
        /// </summary>
        private void MostrarInfo(String keyRecurso)
        {
            lblMensajes.Text = ConversorResource.ResourceManager.GetString(keyRecurso);
            lblMensajes.ForeColor = Color.White;
            pnlMensajes.BackColor = System.Drawing.Color.DodgerBlue;
        }

        /// <summary>
        /// 
        /// </summary>
        private void MostrarError(String keyRecurso)
        {
            lblMensajes.Text = ConversorResource.ResourceManager.GetString(keyRecurso);
            lblMensajes.ForeColor = Color.White;
            pnlMensajes.BackColor = System.Drawing.Color.Red;
        }

        #endregion
    }
}
