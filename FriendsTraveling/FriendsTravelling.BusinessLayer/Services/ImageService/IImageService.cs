using FriendsTraveling.BusinessLayer.DTOs.ImageDTOs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FriendsTraveling.BusinessLayer.Services.ImageService
{
    public interface IImageService
    {
        Task<ImageDTO> UploadImage(IFormCollection formCollection, string currentUserName);
    }
}
