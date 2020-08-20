using StockJocky.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace StockJocky.Storing.Repositories
{
	public class UserRepository
	{
		private StockDbContext _db;

		public UserRepository(StockDbContext context) 
		{
      		_db = context;
    	}
	}
}