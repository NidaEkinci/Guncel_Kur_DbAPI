using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DbContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>()
                .HasKey(c => c.Id);
        }
    }
}
