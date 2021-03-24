using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SimpleConsole
{
    internal class Program
    {
        private static void Main()
        {
            Execute().Wait();
        }

        static async Task Execute()
        {
            //var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");

            /*
                SERVER/CLIENT SETUP - gets us ready to talk
            */
            var apiKey = "NOT_IN_SOURCE_CONTROL";
            var client = new SendGridClient(apiKey);

            /*
                BUILD OUR EMAIL MESSAGE
            */
            //from email has to be the one that is registered on sendgrid!!!
            var from = new EmailAddress("mary.hook3rr@gmail.com", "Old Mary");

            var subject = "Sending with SendGrid is Fun";

            var to = new EmailAddress("mc020791@yahoo.com", "Mary Hooker");

            /*
                ACTUAL CONTENT OF EMAIL
                */

            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>Well Howdy!C#</strong>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            //Print out the result of the mail
            Console.WriteLine(response.StatusCode);
        }
    }
}
