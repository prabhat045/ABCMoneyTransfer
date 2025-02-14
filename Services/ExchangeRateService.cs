using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Configuration;
using ABCMoneyTransfer.DTOs;
using System.Linq;

namespace ABCMoneyTransfer.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ExchangeRateService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<decimal> GetExchangeRateAsync()
        {
            string url = _configuration["ForexApi:Url"];
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ForexResponse>(url).ConfigureAwait(false);
                if (response != null && response.Data != null && response.Data.Payload != null)
                {
                    var payload = response.Data.Payload.FirstOrDefault();
                    if (payload != null && payload.Rates != null)
                    {
                        var myrRate = payload.Rates.FirstOrDefault(r => r.Currency.Iso3 == "MYR");
                        if (myrRate != null && decimal.TryParse(myrRate.Sell, out decimal rate))
                        {
                            return rate;
                        }
                    }
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
