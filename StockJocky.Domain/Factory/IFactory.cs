namespace StockJocky.Domain.Factory
{
   public interface IFactory<T> where T : class, new()
  {
    T Create();
  }
}