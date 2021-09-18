using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace CurrencyConverter.Converters
{
    class DoubleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double doubleValue = (double)value;

            return doubleValue.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string stringValue = (string)value;

            stringValue = stringValue.Replace('.', ',');

            return double.Parse(stringValue, NumberStyles.Any);
        }
    }
}
