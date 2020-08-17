using StockJocky.Domain.Models;

namespace StockJocky.Domain.Factory
{
    public class StockFactory : IFactory<Stock>
    {
        public Stock Create()
        {
            return new Stock();
        }

        public Stock Create(string symbol)
        {
            var stock = new Stock();
            stock.Symbol = symbol;

            return stock;
        }

        public Stock Create(decimal price)
        {
            var stock = new Stock();
            stock.Price = price;

            return stock;
        }

        public Stock Create(string symbol, decimal price)
        {
            var stock = new Stock();
            stock.Symbol = symbol;
            stock.Price = price;

            return stock;
        }
    }

}