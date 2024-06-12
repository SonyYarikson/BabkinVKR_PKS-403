using Models;
using System;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace BabkinsDashBoard.tools
{
    public class NullToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return new BitmapImage(new Uri("C:\\Users\\yaros\\Desktop\\BabkinsDashBoard - master\\BabkinsDashBoard\\tools\\default.jpg", UriKind.Relative));
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}