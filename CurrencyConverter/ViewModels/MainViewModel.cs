using CurrencyConverter.Models;
using CurrencyConverter.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyConverter.ViewModels
{
    public class MainViewModel
    {
        private readonly ICurrencyService currencyService;
        public List<Currency> CurrencyList { get; set; }

        public Currency FromCurrency { get; set; }
        public Currency ToCurrency { get; set; }
        public double FromValue { get; set; }
        public double ToValue { get; set; }
        public MainViewModel(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
            Task.Run(() => Intiailize());
        }

        private async Task Intiailize()
        {
            CurrencyList = await currencyService.GetCurrencyListAsync();
        }
    }
}
