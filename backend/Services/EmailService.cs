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
            string ConfigEmail = "egor.player360@gmail.com";
            string ConfigPass = "m9*pYVd4V9Yn";


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

        public string PassGenerate(){
            string set = "abcdefghijklmnopqrstuvwxyzABCDEFGHIGKLMNOPQRSTUVWXYZ1234567890~`!@#№$;%^:&?*()-_=+/*-+,<>|.";
            int len = set.Length;
            int size = 16;
            string pass = "";
            Random rand = new Random();

            for(int i = 0; i <= size; i++)
            {
                pass += set[rand.Next(len)];
            }

            return pass;
        }
    }
}