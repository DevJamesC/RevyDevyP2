using StockJocky.Domain.Models;

namespace StockJocky.Domain.Factory
{
    public class UnitOfWork
    {
        public StockFactory StockFactory { get; set; }
        public UserFactory UserFactory { get; set; }

        public UnitOfWork()
        {
            StockFactory = new StockFactory();
            UserFactory = new UserFactory();
        }
    }

}