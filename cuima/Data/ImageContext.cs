using System;
using cuima.Models;
using Microsoft.EntityFrameworkCore;

namespace cuima.Data
{
    public sealed class ImageContext : DbContext
    {
        public DbSet<Image> Images { get; set; }

        public ImageContext(DbContextOptions<ImageContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public static string GenerateImageId()
        {
            var encoded = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            return encoded
                .Replace("/", "_")
                .Replace("+", "-");
        }
    }
}