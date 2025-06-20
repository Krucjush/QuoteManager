namespace QuoteManager.Core.Entities
{
    public class Quote
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }

        public required User User { get; set; }
        public ICollection<QuoteItem> Items { get; set; } = [];
    }
}
