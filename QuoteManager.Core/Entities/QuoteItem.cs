namespace QuoteManager.Core.Entities
{
    public class QuoteItem
    {
        public Guid Id { get; set; }
        public Guid QuoteId { get; set; }

        public required string ProductCode { get; set; }
        public required string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal BasePrice { get; set; }
        public decimal ResellerPrice { get; set; }

        public Quote Quote { get; set; }
    }
}
