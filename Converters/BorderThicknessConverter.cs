using System.Globalization;
using System.Windows.Data;

namespace Keedoozle_Fine_Food.Converters
{
    [ValueConversion(typeof(bool), typeof(int))]
    public class BorderThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? 3 : 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
