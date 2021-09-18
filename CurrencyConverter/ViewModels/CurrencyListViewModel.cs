
using CurrencyConverter.Models;
using System.Collections.Generic;

namespace CurrencyConverter.ViewModels
{

    public class CurrencyListViewModel
    {
        MainViewModel parent;
        string direction;
        public List<Currency> CurrencyList { get; set; }
        public Currency SelectedCurrency 
        {
            get => direction == "from" ? parent.FromCurrency : parent.ToCurrency;
            set
            {
                if (direction == "from")
                    parent.FromCurrency = value;
                else
                    parent.ToCurrency = value;
            }
        }
        public CurrencyListViewModel(MainViewModel parent, string direction)
        {
            this.parent = parent;
            this.direction = direction;
            CurrencyList = parent.CurrencyList;

        }
    }
}
