using CurrencyConverter.Models;
using CurrencyConverter.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CurrencyConverter.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ICurrencyService currencyService;

        public List<Currency> CurrencyList { get; set; }

        public Currency FromCurrency 
        {
            get => fromCurrency;
            set
            {
                fromCurrency = value;
                OnPropertyChanged("FromCurrency");
            }
        }

        private Currency fromCurrency;
        public Currency ToCurrency
        {
            get => toCurrency;
            set
            {
                toCurrency = value;
                OnPropertyChanged("ToCurrency");
            }
        }

        private Currency toCurrency;

        public double FromValue 
        {
            get => fromValue;
            set
            {
                fromValue = value;
                OnPropertyChanged("FromValue");
            }
        }

        private double fromValue = 0.0;
        public double ToValue
        {
            get => toValue;
            set
            {
                toValue = value;
                OnPropertyChanged("ToValue");
            }
        }

        private double toValue = 0.0;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
            Task.Run(() => Intiailize());
        }

        private async Task Intiailize()
        {
            CurrencyList = await currencyService.GetCurrencyListAsync();

            Currency rub = new Currency
            {
                CharCode = "RUB",
                Name = "Рубль",
                Value = 1.0,
                Nominal = 1
            };

            CurrencyList.Add(rub);
            FromCurrency = rub;
            ToCurrency = CurrencyList.Find(cur => cur.CharCode == "USD");
        }

        private void Convert() => ToValue = Models.CurrencyConverter.Convert(fromCurrency, toCurrency, fromValue);

        private void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
