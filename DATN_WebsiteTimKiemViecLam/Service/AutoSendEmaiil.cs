using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Net.Mail;
using System.Net;

namespace DATN_WebsiteTimKiemViecLam.Service
{
    public class AutoSendEmaiil
    {

    public bool SendEmail( string toEmail, string subject, string body)
    {
            string fromEmail = "bynunbruleyt@hotmail.com";
            string password = "M2iAGF75";

            // Thông tin người nhận
            //string toEmail = "hoainhoc101@gmail.com";

            // Tạo đối tượng MailMessage
            MailMessage mail = new MailMessage(fromEmail, toEmail);

            // Tiêu đề và nội dung email
            mail.Subject = subject; 
            mail.Body = body; 

            // Cấu hình SMTP client để gửi email qua Gmail
            SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(fromEmail, password);

            try
            {
                // Gửi email
                smtpClient.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
              return false;
            }


        }
    }
}
