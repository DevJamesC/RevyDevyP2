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
            string url = "https://cloud.iexapis.com/stable/stock/msft/quote?token=pk_47017819d55f4fa387ee42458b6a4dd5&symbols=msft";

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