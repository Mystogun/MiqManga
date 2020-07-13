using System.Buffers.Text;
using Microsoft.EntityFrameworkCore;
using MiqManga.Data.Entities;

namespace MiqManga.Data
{
    public class MiqMangaDbContext : DbContext
    {
        public MiqMangaDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FreeWall> FreeWalls { get; set; }

    }
}