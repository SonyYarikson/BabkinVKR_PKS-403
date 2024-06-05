    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Text;

namespace BabkinsDashBoard.tools
{
    public class ByteArrayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte[] byteArray)
            {
                return Encoding.UTF8.GetString(byteArray);
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                return Encoding.UTF8.GetBytes(str);
            }
            return new byte[0];
        }
    }
}
