using Microsoft.EntityFrameworkCore;
using QuoteManager.Core.Entities;

namespace QuoteManager.Infrastructure.Data
{
    public class QuoteDbContext(DbContextOptions<QuoteDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteItem> QuoteItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuoteDbContext).Assembly);
        }
    }
}
