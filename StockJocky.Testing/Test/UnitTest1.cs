using System;
using Xunit;
using StockJocky.Domain.Factory;
using StockJocky.Domain.Models;
using System.Threading.Tasks;

namespace StockJocky.Testing
{
    public class UnitTest1
    {
     StockFactory sf = new StockFactory();

        [Fact]
        public async Task StockFactoryTest()
        {
            ApiHelper.InitializeClient();

            Stock msft = await sf.LoadStock();

            Assert.Equal("MSFT", msft.symbol);
        }
    }
}
