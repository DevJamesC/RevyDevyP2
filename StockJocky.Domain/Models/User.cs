using System.Collections.Generic;

namespace StockJocky.Domain.Models
{
	public class User 
	{
		public int Id {get; set;}
		public string Username {get; set;}

		public string Password {get; set;}

		public List<Stock> Stocks {get; set;}

		public decimal Balance {get; set;} //To be used if we implement Stock Trading Game feature.

		public User()
		{
			
		}
	}
}