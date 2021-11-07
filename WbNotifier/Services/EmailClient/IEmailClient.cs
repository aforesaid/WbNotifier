using System.Threading.Tasks;

namespace WbNotifier.Services.EmailClient
{
    public interface IEmailClient
    {
        public Task SendMessage(string toEmail, string toDisplayName, string message);
    }
}