using System.Net.Mail;

namespace MS.Utils
{
    public static class MailHelper
    {
        public static bool SendMail(MailMessage message)
        {
            var smtpClient = new SmtpClient();

            try
            {
                smtpClient.Send(message);
                return true;
            }
            catch (SmtpException ex)
            {
                return false;
            }
        }
    }
}
