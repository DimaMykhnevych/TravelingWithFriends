﻿using AutoMapper;
using FriendsTraveling.BusinessLayer.Constants;
using FriendsTraveling.BusinessLayer.DTOs.UserDTOs;
using FriendsTraveling.BusinessLayer.Exceptions;
using FriendsTraveling.DataLayer.Models.User;
using FriendsTraveling.DataLayer.Repositories.UserRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, UserManager<AppUser> userManager, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<AppUser> GetUserByUsername(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<AppUser> GetUserWithImage(int id)
        {
            return await _userRepository.GetUserWithImage(id);
        }

        public async Task<AppUser> CreateUserAsync(CreateUserModel model)
        {
            AppUser existingUser = await _userManager.FindByNameAsync(model.Username);
            if (existingUser != null)
            {
                throw new UsernameAlreadyTakenException();
            }

            AppUser user = _mapper.Map<AppUser>(model);
            IdentityResult addUserResult = await _userManager.CreateAsync(user, model.Password);

            ValidateIdentityResult(addUserResult);

            return await GetUserByUsername(user.UserName);
        }

        public async Task<AppUser> UpdateUserProfileAsync(UpdateUserProfileDTO userProfileDTO)
        {
            AppUser existingUser = await _userManager.FindByNameAsync(userProfileDTO.Username);
            if (existingUser != null && existingUser.Id != userProfileDTO.Id)
            {
                throw new UsernameAlreadyTakenException();
            }

            AppUser user = await _userManager.FindByIdAsync(userProfileDTO.Id.ToString());
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            _mapper.Map(userProfileDTO, user);

            IdentityResult updateUserResult = await _userManager.UpdateAsync(user);
            ValidateIdentityResult(updateUserResult);

            return await GetUserByUsername(user.UserName);
        }

        public async Task<AppUser> UpdateUserAsync(UpdateUserModel model)
        {
            List<string> errors = new List<string>();
            Boolean result = ValidatePasswords(model, out errors);

            if (!result)
            {
                throw new InvalidUserPasswordException(String.Join(" ", errors));
            }

            AppUser existingUser = await _userManager.FindByNameAsync(model.Username);
            if (existingUser != null && existingUser.Id != model.Id)
            {
                throw new UsernameAlreadyTakenException();
            }

            AppUser user = await _userManager.FindByIdAsync(model.Id.ToString());
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            _mapper.Map(model, user);

            IdentityResult updateUserResult = await _userManager.UpdateAsync(user);
            ValidateIdentityResult(updateUserResult);

            if (!String.IsNullOrEmpty(model.NewPassword))
            {
                IdentityResult changePasswordsResult = await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);
                if (!changePasswordsResult.Succeeded)
                {
                    throw new InvalidUserPasswordException(String.Join(" ", errors));
                }
            }

            return await GetUserByUsername(user.UserName);
        }



        public async Task DeleteUser(int userId)
        {
            AppUser userToDelete = await _userManager.FindByIdAsync(userId.ToString());
            IdentityResult deleteUserResult = await _userManager.DeleteAsync(userToDelete);

            ValidateIdentityResult(deleteUserResult);
        }


        private void ValidateIdentityResult(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                String errorsMessage = result.Errors
                                         .Select(er => er.Description)
                                         .Aggregate((i, j) => i + ";" + j);
                throw new Exception(errorsMessage);
            }
        }

        private bool ValidatePasswords(UpdateUserModel model, out List<String> errors)
        {
            errors = new List<string>();
            if (String.IsNullOrEmpty(model.Password) &&
                String.IsNullOrEmpty(model.NewPassword) &&
                String.IsNullOrEmpty(model.ConfirmPassword))
            {
                return true;
            }

            if (String.IsNullOrEmpty(model.Password) ||
                String.IsNullOrEmpty(model.NewPassword) ||
                String.IsNullOrEmpty(model.ConfirmPassword))
            {
                errors.Add(ErrorMessagesConstants.NOT_ALL_PASS_FIELDS_FILLED);
            }

            if (!model.NewPassword.Equals(model.ConfirmPassword))
            {
                errors.Add(ErrorMessagesConstants.PASSWORDS_DO_NOT_MATCH);
            }

            return errors.Any() ? false : true;
        }

      
    }
}
