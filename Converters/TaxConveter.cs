using System.Globalization;
using System.Windows.Data;

namespace Keedoozle_Fine_Food.Converters
{
    [ValueConversion(typeof(int), typeof(bool))]

    public class TaxConveter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value == 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
