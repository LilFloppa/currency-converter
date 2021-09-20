using CurrencyConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CurrencyConverter.Services
{
    public class CurrencyService : ICurrencyService
    {
        HttpClient httpClient = new HttpClient();

        public async Task<List<Currency>> GetCurrencyListAsync()
        {
            var response = await httpClient.GetAsync(@"https://www.cbr-xml-daily.ru/daily_json.js");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                JsonDocument json = JsonDocument.Parse(content);

                List<Currency> currencyList = new List<Currency>();
                foreach (var valute in json.RootElement.GetProperty("Valute").EnumerateObject())
                    currencyList.Add(JsonSerializer.Deserialize<Currency>(valute.Value.ToString()));

                currencyList.Add(new Currency
                {
                    CharCode = "RUB",
                    Name = "Российский рубль",
                    Value = 1.0,
                    Nominal = 1
                });

                return currencyList.OrderBy(c => c.Name).ToList();
            }
            else
            {
                throw new Exception($"Error: { response.StatusCode }");
            }
        }
    }
}
