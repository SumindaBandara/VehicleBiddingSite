using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using System;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Sendinblue
{
    public class EmailSender
    {
        public static void SendEmail(string senderEmail, string senderName, string receiverEmail, string receiverName, string subject, string message)
        {
            // Initialize the Transactional Emails API
            var apiInstance = new TransactionalEmailsApi();

            // Create the sender object
            SendSmtpEmailSender sender = new SendSmtpEmailSender(senderName, senderEmail);

            // Create the receiver object
            SendSmtpEmailTo receiver = new SendSmtpEmailTo(receiverEmail, receiverName);

            // Create a list of receivers
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(receiver);

            // Set the HTML content (currently null)
            string HtmlContent = null;
            // Set the text content of the email
            string TextContent = message;

            // Try to send the email
            try
            {
                // Create the email object
                var sendSmtpEmail = new SendSmtpEmail(sender, To, null, null, HtmlContent, TextContent, subject);

                // Send the email and store the result
                CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);

                // Log the Brevo response
                Console.WriteLine("Brevo Response: " + result.ToJson());
            }
            // Handle any exceptions during email sending
            catch (Exception e)
            {
                // Log the exception message
                Console.WriteLine(e.Message);

                // Pause the execution to allow viewing the error
                Console.ReadLine();
            }
        }
    }
}