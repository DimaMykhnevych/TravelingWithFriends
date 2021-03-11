using FriendsTraveling.DataLayer.Models.User;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Abstract
{
    public interface IEmailService
    {
        Task SendTicketEmail(AppUser user, string url);
    }
}
