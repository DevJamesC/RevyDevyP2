using StockJocky.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace StockJocky.Storing.Repositories
{
	public class StockRepository
	{
		private StockDbContext _db;

		public StockRepository(StockDbContext context) 
		{
      		_db = context;
    	}

		public void AddStock(User user, Stock stock)
		{
			var newUser = _db.Users.FirstOrDefault ( u => u.Username == user.Username && u.Password == user.Password);
			if(newUser != null)
			{
				newUser.AddStock(stock);
				_db.Users.Update(newUser);
				_db.SaveChanges();
			}
		}

		public void RemoveStock(User user, Stock stock)
		{
			var newUser = _db.Users.FirstOrDefault ( u => u.Username == user.Username && u.Password == user.Password);
			if(newUser != null)
			{
				newUser.RemoveStock(stock);
				_db.Users.Update(newUser);
				_db.SaveChanges();
			}
		}
	}
}