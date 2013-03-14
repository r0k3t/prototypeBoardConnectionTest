using System;
using System.Windows.Data;
using Microsoft.Robotics.Services.Sample.HiTechnic.PrototypeBoard.Proxy;
using System.Windows.Media;

namespace prototypeBoardConnectionTest.UI.Converters
{
    public class LedStatusToTemplateConverter : IValueConverter 
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return Brushes.Gray;
            var ledStatus = (LedStatus)value;
            
            switch(ledStatus) {
                case LedStatus.Red:
                    return Brushes.Red;
                case LedStatus.Blue:
                    return Brushes.Blue;
                case LedStatus.RedAndBlue:
                    return Brushes.Purple;
                default:
                    return Brushes.Gray;

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
