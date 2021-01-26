using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.DataLayer.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.UserAuthorizationService.UserService
{
    public interface IUserService
    {
        Task<AppUser> GetUserByUsername(string username);
        Task<AppUser> CreateUserAsync(CreateUserModel userModel);
        Task<AppUser> UpdateUserAsync(UpdateUserModel userModel);
        Task DeleteUser(int userId);
    }
}
