namespace QuoteManager.Application.DTOs
{
    public class QuoteDto
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public Guid UserId { get; set; }
        public List<QuoteItemDto> Items { get; set; } = [];
    }
}
