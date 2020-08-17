using System;
using System.Net.Http;
using System.Threading.Tasks;
using StockJocky.Domain.Models;

namespace StockJocky.Domain.Factory
{
    public class StockFactory
    {
        public async Task<Stock> LoadStock()
        {
            string url = "https://api.iextrading.com/1.0/stock/msft/quote";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Stock stock = await response.Content.ReadAsAsync<Stock>();

                    return stock;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}