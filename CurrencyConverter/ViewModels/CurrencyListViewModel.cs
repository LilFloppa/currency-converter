
using CurrencyConverter.Models;
using System.Collections.Generic;

namespace CurrencyConverter.ViewModels
{
    public class CurrencyListViewModel
    {
        public List<Currency> CurrencyList { get; set; }
        public Currency SelectedCurrency { get; set; }
        public CurrencyListViewModel(List<Currency> currencyList, Currency selectedCurrency)
        {
            CurrencyList = currencyList;
            SelectedCurrency = selectedCurrency;
        }
    }
}
