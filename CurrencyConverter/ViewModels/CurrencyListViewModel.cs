
using CurrencyConverter.Models;
using System;
using System.Collections.Generic;

namespace CurrencyConverter.ViewModels
{

    public class ChangeCurrencyViewModel
    {
        Action<Currency> itemSelectedAction;
        public List<Currency> CurrencyList { get; set; }
        public Currency SelectedCurrency 
        {
            get => selectedCurrency;
            set
            {
                selectedCurrency = value;
                itemSelectedAction(value);
            }
        }

        private Currency selectedCurrency;
        public ChangeCurrencyViewModel(List<Currency> currencyList, Currency currency, Action<Currency> itemSelectedAction)
        {
            CurrencyList = currencyList;
            selectedCurrency = currency;
            this.itemSelectedAction = itemSelectedAction;
        }
    }
}
