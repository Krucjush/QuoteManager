using QuoteManager.Application.DTOs;

namespace QuoteManager.Application.Interfaces
{
    public interface IQuoteItemService
    {
        Task<IEnumerable<QuoteItemDto>> GetQuoteItemsByQuoteId(Guid quoteId);
        Task<QuoteItemDto?> GetQuoteItemByIdAsync(Guid id);
        Task<QuoteItemDto> CreateQuoteAsync(QuoteItemDto quoteItemDto);
        Task<bool> UpdateQuoteItemAsync(Guid id, QuoteItemDto quoteItemDto);
        Task<bool> DeleteQuoteItemAsync(Guid id);
    }
}
