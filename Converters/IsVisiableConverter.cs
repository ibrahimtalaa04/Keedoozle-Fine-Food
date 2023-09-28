using System.Globalization;
using System.Windows.Data;

namespace Keedoozle_Fine_Food.Converters
{
    [ValueConversion(typeof(bool), typeof(string))]
    public class IsVisiableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "Visible" : "Hidden";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
