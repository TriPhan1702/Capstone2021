using System.Threading.Tasks;
using MimeKit;

namespace HairCutAppAPI.Utilities.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailMessage emailMessage);
    }
}