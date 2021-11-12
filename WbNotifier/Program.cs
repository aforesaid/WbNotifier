using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WbNotifier.Services.EmailClient;
using WbNotifier.Services.WbClient;
using WbNotifier.Services.WbClient.Requests.GetStocks;

namespace WbNotifier
{
    class Program
    {
        private static ApiWbStockItem[] Items { get; set; }
        static async Task Main()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("configuration.json")
                .Build();
            var wbConfiguration = config.GetSection("WB").Get<WbClientConfiguration>();

            var emailConfiguration = config.GetSection("MAIL").Get<EmailConfiguration>();
            var wbClient = new WbClient();
            var emailClient = new EmailClient(emailConfiguration);
            
            while (true)
            {
                await Task.Delay(5*1000*60);
                var newItems = await wbClient.GetStocks(wbConfiguration.ApiSpecToken);
                if (Items != null)
                {
                    foreach (var item in Items)
                    {
                        var newItem = newItems.FirstOrDefault(i => i.NmId == item.NmId && i.ChrtId == item.ChrtId);
                        if (item.StockStock != newItem.StockStock)
                        {
                            var message = item.StockStock - newItem.StockStock > 0
                                ? "Остаток уменьшился"
                                : "Остаток увеличился";
                            message += $" на {Math.Abs(item.StockStock - newItem.StockStock)} единиц.";
                            await emailClient.SendMessage(config["EMAILTO"], "WbNotifed", message);
                        }
                    }
                }

                Items = newItems;
            }
        }
    }
}