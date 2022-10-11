using FilesUploadApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesUploadApi.Database
{
    public class DbRepository : IDbRepository
    {
        private readonly FilesUploadDbContext _context;

        public DbRepository(FilesUploadDbContext context)
        {
            _context = context;
        }

        public async Task AddImageAsync(Image image)
        {
            await _context.Images.AddAsync(image);
        }

        public async Task<Image> GetImageAsync(int id)
        {
            return await _context.Images.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
