using CurrencyConverter.Models;
using CurrencyConverter.Services;
using System.Collections.Generic;
using System.ComponentModel;

namespace CurrencyConverter.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private enum ChangeSource { None, ViewModel }

        private ChangeSource changeSource;

        public List<Currency> CurrencyList { get; set; }

        public Currency FromCurrency
        {
            get => fromCurrency;
            set
            {
                fromCurrency = value;
                Convert(ChangeSource.ViewModel);
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
                Convert(ChangeSource.ViewModel);
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

                if (changeSource != ChangeSource.ViewModel)
                    Convert(ChangeSource.ViewModel);

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
                if (changeSource != ChangeSource.ViewModel)
                    ConvertBack(ChangeSource.ViewModel);

                OnPropertyChanged("ToValue");
            }
        }

        private double toValue = 0.0;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel(List<Currency> currencyList)
        {
            CurrencyList = currencyList;

            FromCurrency = CurrencyList.Find(cur => cur.CharCode == "RUB");
            ToCurrency = CurrencyList.Find(cur => cur.CharCode == "USD");
        }

        private void Convert(ChangeSource source)
        {
            if (fromCurrency != null && toCurrency != null)
            {
                changeSource = source;
                ToValue = Models.CurrencyConverter.Convert(fromCurrency, toCurrency, FromValue);
                changeSource = ChangeSource.None;
            }
        }

        private void ConvertBack(ChangeSource source)
        {
            if (fromCurrency != null && toCurrency != null)
            {
                changeSource = source;
                FromValue = Models.CurrencyConverter.Convert(toCurrency, fromCurrency, ToValue);
                changeSource = ChangeSource.None;
            }
        }

        private void OnPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
