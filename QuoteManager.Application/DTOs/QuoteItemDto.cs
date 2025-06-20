namespace QuoteManager.Application.DTOs
{
    public class QuoteItemDto
    {
        public Guid Id { get; set; }
        public required string ProductName { get; set; }
        public decimal BasePrice { get; set; }
        public decimal ResellerPrice { get; set; }
        public Guid QuoteId { get; set; }
    }
}
