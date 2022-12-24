using Common.Exceptions;
using Entities.Interfaces;
using Entities.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MimeKit;
using Services.BusinessObjects;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EmailService : IEmailService
    {
        private EmailConfiguration _configuration;
        private ILogger<EmailService> _logger;
        private IUnitOfWork _unit;

        public EmailService(EmailConfiguration configuration, ILogger<EmailService> logger, IUnitOfWork unit) 
        {
            _configuration = configuration;
            _unit = unit;
            _logger = logger;
        }

        public MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(Encoding.UTF8, message.Subject, _configuration.From));
            emailMessage.To.Add(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }

        public void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_configuration.SmtpServer, _configuration.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_configuration.UserName, _configuration.Password);
                    client.Send(mailMessage);
                }
                catch
                {
                    throw new EmailSenderException("Can't send an email message.");
                    _logger.LogInformation("An error in email sending has occured");
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        
    }
}
