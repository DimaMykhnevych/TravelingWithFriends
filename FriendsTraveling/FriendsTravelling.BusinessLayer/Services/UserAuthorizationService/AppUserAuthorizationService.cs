﻿using FriendsTraveling.BusinessLayer.Factories.AuthTokenFactory;
using FriendsTraveling.BusinessLayer.Services.UserService;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Models.Auth;
using FriendsTraveling.DataLayer.Models.User;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.UserAuthorizationService
{
    public class AppUserAuthorizationService : BaseAuthorizationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserService _userService;

        public AppUserAuthorizationService(
            IAuthTokenFactory tokenFactory,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, IUserService userService)
            : base(tokenFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        public override async Task<IEnumerable<Claim>> GetUserClaimsAsync(AuthSignInModel model)
        {
            AppUser user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return new List<Claim> { };
            }

            return new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };
        }

        public async override Task<bool> VerifyUserAsync(AuthSignInModel model)
        {
            AppUser user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return false;
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            return result.Succeeded;
        }

        public async override Task<UserAuthInfo> GetUserInfoAsync(string userName)
        {
            AppUser user = await _userManager.FindByNameAsync(userName);
            AppUser userWithImage = await _userService.GetUserWithImage(user.Id);
            string profileImagePath;

            if (userWithImage.ProfileImage == null)
            {
                profileImagePath = "";
            }
            else
            {
                profileImagePath = userWithImage.ProfileImage.ImagePath;
            }

            UserAuthInfo info = new UserAuthInfo
            {
                UserId = user.Id,
                Username = user.UserName,
                Role = user.Role,
                City = user.City,
                Country = user.Country,
                Age = user.Age,
                Email = user.Email,
                ProfileImagePath = profileImagePath,
            };

            return info;
        }
    }
}
