using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuoteManager.Core.Entities;

namespace QuoteManager.Infrastructure.Configurations
{
    internal class QuoteItemConfiguration : IEntityTypeConfiguration<QuoteItem>
    {
        public void Configure(EntityTypeBuilder<QuoteItem> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.ProductCode).IsRequired();
        }
    }
}
