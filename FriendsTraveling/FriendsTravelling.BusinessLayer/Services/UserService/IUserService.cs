using FriendsTraveling.BusinessLayer.DTOs.UserDTOs;
using FriendsTraveling.DataLayer.Models.User;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.UserService
{
    public interface IUserService
    {
        Task<AppUser> GetUserByUsername(string username);
        Task<AppUser> GetUserWithImage(int id);
        Task<AppUser> CreateUserAsync(CreateUserModel userModel);
        Task<AppUser> UpdateUserAsync(UpdateUserModel userModel);
        Task<AppUser> UpdateUserProfileAsync(UpdateUserProfileDTO userProfileDTO);
        Task DeleteUser(int userId);
    }
}
