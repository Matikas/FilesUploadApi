using FilesUploadApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesUploadApi.Database
{
    public class FilesUploadDbContext : DbContext
    {
        public DbSet<Image> Images { get; set; }

        public FilesUploadDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
