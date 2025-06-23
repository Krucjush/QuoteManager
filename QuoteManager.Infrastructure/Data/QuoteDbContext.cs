using Microsoft.EntityFrameworkCore;
using QuoteManager.Core.Entities;
using QuoteManager.Core.Enums;

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

            var adminId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var customerId = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var quoteId = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var quoteItem1Id = Guid.Parse("44444444-4444-4444-4444-444444444444");
            var quoteItem2Id = Guid.Parse("55555555-5555-5555-5555-555555555555");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = adminId,
                    Email = "admin@example.com",
                    PasswordHash = "AdminPassword",
                    Role = UserRole.Admin
                },
                new User
                {
                    Id = customerId,
                    Email = "customer@example.com",
                    PasswordHash = "CustomerPassword",
                    Role = UserRole.Customer
                }
            );

            modelBuilder.Entity<Quote>().HasData(
                new Quote
                {
                    Id = quoteId,
                    Title = "Sample Quote for Customer",
                    CreatedAt = new DateTime(2025, 1, 1),
                    UserId = customerId
                }
            );

            modelBuilder.Entity<QuoteItem>().HasData(
                new QuoteItem
                {
                    Id = quoteItem1Id,
                    QuoteId = quoteId,
                    ProductCode = "P001",
                    ProductName = "Sample Product 1",
                    Quantity = 2,
                    BasePrice = 100.00m,
                    ResellerPrice = 95.00m
                },
                new QuoteItem
                {
                    Id = quoteItem2Id,
                    QuoteId = quoteId,
                    ProductCode = "P002",
                    ProductName = "Sample Product 2",
                    Quantity = 1,
                    BasePrice = 150.00m,
                    ResellerPrice = 140.00m
                }
            );
        }
    }
}
