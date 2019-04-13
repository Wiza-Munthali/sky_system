using System.Net.Mail;
using System.Net;

namespace SKY
{
   public static class EmailInfo
    {
        public static string username = "skyprojectl5dc";
        public static string password = "00177964";
        public static string smtp = "smtp.gmail.com";
        public static int port = 587;
        public static NetworkCredential credential;
        public static SmtpClient client;
        public static MailMessage message;
    }
}
