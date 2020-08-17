namespace StockJocky.Domain.Models
{
	public class Stock 
	{
		public int Id {get; set;}
		public string Name {get; set;}

		public string Symbol {get; set;}

		public decimal Price {get; set;}

		public decimal PriceChange {get; set;}

		public double PercentChange {get; set;}
	}
}