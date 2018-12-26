using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversorTemasCMS.Entidades
{
    public class Idioma
    {
        #region Constantes

        private const String CLASE = "Conversor.Entidades.Idioma";

        #endregion

        #region Atributos

        private String _nombreIdioma;
        private String _cultureIdioma;

        #endregion

        #region Propiedades

        public String NombreIdioma 
        {
            get { return _nombreIdioma; }
            set { _nombreIdioma = value; } 
        }
        public String CultureIdioma 
        {
            get { return _cultureIdioma; }
            set { _cultureIdioma = value; } 
        }

        #endregion

        #region Constructores

        public Idioma(String nombre, String culture)
        {
            NombreIdioma = nombre;
            CultureIdioma = culture;
        }

        #endregion

        #region Métodos públicos

        public override String ToString()
        {
            return NombreIdioma;
        }

        #endregion
        
    }
}
