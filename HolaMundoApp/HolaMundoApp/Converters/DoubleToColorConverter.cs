using System;
using System.Globalization;
using Xamarin.Forms;

namespace HolaMundoApp.Converters
{
    public class DoubleToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Double doubleValue))
            {
                return Color.Black;
            }

            if (doubleValue > 80)
            {
                return Color.Green;
            }
            else if (doubleValue > 50)
            {
                return Color.Yellow;
            }
            else if (doubleValue > 30)
            {
                return Color.Orange;
            }
            else
            {
                return Color.Red;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
