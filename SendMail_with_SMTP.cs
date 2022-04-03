using System;
using System.Net;
using System.Net.Mail;

namespace SmtpMail
{
  class MailSend 
  {
    public void SendMail(string fromMail, string fromMailPassword, string companyName, string mailText, string subject, string toMail)
    {
      MailMessage mailMessage = new MailMessage();
      mailMessage.From = new MailAddress(fromMail, companyName);
      mailMessage.To.Add(toMail);
      mailMessage.Subject = subject;
      mailMessage.Body = mailText;
      new SmtpClient()
      {
        Credentials = ((ICredentialsByHost)new NetworkCredential(fromMail, fromMailPassword)),
        Port = 587,
        Host = "smtp.gmail.com",
        EnableSsl = true
      }.SendAsync(mailMessage, (object)mailMessage);
    }
  }
}
