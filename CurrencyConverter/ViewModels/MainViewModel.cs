using CurrencyConverter.Models;
using CurrencyConverter.Services;
using System.Collections.Generic;
using System.ComponentModel;

namespace CurrencyConverter.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private enum ChangeSource { None, ViewModel }

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

        private ChangeSource changeSource;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel(List<Currency> currencyList)
        {
            CurrencyList = currencyList;
        }

        private void Convert(ChangeSource source)
        {
            changeSource = source;
            ToValue = Models.CurrencyConverter.Convert(fromCurrency, toCurrency, FromValue);
            changeSource = ChangeSource.None;
        }

        private void ConvertBack(ChangeSource source)
        {
            changeSource = source;
            FromValue = Models.CurrencyConverter.Convert(fromCurrency, toCurrency, ToValue);
            changeSource = ChangeSource.None;
        }

        private void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
