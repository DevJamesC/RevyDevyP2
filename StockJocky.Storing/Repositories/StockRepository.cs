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
	}
}