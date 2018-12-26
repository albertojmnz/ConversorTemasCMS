using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ConversorTemasCMS
{
    public class Log
    {
        #region Constantes

        private const String NOM_FICH = "/logConversorTema_{0}.log";

        #endregion

        #region Enumerados

        public enum Modo
        {
            Error,
            Info
        }

        #endregion

        #region Atributos

        private static Log _instance = null;
        private String _cadena = "";
        private StreamWriter _fichLog = null;

        #endregion

        #region Métodos

        public static Log GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Log();
                return _instance;
            }
            else
            {
                return _instance;
            }
        }

        private Log()
        {
            try
            {
                String nomFichLog = Application.StartupPath + NOM_FICH;
                DateTime fecInicio = DateTime.Now;
                nomFichLog = String.Format(nomFichLog, fecInicio.ToString("yyyyMMdd"));
                if (!Directory.GetParent(nomFichLog).Exists)
                {
                    Directory.GetParent(nomFichLog).Create();
                }
                _fichLog = File.AppendText(nomFichLog);
            }
            catch
            {

            }
        }

        public void Add(Modo modo, String cadena)
        {
            switch (modo)
            {
                case Modo.Error:
                    _cadena = "[" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "]" + "[Error] - " + cadena;
                    break;
                case Modo.Info:
                    _cadena = "[" + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "]" + "[Info] - " + cadena;
                    break;
            }

            _fichLog.WriteLine(_cadena);
            _fichLog.Flush();
        }

        public void Cerrar()
        {
            try
            {
                _fichLog.Close();
            }
            catch
            {
            }
        }

        #endregion
    }
}

