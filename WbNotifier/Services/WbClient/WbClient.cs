using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WbNotifier.Services.WbClient.Requests.GetStocks;

namespace WbNotifier.Services.WbClient
{
    public class WbClient : IWbClient, IDisposable
    {
        private readonly HttpClient _httpClient;

        public WbClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ApiWbStockItem[]> GetStocks(string apiSpecToken)
        {
            try
            {
                var result = new List<ApiWbStockItem>();
                var skip = 0;
                const int take = 1000;
                ApiWbStockItem[] responseItems;
                do
                {
                    var url = WbClientEndpoints.GetStocksUrl(skip, take);

                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(url)
                    };
                    const string authorizationHeader = "authorization";
                    request.Headers.Add(authorizationHeader, apiSpecToken);
                    var response = await _httpClient.SendAsync(request);
                    var responseString = await response.Content.ReadAsStringAsync();

                    var jResponse = JObject.Parse(responseString);
                    responseItems = jResponse["stocks"]?.ToObject<ApiWbStockItem[]>();
                    if (responseItems != null)
                        result.AddRange(responseItems);
                    skip += take;
                } while (responseItems is {Length: > 0});

                return result.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}