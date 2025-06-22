using QuoteManager.Application.DTOs;

namespace QuoteManager.Application.Interfaces
{
    public interface IQuoteService
    {
        Task<IEnumerable<QuoteDto>> GetAllQuotes();
        Task<QuoteDto?> GetQuoteByIdAsync(Guid id);
        Task<IEnumerable<QuoteDto>> GetQuoteByUserIdAsync(Guid userId);
        Task<QuoteDto> CreateQuoteAsync(QuoteDto quoteDto);
        Task<bool> UpdateQuoteAsync(Guid id, QuoteDto quoteDto);
        Task<bool> DeleteQuoteAsync(Guid id);
    }
}
