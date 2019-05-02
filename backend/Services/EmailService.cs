using System;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace CodeBattle.PointWar.Server.Services
{
    public class EmailService
    {
        public async Task SendEmail(string email, string subject, string message)
        {
            // From send message
            string ConfigEmail = "mail@server";
            string ConfigPass = "password";


            var emailMessage = new MimeMessage();
 
            emailMessage.From.Add(new MailboxAddress("Code Battle", ConfigEmail));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
             
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 25, false);
                await client.AuthenticateAsync(ConfigEmail, ConfigPass);
                await client.SendAsync(emailMessage);
 
                await client.DisconnectAsync(true);
            }
        }
    }
}