using Microsoft.EntityFrameworkCore;
using SentenceBuilderAPI.Models;

namespace SentenceBuilderAPI.Data
{
    public class AppliationDbContext : DbContext
    {
        public AppliationDbContext(DbContextOptions<AppliationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Sentence> Sentences { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Words> Words { get; set; }
        public DbSet<WordType> WordType { get; set; }
    }
}
