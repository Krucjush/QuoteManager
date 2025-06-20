using QuoteManager.Core.Enums;

namespace QuoteManager.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public UserRole Role { get; set; }

        public ICollection<Quote> Quotes { get; set; } = [];
    }
}
