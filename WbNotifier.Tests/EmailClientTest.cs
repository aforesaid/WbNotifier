using Microsoft.Extensions.Configuration;
using WbNotifier.Services.EmailClient;
using Xunit;

namespace WbNotifier.Tests
{
    public class EmailClientTest
    {
        private readonly IEmailClient _emailClient;
        public EmailClientTest()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<EmailClientTest>()
                .Build();
            var testConfig = new EmailConfiguration("smtp.mail.ru",
                config["email"],
                config["password"],
                "Test",
                "Test");
            _emailClient = new EmailClient(testConfig);
        }

        [Fact]
        public void SendMessage()
        {
            _emailClient.SendMessage("bezlla@yandex.ru", "Test", "test content");
        }
    }
}