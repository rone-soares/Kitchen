using Library.Entities;
using Library.Resources;
using System;
using System.Net;
using System.Net.Mail;

namespace Library.Service
{
    public static class SendEmailService
    {
        //Example for send email:
        //SendEmail sendEmail = new SendEmail();
        //sendEmail.Email("rone_soares@yahoo.com.br", "Test", "Message of <b>test</b>!", true);

        public static void Email(string toward, string subject, string message, bool messageHtml)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient(Constants.Email.smtp);

                mail.From = new MailAddress(Constants.Email.sender);
                mail.To.Add(toward);
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = messageHtml;

                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential(Constants.Email.sender, Constants.Email.senderPassword);
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
            }
            catch
            {
                throw new Exception(string.Format(MessageResource.FailedToSendEmailToSubject, toward, subject));
            }
        }
    }
}
