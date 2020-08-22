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
			UserRepository ur = new UserRepository(_db);
			var newUser = ur.LoginUser(user.Username, user.Password);
			
			if(newUser != null)
			{
				newUser.AddStock(stock);
				_db.Users.Update(newUser);
				_db.SaveChanges();
			}
		}

		public void RemoveStock(User user, Stock stock)
		{
			UserRepository ur = new UserRepository(_db);
			var newUser = ur.LoginUser(user.Username, user.Password);

			if(newUser != null)
			{
				// newUser.RemoveStock(stock);
				// _db.Users.Update(newUser);     
				// Only remove reference, does not remove data entry.

				var StockForRemoval = _db.Stocks.FirstOrDefault(s => s.Symbol == stock.Symbol && s.Userid.Id == user.Id);
				_db.Stocks.Remove(StockForRemoval);
				_db.SaveChanges();
			}
		}
	}
}