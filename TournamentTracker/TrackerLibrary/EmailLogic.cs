using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace TrackerLibrary
{
    public static class EmailLogic
    {
        public static void SendEmail(string toName, string toAddress, string subject, string body)
        {
            MailboxAddress fromMailbox = new MailboxAddress(GlobalConfig.AppKeyLookup("senderDisplayName"), GlobalConfig.AppKeyLookup("senderEmail"));
            MailboxAddress toMailbox = new MailboxAddress(toName, toAddress);

            var mail = new MimeMessage();

            mail.To.Add(toMailbox);
            mail.From.Add(fromMailbox);
            mail.Subject = subject;
            mail.Body = new TextPart(body);

            using (var client = new SmtpClient())
            {
                client.Connect(
                    host: GlobalConfig.AppKeyLookup("mailHost"), 
                    port: Int16.Parse(GlobalConfig.AppKeyLookup("mailPort")), 
                    useSsl: bool.Parse(GlobalConfig.AppKeyLookup("mailEnableSsl")));
                
                // Doesn't work - Use anonymously
                //client.Authenticate(
                //    userName: GlobalConfig.AppKeyLookup("mailUsername"), 
                //    password: GlobalConfig.AppKeyLookup("mailPassword"));

                client.Send(mail);
                client.Disconnect(true);
            }
        }
    }
}
