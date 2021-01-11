using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using static Juego_DINT.Pelicula;

namespace Juego_DINT
{
    class generoTipoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Genero genero;
            switch (value)
            {
                case "Comedia":
                    genero = Genero.Comedia;
                    break;
                case "Miedo":
                    genero = Genero.Miedo;
                    break;
                case "Accion":
                    genero = Genero.Accion;
                    break;
                default:
                    genero = Genero.Misterio;
                    break;
            }
            return genero;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
