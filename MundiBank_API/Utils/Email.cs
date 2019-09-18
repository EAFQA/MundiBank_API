using System;
using System.Net;
using System.Net.Mail;

namespace MundiBank_API.Utils
{
    public class Email
    {
        public static void EnviarEmail()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
            mail.Subject = "Testando EndPoint PinBank";
            mail.From = new MailAddress("eduardo.andrade@mundibank.com.br");
            mail.To.Add("eduardo.andrade@mundibank.com.br");
            mail.Body = "Ops! Favor verificar o momento em que ocorreu a falha: " + DateTime.Now;

            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new NetworkCredential("eduardo.andrade@mundibank.com.br", "edu@2019");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);

            //Attachment attachment;
            //attachment = new Attachment("C:");
            //mail.Attachments.Add(attachment);
        }
    }
}
