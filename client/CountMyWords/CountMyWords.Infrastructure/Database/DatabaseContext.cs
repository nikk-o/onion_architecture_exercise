using CountMyWords.Infrastructure.Configurations;
using CountMyWords.Infrastructure.Records;
using Microsoft.EntityFrameworkCore;

namespace CountMyWords.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DbSet<TextRecord> Texts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TextRecordConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            // TODO: Move the connection string to appsettings.json
            builder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;");
        }
    }
}
