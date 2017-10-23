using System.Threading.Tasks;

namespace KenBonny.ClaimsExperiment.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
