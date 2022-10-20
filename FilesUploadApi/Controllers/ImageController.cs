using FilesUploadApi.BusinessLogic;
using FilesUploadApi.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilesUploadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImagesService _imagesService;

        public ImageController(IImagesService imagesService)
        {
            _imagesService = imagesService;
        }

        [HttpPost("Upload")]
        public async Task<ActionResult> UploadImage([FromForm] ImageUploadRequest request)
        {
            var savedImagesIds = new List<int>();

            foreach(var image in request.Images)
            {
                using var memoryStream = new MemoryStream();
                image.CopyTo(memoryStream);
                var imageBytes = memoryStream.ToArray();

                var savedImage = await _imagesService.AddImageAsync(imageBytes, image.FileName, image.ContentType);
                savedImagesIds.Add(savedImage.Id);
            }

            return Ok(new { ImageIds = savedImagesIds });
        }

        [HttpGet("Download")]
        public async Task<ActionResult> DownloadImage([FromQuery] int id)
        {
            var image = await _imagesService.GetImageAsync(id);
            return File(image.ImageBytes, image.ContentType);
        }
    }
}
