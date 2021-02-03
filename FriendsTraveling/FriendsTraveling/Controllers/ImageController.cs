using FriendsTraveling.BusinessLayer.DTOs.ImageDTOs;
using FriendsTraveling.BusinessLayer.Services.ImageService;
using FriendsTraveling.DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FriendsTraveling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadImage()
        {
            string currentUserName = User.Identity.Name;

            IFormCollection formCollection = await Request.ReadFormAsync();
            ImageDTO image = await _imageService.UploadImage(formCollection, currentUserName);
            if (image != null)
                return Ok(image);
            return BadRequest();
        }
    }
}
