using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MvcYazGelProje.Models
{
    public class Mail
    {
        public static void MailSender(string body)
        {
            var fromAddress = new MailAddress("canatatekirdagli30@gmail.com");
            var toAddress = new MailAddress("mailadresiniz@gmail.com");
            const string subject = "Kocaeli Üniverisitesi";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "Mail_Sifresi")
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                {
                    smtp.Send(message);
                }
            }
        }
    }
}