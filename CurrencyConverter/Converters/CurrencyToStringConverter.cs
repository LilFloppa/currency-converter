using CurrencyConverter.Models;
using System;
using Windows.UI.Xaml.Data;

namespace CurrencyConverter.Converters
{
    public class CurrencyToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return "";

            Currency currency = (Currency)value;
            return currency.CharCode;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
