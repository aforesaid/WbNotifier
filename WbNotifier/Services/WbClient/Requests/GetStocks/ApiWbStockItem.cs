using Newtonsoft.Json;

namespace WbNotifier.Services.WbClient.Requests.GetStocks
{
    public class ApiWbStockItem
    {
        [JsonProperty("chrtId")]
        public long ChrtId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nmId")]
        public long NmId { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("barcodes")]
        public string[] Barcodes { get; set; }

        [JsonProperty("article")]
        public string Article { get; set; }

        [JsonProperty("stock")]
        public long StockStock { get; set; }

        [JsonProperty("warehouseName")]
        public string WarehouseName { get; set; }

        [JsonProperty("warehouseId")]
        public long WarehouseId { get; set; }
    }
}