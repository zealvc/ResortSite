using System.Threading.Tasks;

namespace Resort.WebUI.Controllers
{
    public interface IMessageService
    {
        Task Send(string email, string subject, string message);
    }
}