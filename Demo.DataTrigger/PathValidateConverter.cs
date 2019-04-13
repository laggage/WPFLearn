using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace Demo.DataTrigger
{
    class PathValidateConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return false;
            if (value.GetType() != typeof(string)) throw new ArgumentOutOfRangeException(nameof(value));

            return File.Exists((string) value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
