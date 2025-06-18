namespace QuoteManager.Core.Entities
{
    public class QuoteItem
    {
        public Guid Id { get; set; }
        public Guid QuoteId { get; set; }

        public required string ProductCode { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal BasePrice { get; set; }
        public decimal ResellerPrice { get; set; }

        public required Quote Quote { get; set; }
    }
}
