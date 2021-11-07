namespace WbNotifier.Services.WbClient
{
    public static class WbClientEndpoints
    {
        private const string BaseUrl = "https://suppliers-api.wildberries.ru/api";
        
        public static string GetStocksUrl(int skip = 0, int take = 100)
        {
            return BaseUrl + $"/v2/stocks?skip={skip}&take={take}";
        } 
    }
}