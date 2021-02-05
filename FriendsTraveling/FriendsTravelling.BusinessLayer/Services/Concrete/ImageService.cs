using AutoMapper;
using FriendsTraveling.BusinessLayer.DTOs;
using FriendsTraveling.BusinessLayer.Services.Abstract;
using FriendsTraveling.DataLayer.Models;
using FriendsTraveling.DataLayer.Models.Auth;
using FriendsTraveling.DataLayer.Models.User;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Concrete
{
    public class ImageService : IImageService
    {
        private readonly BaseAuthorizationService _authorizationService;
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public ImageService(BaseAuthorizationService authorizationService,
            IImageRepository imageRepository, IMapper mapper, IUserService userService)
        {
            _authorizationService = authorizationService;
            _imageRepository = imageRepository;
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<ImageDto> UploadImage(IFormCollection formCollection, string currentUserName)
        {
            UserAuthInfo userInfo = await _authorizationService.GetUserInfoAsync(currentUserName);
            var file = formCollection.Files.First();
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);

                await DeletePreviousUserPhoto(userInfo, pathToSave);

                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Image image = new Image { AppUserId = userInfo.UserId, ImageTitle = fileName, ImagePath = dbPath };
                await _imageRepository.Insert(image);
                await _imageRepository.Save();

                return _mapper.Map<ImageDto>(image);
            }
            return null;
        }

        private async Task DeletePreviousUserPhoto(UserAuthInfo userAuthInfo, string pathToSave)
        {
            AppUser t = await _userService.GetUserWithImage(userAuthInfo.UserId);
            Image userProfileImage = t.ProfileImage;
            if (userProfileImage != null)
            {
                string path = Path.Combine(pathToSave, userProfileImage.ImageTitle);
                File.Delete(path);
            }
        }
    }
}
