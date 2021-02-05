using FriendsTraveling.BusinessLayer.DTOs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.Abstract
{
    public interface IImageService
    {
        Task<ImageDto> UploadImage(IFormCollection formCollection, string currentUserName);
    }
}
