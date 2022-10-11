using FilesUploadApi.Models;

namespace FilesUploadApi.Database
{
    public interface IDbRepository
    {
        Task AddImageAsync(Image image);
        Task<Image> GetImageAsync(int id);
        Task SaveChangesAsync();
    }
}
