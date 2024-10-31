using feliciano.DAL.Model;
using System.Net;
using System.Net.Mail;

namespace feliciano.PL.Helpers
{
    public class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("masadawood18@gmail.com", "jvrh helk jfoc ygai");
            client.Send("masadawood18@gmail.com",email.Recivers,email.Subject,email.Body);
        }
    }
}
