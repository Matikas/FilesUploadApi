using FilesUploadApi.Database;
using FilesUploadApi.Models;

namespace FilesUploadApi.BusinessLogic
{
    public class ImagesService : IImagesService
    {
        private readonly IDbRepository _dbRepository;

        public ImagesService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<Image> AddImageAsync(byte[] imageBytes, string fileName, string contentType)
        {
            var image = new Image
            {
                ImageBytes = imageBytes,
                ContentType = contentType,
                FileName = fileName
            };

            await _dbRepository.AddImageAsync(image);
            await _dbRepository.SaveChangesAsync();

            return image;
        }

        public async Task<Image> GetImageAsync(int id)
        {
            return await _dbRepository.GetImageAsync(id);
        }
    }
}
