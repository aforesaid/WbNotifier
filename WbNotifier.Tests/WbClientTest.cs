using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WbNotifier.Services.WbClient;
using Xunit;

namespace WbNotifier.Tests
{
    public class WbClientTest
    {
        private readonly IWbClient _wbClient;
        private readonly string _testApiClient;

        public WbClientTest()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<WbClientTest>()
                .Build();
            _testApiClient = config["testApiKey"];
            _wbClient = new WbClient();
            
        }

        [Fact]
        public async Task GetStocksWorks()
        {
            var items = await _wbClient.GetStocks(_testApiClient);
            
            Assert.NotEmpty(items);
        }
    }
}