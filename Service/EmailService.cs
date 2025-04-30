//using System.Net;
//using System.Net.Mail;

//namespace EmailSender.Service
//{
//    public class EmailService : IEmailService
//    {
//        private readonly IConfiguration _configuration;

//        public EmailService(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        public async Task SendEmail(string recepeint, string subject, string body)
//        {
//            var email = _configuration.GetValue<string>("Email_Configuration:Email");
//            var password = _configuration.GetValue<string>("Email_Configuration:Password");
//            var host = _configuration.GetValue<string>("Email_Configuration:Host");
//            var port = _configuration.GetValue<int>("Email_Configuration:Port");

//            var smtpClient = new SmtpClient(host, port);
//            smtpClient.EnableSsl = true;
//            smtpClient.UseDefaultCredentials = false;

//            smtpClient.Credentials = new NetworkCredential(email, password);

//            var message = new MailMessage(email!, recepeint, subject, body);
//            await smtpClient.SendMailAsync(message);
//        }
//    }
//}


using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailSender.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmail(string recipient, string subject, string body)
        {
            var emailConfigs = _configuration.GetSection("Email_Configurations").Get<List<EmailConfig>>();

            foreach (var config in emailConfigs)
            {
                var smtpClient = new SmtpClient(config.Host, config.Port)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(config.Email, config.Password)
                };

                var message = new MailMessage(config.Email, recipient, subject, body);
                await smtpClient.SendMailAsync(message);
            }
        }
    }

    public class EmailConfig
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}