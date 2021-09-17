
using CurrencyConverter.Models;
using System.Collections.Generic;

namespace CurrencyConverter.ViewModels
{
    public class CurrencyListViewModel
    {
        MainViewModel parentVM;

        public List<Currency> CurrencyList { get; set; }
        public Currency SelectedCurrency { get; set; }
        public CurrencyListViewModel(MainViewModel parentVM)
        {
            this.parentVM = parentVM;

            CurrencyList = parentVM.CurrencyList;
            SelectedCurrency = CurrencyList[0];
        }
    }
}
