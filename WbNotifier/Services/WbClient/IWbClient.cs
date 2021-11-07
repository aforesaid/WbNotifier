using System.Threading.Tasks;
using WbNotifier.Services.WbClient.Requests.GetStocks;

namespace WbNotifier.Services.WbClient
{
    public interface IWbClient
    {
        public Task<ApiWbStockItem[]> GetStocks(string apiSpecToken);
    }
}