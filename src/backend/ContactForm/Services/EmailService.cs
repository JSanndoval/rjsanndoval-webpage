using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using ContactForm.Models;
using System.Net;
using Microsoft.Extensions.Options;

namespace ContactForm.Services
{
    public class EmailService
    {
        private readonly EmailSettings _settings;
        private readonly CryptoService _cryptoService;
        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<bool> SendEmail(FormModel model)
        {
            try
            {
                var mail = new MailMessage
                {
                    From = new MailAddress(CryptoService.Decrypt(_settings.From)),
                    Subject = model.Category,
                    Body = "Buen día, mi nombre es " + (model.Name) + "\n\n" +
                    (model.Message) + "\n\n" +
                    (!string.IsNullOrWhiteSpace(model.Phone) ? "Mi número de teléfono es: " + model.Phone : "")
                };

                mail.ReplyToList.Add(new MailAddress(model.Email));
                mail.To.Add(CryptoService.Decrypt(_settings.From));

                using var smtp = new SmtpClient(_settings.SmtpServer, _settings.Port);
                smtp.Credentials = new NetworkCredential(CryptoService.Decrypt(_settings.From), CryptoService.Decrypt(_settings.Password));
                smtp.EnableSsl = true;

                await smtp.SendMailAsync(mail);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar correo: " + ex.Message);
                return false;
            }
        }
    }
}

