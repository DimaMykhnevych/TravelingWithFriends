using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Models.User;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text;
using System.Net;

namespace FriendsTraveling.BusinessLayer.Services.Concrete
{
    public class EmailService : IEmailService
    {
        public async Task SendTicketEmail(AppUser user, string url)
        {
            MailAddress addressFrom = new MailAddress("kharkov.theaters@gmail.com", "Kharkov Theaters");
            MailAddress addressTo = new MailAddress(user.Email);
            MailMessage message = new MailMessage(addressFrom, addressTo);

            message.Subject = "Account Confirmation";
            message.IsBodyHtml = true;
            string htmlString = @$"<html>
                      <body style='background-color: #f7f1d5; 
                        padding: 15px; border-radius: 15px; 
                        box-shadow: 5px 5px 15px 5px #9F9F9F;
                        font-size: 16px;'>
                      <p>Hello {user.UserName},</p>
                      <p>Please, confirm your account by clicking the following link.</p>
                      <a href={url}>Confirm Account</a>
                         <p>Thank you,<br>-Travelling With Friends</br></p>
                      </body>
                      </html>
                     ";
            message.Body = htmlString;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("kharkov.theaters@gmail.com", "Galaxybird07");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(message);
         }
    }
}
