using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using StockJocky.Domain.Models;

namespace StockJocky.Domain.Factory
{
    public class StockFactory
    {
        public async Task<StockSymbol> FindStock(string name, string symbol)
        {
            string url = "https://api.iextrading.com/1.0/ref-data/symbols"; // Returns a collection of objects.

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json =  await response.Content.ReadAsStreamAsync();

                    return new StockSymbol(); //Waiting for a solution.
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }   
        }

        public async Task<Stock> LoadStock() //Default method for testing. Obselete for implementation.
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

        public async Task<Stock> LoadStock(string stocksymbol) //Method with argument for specific symbol.
        {
            string url = "https://cloud.iexapis.com/stable/stock/" + stocksymbol + "/quote?token=pk_47017819d55f4fa387ee42458b6a4dd5&symbols=" + stocksymbol;

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