using Microsoft.EntityFrameworkCore;
using SentenceBuilderAPI.Models;

namespace SentenceBuilderAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Sentence> Sentences { get; set; }
        public DbSet<Words> Words { get; set; }
        public DbSet<WordType> WordType { get; set; }
        public DbSet<ExceptionsLog> ExceptionLogs { get; set; }
    }
}
