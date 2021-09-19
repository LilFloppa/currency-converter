namespace CurrencyConverter.Models
{
    public static class CurrencyConverter
    {
        public static double Convert(Currency fromCurrency, Currency toCurrency, double value)
        {
            // First, from fromCurrency convert to rubles, then from rubles convert to toCurrency
            double rubles = fromCurrency.Value * value / fromCurrency.Nominal;
            double result = rubles / toCurrency.Value * toCurrency.Nominal;

            return result;
        }
    }
}
