using System.Collections.Generic;
using StockJocky.Domain.Models;

namespace StockJocky.Client.Models
{
    public class StockViewModel
    {
        public List<Stock> Stocks { get; set; }

        public StockViewModel()
        {
            Stocks = new List<Stock>();
        }

        public StockViewModel(Stock stock)
        {
            Stocks = new List<Stock>();
            Stocks.Add(stock);
        }

        public StockViewModel(List<Stock> stocks)
        {
            Stocks = stocks;
        }
    }
}
