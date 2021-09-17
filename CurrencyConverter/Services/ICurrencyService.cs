using CurrencyConverter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyConverter.Services
{
    public interface ICurrencyService
    {
        Task<List<Currency>> GetCurrencyListAsync();
    }
}
