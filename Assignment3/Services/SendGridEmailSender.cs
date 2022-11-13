﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Assignment3.Services
{
    public class SendGridEmailSender : IEmailSender
    {
        public SendGridEmailSender(IOptions<SendGridEmailSenderOptions> options)
        {
            this.Options = options.Value;
        }

        public SendGridEmailSenderOptions Options { get; set; }
        public async Task SendEmailAsync(
            string email, 
            string subject, 
            string htmlMessage)
        {
            await Execute(Options.ApiKey, subject, htmlMessage, email);
        }

        private async Task<Response> Execute(
            string apiKey,
            string subject,
            string message,
            string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(Options.SenderEmail, Options.SenderName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            msg.AddTo(new EmailAddress(email));

            // disable tracking settings
            msg.SetClickTracking(false, false);
            msg.SetOpenTracking(false);
            msg.SetGoogleAnalytics(false);
            msg.SetSubscriptionTracking(false);

            return await client.SendEmailAsync(msg);

        }

        public override string ToString()
        {
            return base.ToString();
        }


    }
}
