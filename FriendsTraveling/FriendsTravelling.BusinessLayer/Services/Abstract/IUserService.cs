﻿using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.DataLayer.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Abstract
{
    public interface IUserService
    {
        Task<AppUser> GetUserByUsername(string username);
        Task<IEnumerable<JourneyRequestDto>> GetUserRequestsById(int id);
        Task<AppUser> GetAllUserInfoById(int id);
        Task<AppUser> GetUserWithImage(int id);
        Task<AppUser> CreateUserAsync(CreateUserModel userModel);
        Task<AppUser> UpdateUserAsync(UpdateUserModel userModel);
        Task<AppUser> UpdateUserProfileAsync(UpdateUserProfileDto userProfileDTO);
        Task<ConfirmEmailDto> ConfirmEmail(ConfirmEmailDto confirmEmailDto);
        Task DeleteUser(int userId);
    }
}
