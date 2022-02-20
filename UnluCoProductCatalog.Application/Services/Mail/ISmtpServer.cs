using System.Net.Mail;

namespace UnluCoProductCatalog.Application.Services.Mail
{
    public interface ISmtpServer
    {
        SmtpClient GetSmtpClient();
    }
}
