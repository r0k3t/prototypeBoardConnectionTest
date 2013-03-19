using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace prototypeBoardConnectionTest.UI.Converters
{
    public class ByteToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value == null)
                    return 2;

                var bytes = new[] { (byte)value, (byte)0 };
                var width = BitConverter.ToInt16(bytes, 0);
                return width == 0 ? 2 : width;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
