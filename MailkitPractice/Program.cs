using System;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Linq.Expressions;
using MailKit.Security;
using MimeKit.Text;
using System.Threading.Tasks;
//This is an example code of sending emails using C#
// install mailkit package from Nuget
namespace MailkitPractice
{
    class Program
    {

        static void Mail(string receiver, string subject, string body)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test", "desmond20@balga.email"));//This is the subject
            message.To.Add(MailboxAddress.Parse(receiver));
            message.Subject = subject;

            message.Body = new TextPart(TextFormat.Html)
            {
                Text = body
            };

            string emailAddress = "";//Enter Senders email
            string password = "";//Enter Sender password

            SmtpClient client = new SmtpClient();

            try
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(emailAddress, password);
                client.Send(message);

                Console.WriteLine("Email Sent . :)");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
        static void Main(string[] args)
        {
            string[] receivers = { "" };//Enter Receivers Email  //Add multiple email addresses or connect a database
            string subject = "Hello My Friend ";
            string body = @"<html><body><h1>Hello</h2></body></html>";//Email body as a normal email or web email.
            int milliseconds = 2000;
            for (int i = 0; i < 1; i++)
            {
                foreach (string receiver in receivers)
                {
                    Console.WriteLine($"Sending email to {receiver}");
                    Mail(receiver, subject, body);
                }

            }
            
        }
    }

}