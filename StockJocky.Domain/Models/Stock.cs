namespace StockJocky.Domain.Models
{
    public class Stock
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }

        public Stock()
        {
            Symbol="";
            Price=0.0m;
        }
    }
}