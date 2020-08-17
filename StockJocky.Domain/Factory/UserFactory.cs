using StockJocky.Domain.Models;

namespace StockJocky.Domain.Factory
{
    public class UserFactory : IFactory<User>
    {
        public User Create()
        {
            return new User();
        }
    }

}