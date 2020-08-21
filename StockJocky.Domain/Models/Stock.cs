namespace StockJocky.Domain.Models
{
	public class Stock 
	{
		public int Id {get; set;}
		public string CompanyName {get; set;}

		public string Symbol {get; set;}

		public decimal LatestPrice {get; set;}

		public decimal Change {get; set;}

		public double ChangePercent {get; set;}

		public int Quantity {get; set;} //To be used if we implement Stock Trading Game feature. 

		public Stock() 
		{

		}
	}
}