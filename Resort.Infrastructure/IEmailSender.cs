using System;
using System.Threading.Tasks;

namespace Resort.Infrastructure
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
